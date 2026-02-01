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
        // Constanten voor dashboardbeheer
        private const int TOTAAL_HOKKEN = 100;
        private List<Reservering> _huidigeReserveringen = new List<Reservering>();
        private readonly Color KleurOverschreden = Color.FromArgb(255, 107, 107);

        public ucDashboard()
        {
            InitializeComponent();

            // Configureer grids 
            ConfigureerGrid(dgvCkeckInDashboard);
            ConfigureerGrid(dgvCheckOutDashboard);

            // Koppel events voor interactie
            dgvCkeckInDashboard.CellContentClick += Grid_CellContentClick;
            dgvCheckOutDashboard.CellContentClick += Grid_CellContentClick;

            dgvCkeckInDashboard.CellMouseEnter += Grid_CellMouseEnter;
            dgvCkeckInDashboard.CellMouseLeave += Grid_CellMouseLeave;
            dgvCheckOutDashboard.CellMouseEnter += Grid_CellMouseEnter;
            dgvCheckOutDashboard.CellMouseLeave += Grid_CellMouseLeave;
        }

        private void ConfigureerGrid(DataGridView dgv)
        {
            // Stel kleuren en gedrag van grid in
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 220, 255);
            dgv.CurrentCell = null;
        }

        public void RefreshDashboard()
        {
            // Initialiseer data en ververs alle statistieken en overzichten
            DataManager.Initialiseer();

            _huidigeReserveringen = DataManager.LaadReserveringen();
            List<Eigenaar> alleEigenaren = DataManager.LaadEigenaren();
            List<Dier> alleDieren = DataManager.LaadDieren();

            UpdateStatistieken(_huidigeReserveringen, alleEigenaren);
            VulGrids(_huidigeReserveringen, alleDieren);
        }

        private void UpdateStatistieken(List<Reservering> reserveringen, List<Eigenaar> eigenaren)
        {
            // Bereken aantal gasten op basis van actieve reserveringen
            var huidigeGastenLijst = reserveringen.Where(r =>
                !string.IsNullOrEmpty(r.Status) &&
                (r.Status.Trim().Equals("Ingecheckt", StringComparison.OrdinalIgnoreCase) ||
                 r.Status.Trim().Equals("Gepland", StringComparison.OrdinalIgnoreCase))).ToList();

            lblHuidigeGastenDashboard.Text = huidigeGastenLijst.Count.ToString();

            // Bereken vrije verblijven
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
            // Maak grids leeg voor nieuwe data
            dgvCkeckInDashboard.Rows.Clear();
            dgvCheckOutDashboard.Rows.Clear();
            DateTime vandaag = DateTime.Today;

            // Filter reserveringen voor check-in vandaag
            var aankomstVandaag = reserveringen.Where(r => r.StartDatum.Date == vandaag).ToList();

            // Filter reserveringen voor check-out vandaag of overschreden check-out
            var checkOutLijst = reserveringen.Where(r =>
                r.EindDatum.Date == vandaag ||
                (r.EindDatum.Date < vandaag &&
                 r.Status != null &&
                 !r.Status.Trim().Equals("Uitgecheckt", StringComparison.OrdinalIgnoreCase))
            ).OrderBy(r => r.EindDatum).ToList();

            // Vul check-in grid
            foreach (var res in aankomstVandaag)
            {
                var dier = dieren.FirstOrDefault(d => d.Chipnummer == res.DierChipnummer);
                int rowIndex = dgvCkeckInDashboard.Rows.Add(res.Verblijf, res.DierNaam, dier?.Eigenaar ?? "Onbekend");
                dgvCkeckInDashboard.Rows[rowIndex].Tag = res.DierChipnummer;
                dgvCkeckInDashboard.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }

            // Vul check-out grid en markeer overschreden check-outs
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

            // Verwijder automatische selectie na vullen
            dgvCkeckInDashboard.ClearSelection();
            dgvCheckOutDashboard.ClearSelection();
            dgvCkeckInDashboard.CurrentCell = null;
            dgvCheckOutDashboard.CurrentCell = null;
        }

        private void Grid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Toon handcursor en onderstreep tekst bij hover 
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
            // Herstel standaard cursor en tekststijl bij verlaten cel
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
            // Navigeer naar dier- of eigenaarprofiel op basis van geklikte cel
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


