using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetCareProApp
{
    public partial class ucKalender : UserControl
    {
        private DateTime huidigeMaandag;
        private const int RijHoogte = 30; // Aangepast naar 30px voor een compacter overzicht

        public ucKalender()
        {
            InitializeComponent();
            this.Load += UcKalender_Load;
            btnVorigePlanning.Click += BtnVorigePlanning_Click;
            btnVolgendePlanning.Click += BtnVolgendePlanning_Click;
            dtpWeekPlanning.ValueChanged += DtpWeekPlanning_ValueChanged;

            // Reset basisinstellingen voor een strak grid
            tlpGridPlanning.Padding = new Padding(0);
            tlpGridPlanning.Margin = new Padding(0);
        }

        private void UcKalender_Load(object sender, EventArgs e)
        {
            InstellenWeek(DateTime.Now);
        }

        private void InstellenWeek(DateTime datum)
        {
            int verschil = (int)datum.DayOfWeek - (int)DayOfWeek.Monday;
            if (verschil < 0) verschil += 7;
            huidigeMaandag = datum.AddDays(-verschil).Date;

            dtpWeekPlanning.ValueChanged -= DtpWeekPlanning_ValueChanged;
            dtpWeekPlanning.Value = huidigeMaandag;
            dtpWeekPlanning.ValueChanged += DtpWeekPlanning_ValueChanged;

            UpdateHeaderDatums();
            VulPlanningGrid();
        }

        private void UpdateHeaderDatums()
        {
            lblMaPlanning.Text = $"Ma {huidigeMaandag:dd/MM}";
            lblDiPlanning.Text = $"Di {huidigeMaandag.AddDays(1):dd/MM}";
            lblWoPlanning.Text = $"Wo {huidigeMaandag.AddDays(2):dd/MM}";
            lblDoPlanning.Text = $"Do {huidigeMaandag.AddDays(3):dd/MM}";
            lblVrPlanning.Text = $"Vr {huidigeMaandag.AddDays(4):dd/MM}";
            lblZaPlanning.Text = $"Za {huidigeMaandag.AddDays(5):dd/MM}";
            lblZoPlanning.Text = $"Zo {huidigeMaandag.AddDays(6):dd/MM}";
        }

        private void VulPlanningGrid()
        {
            tlpGridPlanning.SuspendLayout();

            // 1. Alles grondig opschonen
            tlpGridPlanning.Controls.Clear();
            tlpGridPlanning.RowStyles.Clear();
            tlpGridPlanning.RowCount = 0;

            var reserveringen = DataManager.LaadReserveringen();
            DateTime eindeWeek = huidigeMaandag.AddDays(6);

            var toegewezenHokken = reserveringen
                .Where(r => !string.IsNullOrEmpty(r.Verblijf) &&
                            r.Verblijf != "(Geen)" &&
                            r.StartDatum.Date <= eindeWeek &&
                            r.EindDatum.Date >= huidigeMaandag)
                .Select(r => r.Verblijf)
                .Distinct()
                .OrderBy(h => h.Length).ThenBy(h => h)
                .ToList();

            if (toegewezenHokken.Count == 0)
            {
                tlpGridPlanning.Height = 0;
                tlpGridPlanning.ResumeLayout();
                return;
            }

            // 2. Rijen opbouwen
            for (int i = 0; i < toegewezenHokken.Count; i++)
            {
                string hokNaam = toegewezenHokken[i];

                // Voeg rij toe en forceer de hoogte (nu 30px)
                tlpGridPlanning.RowCount++;
                tlpGridPlanning.RowStyles.Add(new RowStyle(SizeType.Absolute, RijHoogte));

                // Hok Nummer label
                Label lblHok = new Label
                {
                    Text = hokNaam.Replace("Hok ", ""),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    Margin = new Padding(0)
                };
                tlpGridPlanning.Controls.Add(lblHok, 0, i);

                // Vul de dagen
                for (int dag = 0; dag < 7; dag++)
                {
                    DateTime datumCheck = huidigeMaandag.AddDays(dag);
                    var res = reserveringen.FirstOrDefault(r =>
                        r.Verblijf == hokNaam &&
                        datumCheck >= r.StartDatum.Date &&
                        datumCheck <= r.EindDatum.Date);

                    if (res != null)
                    {
                        Panel pnlBezet = new Panel
                        {
                            Dock = DockStyle.Fill,
                            Margin = new Padding(1),
                            BackColor = datumCheck == res.EindDatum.Date ? Color.LightBlue : Color.LightGreen
                        };

                        Label lblDier = new Label
                        {
                            Text = res.DierNaam,
                            ForeColor = Color.Black,
                            Dock = DockStyle.Fill,
                            TextAlign = ContentAlignment.MiddleCenter,
                            Cursor = Cursors.Hand,
                            Font = new Font("Segoe UI", 8, FontStyle.Regular)
                        };

                        lblDier.Click += (s, e) => GaNaarDierProfiel(res.DierChipnummer);
                        pnlBezet.Controls.Add(lblDier);
                        tlpGridPlanning.Controls.Add(pnlBezet, dag + 1, i);
                    }
                }
            }

            // 3. Totale hoogte berekening
            int extraVoorBorders = (tlpGridPlanning.CellBorderStyle == TableLayoutPanelCellBorderStyle.None) ? 0 : toegewezenHokken.Count + 1;
            tlpGridPlanning.Height = (toegewezenHokken.Count * RijHoogte) + extraVoorBorders;

            tlpGridPlanning.ResumeLayout();
        }

        private void GaNaarDierProfiel(string chipnummer)
        {
            var dier = DataManager.LaadDieren().FirstOrDefault(d => d.Chipnummer == chipnummer);
            if (dier != null && this.ParentForm is MainForm mainForm)
            {
                ucProfielPaginaDieren profielScherm = new ucProfielPaginaDieren();
                profielScherm.VulData(dier, "Kalender");
                mainForm.ToonScherm(profielScherm);
            }
        }

        private void BtnVorigePlanning_Click(object sender, EventArgs e) => InstellenWeek(huidigeMaandag.AddDays(-7));
        private void BtnVolgendePlanning_Click(object sender, EventArgs e) => InstellenWeek(huidigeMaandag.AddDays(7));
        private void DtpWeekPlanning_ValueChanged(object sender, EventArgs e) => InstellenWeek(dtpWeekPlanning.Value);
    }
}
