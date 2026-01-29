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
        private const string ZoekPlaceholderDieren = "Typ naam van dier of eigenaar..";

        public ucDieren()
        {
            InitializeComponent();
        }

        private void ucDieren_Load(object sender, EventArgs e)
        {
            DataManager.Initialiseer();
            VerversGrid();

            txbZoekenDieren.Text = ZoekPlaceholderDieren;
            txbZoekenDieren.ForeColor = Color.Gray;
        }

        private void VerversGrid(string filter = "")
        {
            List<Dier> lijst = DataManager.LaadDieren();
            dgvDieren.AutoGenerateColumns = false;

            // Kolomkoppelingen
            ColumnNaam.DataPropertyName = "Naam";
            ColumnSoort.DataPropertyName = "Soort";
            ColumnLeeftijd.DataPropertyName = "Leeftijd";
            ColumnRas.DataPropertyName = "Ras";
            ColumnGeslacht.DataPropertyName = "Geslacht";
            ColumnChipnr.DataPropertyName = "Chipnummer";
            ColumnEigenaar.DataPropertyName = "Eigenaar";
            ColumnVerblijf.DataPropertyName = "Verblijf";

            // Filter toepassen als er tekst is
            if (!string.IsNullOrWhiteSpace(filter) && filter != ZoekPlaceholderDieren)
            {
                string zoekTerm = filter.ToLower().Trim();
                lijst = lijst.Where(d =>
                    (d.Naam != null && d.Naam.ToLower().Contains(zoekTerm)) ||
                    (d.Eigenaar != null && d.Eigenaar.ToLower().Contains(zoekTerm))
                ).ToList();
            }

            dgvDieren.DataSource = null;
            dgvDieren.DataSource = lijst;
        }

        private void txbZoekenDieren_TextChanged(object sender, EventArgs e)
        {
            // Ververs de lijst direct bij elke wijziging, behalve bij de placeholder
            if (txbZoekenDieren.Text != ZoekPlaceholderDieren)
            {
                VerversGrid(txbZoekenDieren.Text);
            }
        }

        private void txbZoekenDieren_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                VerversGrid(txbZoekenDieren.Text);
                e.SuppressKeyPress = true; // Geen piepje
            }
        }

        private void btnZoekenDieren_Click(object sender, EventArgs e)
        {
            VerversGrid(txbZoekenDieren.Text);
        }

        private void txbZoekenDieren_Enter(object sender, EventArgs e)
        {
            if (txbZoekenDieren.Text == ZoekPlaceholderDieren)
            {
                txbZoekenDieren.Text = "";
                txbZoekenDieren.ForeColor = Color.Black;
            }
        }

        private void txbZoekenDieren_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbZoekenDieren.Text))
            {
                txbZoekenDieren.Text = ZoekPlaceholderDieren;
                txbZoekenDieren.ForeColor = Color.Gray;
            }
        }

        // --- Navigatie en andere knoppen ---

        private void btnToevoegenDieren_Click(object sender, EventArgs e)
        {
            if (this.ParentForm is MainForm mainForm)
            {
                mainForm.ToonScherm(new ucDierenToevoegen());
            }
        }

        private void btnBewerkenDieren_Click(object sender, EventArgs e)
        {
            if (dgvDieren.SelectedRows.Count > 0)
            {
                Dier gekozenDier = (Dier)dgvDieren.SelectedRows[0].DataBoundItem;
                ucDierenToevoegen bewerkScherm = new ucDierenToevoegen();
                bewerkScherm.LaadDierVoorBewerken(gekozenDier);

                if (this.ParentForm is MainForm mainForm)
                {
                    mainForm.ToonScherm(bewerkScherm);
                }
            }
            else
            {
                MessageBox.Show("Selecteer eerst een dier uit de lijst om te bewerken.");
            }
        }

        private void btnVerwijderDieren_Click(object sender, EventArgs e)
        {
            if (dgvDieren.SelectedRows.Count > 0)
            {
                Dier gekozenDier = (Dier)dgvDieren.SelectedRows[0].DataBoundItem;
                var resultaat = MessageBox.Show($"Weet je zeker dat je {gekozenDier.Naam} wilt verwijderen?",
                                                "Bevestig Verwijderen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

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
            if (e.RowIndex < 0) return;

            if (dgvDieren.Columns[e.ColumnIndex].Name == "ColumnNaam")
            {
                Dier gekozenDier = (Dier)dgvDieren.Rows[e.RowIndex].DataBoundItem;
                if (gekozenDier != null)
                {
                    ucProfielPaginaDieren profiel = new ucProfielPaginaDieren();
                    profiel.VulData(gekozenDier);

                    if (this.ParentForm is MainForm mainForm)
                    {
                        mainForm.ToonScherm(profiel);
                    }
                }
            }
        }
    }
}
