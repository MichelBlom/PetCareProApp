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
        private const int RijHoogte = 30;

        public ucKalender()
        {
            InitializeComponent();
            this.Load += UcKalender_Load;
            btnVorigePlanning.Click += BtnVorigePlanning_Click;
            btnVolgendePlanning.Click += BtnVolgendePlanning_Click;
            dtpWeekPlanning.ValueChanged += DtpWeekPlanning_ValueChanged;

            // Zorg voor een strakke weergave 
            tlpGridPlanning.Padding = new Padding(0);
            tlpGridPlanning.Margin = new Padding(0);
        }

        private void UcKalender_Load(object sender, EventArgs e)
        {
            InstellenWeek(DateTime.Now);
        }

        private void InstellenWeek(DateTime datum)
        {
            // Bereken de maandag van de betreffende week
            int verschil = (int)datum.DayOfWeek - (int)DayOfWeek.Monday;
            if (verschil < 0) verschil += 7;
            huidigeMaandag = datum.AddDays(-verschil).Date;

            // Update de DateTimePicker zonder een dubbele event-trigger
            dtpWeekPlanning.ValueChanged -= DtpWeekPlanning_ValueChanged;
            dtpWeekPlanning.Value = huidigeMaandag;
            dtpWeekPlanning.ValueChanged += DtpWeekPlanning_ValueChanged;

            UpdateHeaderDatums();
            VulPlanningGrid();
        }

        private void UpdateHeaderDatums()
        {
            // Zet de datums in de kolomkoppen van de tabel
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
            tlpGridPlanning.Controls.Clear();
            tlpGridPlanning.RowStyles.Clear();
            tlpGridPlanning.RowCount = 0;

            var reserveringen = DataManager.LaadReserveringen();
            DateTime eindeWeek = huidigeMaandag.AddDays(6);

            // Haal alle hokken op die deze week bezet zijn
            var toegewezenHokken = reserveringen
                .Where(r => !string.IsNullOrEmpty(r.Verblijf) &&
                            r.Verblijf != "(Geen)" &&
                            r.StartDatum.Date <= eindeWeek &&
                            (r.EindDatum.Date >= huidigeMaandag || (r.EindDatum.Date < huidigeMaandag && DateTime.Today >= r.EindDatum.Date)))
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

            // Maak voor elk bezet hok een rij aan
            for (int i = 0; i < toegewezenHokken.Count; i++)
            {
                string hokNaam = toegewezenHokken[i];
                tlpGridPlanning.RowCount++;
                tlpGridPlanning.RowStyles.Add(new RowStyle(SizeType.Absolute, RijHoogte));

                // Hoknummer in de eerste kolom
                Label lblHok = new Label
                {
                    Text = hokNaam.Replace("Hok ", ""),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    Margin = new Padding(0)
                };
                tlpGridPlanning.Controls.Add(lblHok, 0, i);

                // Controleer de status voor elke dag van de week
                for (int dag = 0; dag < 7; dag++)
                {
                    DateTime datumCheck = huidigeMaandag.AddDays(dag);

                    var res = reserveringen.FirstOrDefault(r =>
                        r.Verblijf == hokNaam &&
                        ((datumCheck >= r.StartDatum.Date && datumCheck <= r.EindDatum.Date) ||
                         (datumCheck > r.EindDatum.Date && datumCheck <= DateTime.Today)));

                    if (res != null)
                    {
                        Color achtergrondKleur;
                        if (datumCheck > res.EindDatum.Date)
                        {
                            // Rood: Dier is nog aanwezig na uitcheckdatum
                            achtergrondKleur = Color.FromArgb(255, 107, 107);
                        }
                        else if (datumCheck == res.EindDatum.Date)
                        {
                            // Blauw: Dier vertrekt vandaag
                            achtergrondKleur = Color.FromArgb(100, 149, 237);
                        }
                        else
                        {
                            // Groen: Normale bezetting
                            achtergrondKleur = Color.FromArgb(100, 220, 100);
                        }

                        Panel pnlBezet = new Panel
                        {
                            Dock = DockStyle.Fill,
                            Margin = new Padding(1),
                            BackColor = achtergrondKleur
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

                        // Navigeer naar dierprofiel bij klik op de naam
                        lblDier.Click += (s, e) => GaNaarDierProfiel(res.DierChipnummer);
                        pnlBezet.Controls.Add(lblDier);
                        tlpGridPlanning.Controls.Add(pnlBezet, dag + 1, i);
                    }
                }
            }

            // Pas de hoogte van de tabel aan op basis van het aantal rijen
            int extraVoorBorders = (tlpGridPlanning.CellBorderStyle == TableLayoutPanelCellBorderStyle.None) ? 0 : toegewezenHokken.Count + 1;
            tlpGridPlanning.Height = (toegewezenHokken.Count * RijHoogte) + extraVoorBorders;

            tlpGridPlanning.ResumeLayout();
        }

        private void GaNaarDierProfiel(string chipnummer)
        {
            // Zoek dier en open de profielpagina
            var dier = DataManager.LaadDieren().FirstOrDefault(d => d.Chipnummer == chipnummer);
            if (dier != null && this.ParentForm is MainForm mainForm)
            {
                ucProfielPaginaDieren profielScherm = new ucProfielPaginaDieren();
                profielScherm.VulData(dier, "Kalender");
                mainForm.ToonScherm(profielScherm);
            }
        }

        // Navigatie-events voor de weekplanning
        private void BtnVorigePlanning_Click(object sender, EventArgs e) => InstellenWeek(huidigeMaandag.AddDays(-7));
        private void BtnVolgendePlanning_Click(object sender, EventArgs e) => InstellenWeek(huidigeMaandag.AddDays(7));
        private void DtpWeekPlanning_ValueChanged(object sender, EventArgs e) => InstellenWeek(dtpWeekPlanning.Value);
    }
}
