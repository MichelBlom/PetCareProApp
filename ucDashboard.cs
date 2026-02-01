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
    public partial class ucDashboard : UserControl
    {
        private const int TOTAAL_HOKKEN = 100;
        private List<Reservering> _huidigeReserveringen = new List<Reservering>();
        private readonly Color KleurOverschreden = Color.FromArgb(255, 107, 107);

        public ucDashboard()
        {
            InitializeComponent();

            // Voorkom automatische selectie en stel zwarte tekst in
            ConfigureerGrid(dgvCkeckInDashboard);
            ConfigureerGrid(dgvCheckOutDashboard);

            // Events koppelen voor navigatie
            dgvCkeckInDashboard.CellContentClick += Grid_CellContentClick;
            dgvCheckOutDashboard.CellContentClick += Grid_CellContentClick;

            // Events koppelen voor de interactieve "Link" stijl
            dgvCkeckInDashboard.CellMouseEnter += Grid_CellMouseEnter;
            dgvCkeckInDashboard.CellMouseLeave += Grid_CellMouseLeave;
            dgvCheckOutDashboard.CellMouseEnter += Grid_CellMouseEnter;
            dgvCheckOutDashboard.CellMouseLeave += Grid_CellMouseLeave;
        }

        private void ConfigureerGrid(DataGridView dgv)
        {
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Zet de selectiekleur op een heel licht grijs/blauw zodat rood erdoorheen kan schijnen
            // Of gebruik Color.Transparent als je helemaal geen selectiekleur wilt zien
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 220, 255);

            // Zorg dat de focus niet direct een cel selecteert
            dgv.CurrentCell = null;
        }

        public void RefreshDashboard()
        {
            DataManager.Initialiseer();

            _huidigeReserveringen = DataManager.LaadReserveringen();
            List<Eigenaar> alleEigenaren = DataManager.LaadEigenaren();
            List<Dier> alleDieren = DataManager.LaadDieren();

            UpdateStatistieken(_huidigeReserveringen, alleEigenaren);
            VulGrids(_huidigeReserveringen, alleDieren);
        }

        private void UpdateStatistieken(List<Reservering> reserveringen, List<Eigenaar> eigenaren)
        {
            var huidigeGastenLijst = reserveringen.Where(r =>
                !string.IsNullOrEmpty(r.Status) &&
                (r.Status.Trim().Equals("Ingecheckt", StringComparison.OrdinalIgnoreCase) ||
                 r.Status.Trim().Equals("Gepland", StringComparison.OrdinalIgnoreCase))).ToList();

            lblHuidigeGastenDashboard.Text = huidigeGastenLijst.Count.ToString();

            int bezetteHokkenCount = huidigeGastenLijst
                .Select(r => r.Verblijf)
                .Where(v => !string.IsNullOrEmpty(v) && v != "(Geen)")
                .Distinct()
                .Count();

            lblVrijeHokkenDashboard.Text = (TOTAAL_HOKKEN - bezetteHokkenCount).ToString();
            lblAantalKlantenDashboard.Text = eigenaren.Count.ToString();
            lblAantalCheckInsDashboard.Text = reserveringen.Count.ToString();
        }

        private void VulGrids(List<Reservering> reserveringen, List<Dier> dieren)
        {
            dgvCkeckInDashboard.Rows.Clear();
            dgvCheckOutDashboard.Rows.Clear();
            DateTime vandaag = DateTime.Today;

            var aankomstVandaag = reserveringen.Where(r => r.StartDatum.Date == vandaag).ToList();

            var checkOutLijst = reserveringen.Where(r =>
                r.EindDatum.Date == vandaag ||
                (r.EindDatum.Date < vandaag &&
                 r.Status != null &&
                 !r.Status.Trim().Equals("Uitgecheckt", StringComparison.OrdinalIgnoreCase))
            ).OrderBy(r => r.EindDatum).ToList();

            foreach (var res in aankomstVandaag)
            {
                var dier = dieren.FirstOrDefault(d => d.Chipnummer == res.DierChipnummer);
                int rowIndex = dgvCkeckInDashboard.Rows.Add(res.Verblijf, res.DierNaam, dier?.Eigenaar ?? "Onbekend");
                dgvCkeckInDashboard.Rows[rowIndex].Tag = res.DierChipnummer;
                dgvCkeckInDashboard.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }

            foreach (var res in checkOutLijst)
            {
                var dier = dieren.FirstOrDefault(d => d.Chipnummer == res.DierChipnummer);
                int rowIndex = dgvCheckOutDashboard.Rows.Add(res.Verblijf, res.DierNaam, dier?.Eigenaar ?? "Onbekend");
                dgvCheckOutDashboard.Rows[rowIndex].Tag = res.DierChipnummer;
                dgvCheckOutDashboard.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.Black;

                if (res.EindDatum.Date < vandaag)
                {
                    dgvCheckOutDashboard.Rows[rowIndex].DefaultCellStyle.BackColor = KleurOverschreden;
                }
            }

            // Cruciaal: Verwijder de automatische selectie na het vullen van de data
            dgvCkeckInDashboard.ClearSelection();
            dgvCheckOutDashboard.ClearSelection();
            dgvCkeckInDashboard.CurrentCell = null;
            dgvCheckOutDashboard.CurrentCell = null;
        }

        private void Grid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 1) return;

            DataGridView grid = (DataGridView)sender;
            if (e.ColumnIndex == 1 || e.ColumnIndex == 2)
            {
                grid.Cursor = Cursors.Hand;
                grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Blue;
                grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.Font = new Font(grid.Font, FontStyle.Underline);
            }
        }

        private void Grid_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 1) return;

            DataGridView grid = (DataGridView)sender;
            if (e.ColumnIndex == 1 || e.ColumnIndex == 2)
            {
                grid.Cursor = Cursors.Default;
                grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Black;
                grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.Font = new Font(grid.Font, FontStyle.Regular);
            }
        }

        private void Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridView grid = (DataGridView)sender;
            string chipnummer = grid.Rows[e.RowIndex].Tag?.ToString();

            if (string.IsNullOrEmpty(chipnummer)) return;

            var alleDieren = DataManager.LaadDieren();
            var dier = alleDieren.FirstOrDefault(d => d.Chipnummer == chipnummer);

            if (dier == null) return;

            MainForm mainForm = (MainForm)this.ParentForm;

            if (e.ColumnIndex == 1)
            {
                mainForm.ToonScherm(new ucProfielPaginaDieren(dier));
            }
            else if (e.ColumnIndex == 2)
            {
                var eigenaar = DataManager.LaadEigenaren().FirstOrDefault(eig => eig.Naam == dier.Eigenaar);
                if (eigenaar != null)
                {
                    mainForm.ToonScherm(new ucProfielEigenaar(eigenaar));
                }
            }
        }
    }
}


