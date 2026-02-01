using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PetCareProApp
{
    public partial class ucDieren : UserControl
    {
        // Tekst voor de zoekbalk wanneer deze leeg is
        private const string ZoekPlaceholderDieren = "Typ naam van dier of eigenaar..";

        public ucDieren()
        {
            InitializeComponent();
        }

        private void ucDieren_Load(object sender, EventArgs e)
        {
            // Initialiseer data en stel de zoekbalk in bij het laden
            DataManager.Initialiseer();
            VerversGrid();
            txbZoekenDieren.Text = ZoekPlaceholderDieren;
            txbZoekenDieren.ForeColor = Color.Gray;
        }

        private void VerversGrid(string filter = "")
        {
            // Laad dierenlijst en koppel de kolommen aan juiste data
            List<Dier> lijst = DataManager.LaadDieren();
            dgvDieren.AutoGenerateColumns = false;
            ColumnNaam.DataPropertyName = "Naam";
            ColumnSoort.DataPropertyName = "Soort";
            ColumnLeeftijd.DataPropertyName = "Leeftijd";
            ColumnRas.DataPropertyName = "Ras";
            ColumnGeslacht.DataPropertyName = "Geslacht";
            ColumnChipnr.DataPropertyName = "Chipnummer";
            ColumnEigenaar.DataPropertyName = "Eigenaar";
            ColumnVerblijf.DataPropertyName = "Verblijf";

            // Pas filter toe op naam of eigenaar indien er een zoekterm is ingevoerd
            if (!string.IsNullOrWhiteSpace(filter) && filter != ZoekPlaceholderDieren)
            {
                string zoekTerm = filter.ToLower().Trim();
                lijst = lijst.Where(d =>
                    (d.Naam != null && d.Naam.ToLower().Contains(zoekTerm)) ||
                    (d.Eigenaar != null && d.Eigenaar.ToLower().Contains(zoekTerm))
                ).ToList();
            }

            // Toon de (gefilterde) lijst in het grid
            dgvDieren.DataSource = null;
            dgvDieren.DataSource = lijst;
        }

        // Handlers voor de zoekfunctionaliteit en placeholder
        private void txbZoekenDieren_TextChanged(object sender, EventArgs e) { if (txbZoekenDieren.Text != ZoekPlaceholderDieren) VerversGrid(txbZoekenDieren.Text); }
        private void txbZoekenDieren_KeyDown(object sender, KeyEventArgs e) { if (e.KeyCode == Keys.Enter) { VerversGrid(txbZoekenDieren.Text); e.SuppressKeyPress = true; } }
        private void btnZoekenDieren_Click(object sender, EventArgs e) => VerversGrid(txbZoekenDieren.Text);
        private void txbZoekenDieren_Enter(object sender, EventArgs e) { if (txbZoekenDieren.Text == ZoekPlaceholderDieren) { txbZoekenDieren.Text = ""; txbZoekenDieren.ForeColor = Color.Black; } }
        private void txbZoekenDieren_Leave(object sender, EventArgs e) { if (string.IsNullOrWhiteSpace(txbZoekenDieren.Text)) { txbZoekenDieren.Text = ZoekPlaceholderDieren; txbZoekenDieren.ForeColor = Color.Gray; } }

        private void btnToevoegenDieren_Click(object sender, EventArgs e)
        {
            // Open het scherm om een nieuw dier toe te voegen
            if (this.ParentForm is MainForm mainForm) mainForm.ToonScherm(new ucDierenToevoegen());
        }

        private void btnBewerkenDieren_Click(object sender, EventArgs e)
        {
            // Open bewerkscherm voor het geselecteerde dier
            if (dgvDieren.SelectedRows.Count > 0)
            {
                Dier gekozenDier = (Dier)dgvDieren.SelectedRows[0].DataBoundItem;
                ucDierenToevoegen bewerkScherm = new ucDierenToevoegen();
                bewerkScherm.LaadDierVoorBewerken(gekozenDier);
                if (this.ParentForm is MainForm mainForm) mainForm.ToonScherm(bewerkScherm);
            }
            else MessageBox.Show("Selecteer eerst een dier uit de lijst om te bewerken.");
        }

        private void btnVerwijderDieren_Click(object sender, EventArgs e)
        {
            // Verwijder geselecteerd dier na bevestiging van de gebruiker
            if (dgvDieren.SelectedRows.Count > 0)
            {
                Dier gekozenDier = (Dier)dgvDieren.SelectedRows[0].DataBoundItem;
                var resultaat = MessageBox.Show($"Weet je zeker dat je {gekozenDier.Naam} wilt verwijderen?", "Bevestig", MessageBoxButtons.YesNo);
                if (resultaat == DialogResult.Yes)
                {
                    List<Dier> lijst = DataManager.LaadDieren();
                    lijst.RemoveAll(d => d.Chipnummer == gekozenDier.Chipnummer);
                    DataManager.SlaDierenOp(lijst);
                    VerversGrid();
                }
            }
        }

        private void dgvDieren_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Navigeer naar profielpagina bij klik op naam of eigenaar in het grid
            if (e.RowIndex < 0) return;

            // Controleer of er op de naamkolom is geklikt voor het dierprofiel
            if (dgvDieren.Columns[e.ColumnIndex].Name == "ColumnNaam")
            {
                Dier gekozenDier = (Dier)dgvDieren.Rows[e.RowIndex].DataBoundItem;
                if (gekozenDier != null && this.ParentForm is MainForm mainForm)
                {
                    ucProfielPaginaDieren profiel = new ucProfielPaginaDieren();
                    profiel.VulData(gekozenDier);
                    mainForm.ToonScherm(profiel);
                }
            }

            // Controleer voetafrduk
            if (dgvDieren.Columns[e.ColumnIndex].Name == "ColumnEigenaar")
            {
                string eigenaarNaam = dgvDieren.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
                if (!string.IsNullOrEmpty(eigenaarNaam))
                {
                    var eigenaar = DataManager.LaadEigenaren().FirstOrDefault(eig => eig.Naam == eigenaarNaam);
                    if (eigenaar != null && this.ParentForm is MainForm mainForm)
                    {
                        ucProfielEigenaar profielEigenaar = new ucProfielEigenaar();
                        profielEigenaar.VulData(eigenaar, "DierenLijst");
                        mainForm.ToonScherm(profielEigenaar);
                    }
                }
            }
        }
    }
}
