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
    public partial class ucDieren : UserControl
    {
        
        public ucDieren()
        {
            InitializeComponent();
        }

        private void btnToevoegenDieren_Click(object sender, EventArgs e)
        {
            //ToonScherm(new ucDierenToevoegen());
            if (this.ParentForm is MainForm mainForm)
            {
                mainForm.ToonScherm(new ucDierenToevoegen());
            }
        }

        private void ucDieren_Load(object sender, EventArgs e)
        {
            DataManager.Initialiseer(); // Zorgt dat de mappen bestaan
            VerversGrid();

            txbZoekenDieren.Text = "Typ naam dier of eigenaar...";
            txbZoekenDieren.ForeColor = Color.Gray;
        }

        private void VerversGrid()
        {
            List<Dier> lijst = DataManager.LaadDieren();
            dgvDieren.AutoGenerateColumns = false;

            // Koppeling van kolommen aan eigenschappen van Dier
            ColumnNaam.DataPropertyName = "Naam";
            ColumnSoort.DataPropertyName = "Soort";
            ColumnLeeftijd.DataPropertyName = "Leeftijd";
            ColumnRas.DataPropertyName = "Ras";
            ColumnGeslacht.DataPropertyName = "Geslacht";
            ColumnChipnr.DataPropertyName = "Chipnummer";
            ColumnEigenaar.DataPropertyName = "Eigenaar";
            ColumnVerblijf.DataPropertyName = "Verblijf";

            dgvDieren.DataSource = lijst;
        }

        private void dgvDieren_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

            
            if (e.RowIndex < 0) return;

            // Check of de kolomnaam EXACT overeenkomt (ColumnNaam)
            if (dgvDieren.Columns[e.ColumnIndex].Name == "ColumnNaam")
            {
                try
                {
                    // Haal het dier op
                    Dier gekozenDier = (Dier)dgvDieren.Rows[e.RowIndex].DataBoundItem;

                    if (gekozenDier != null)
                    {
                        // Maak het profielscherm aan
                        ucProfielPaginaDieren profiel = new ucProfielPaginaDieren();

                        // Vul de data 
                        profiel.VulData(gekozenDier);

                        // Wissel van scherm
                        if (this.ParentForm is MainForm mainForm)
                        {
                            mainForm.ToonScherm(profiel);
                        }
                        else
                        {
                            MessageBox.Show("Kan MainForm niet vinden!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fout bij openen profiel: " + ex.Message);
                }
            }
        }

        private void btnBewerkenDieren_Click(object sender, EventArgs e)
        {
            // Controleer of er wel een rij geselecteerd is
            if (dgvDieren.SelectedRows.Count > 0)
            {
                // Pak het dier-object uit de geselecteerd rij
                Dier gekozenDier = (Dier)dgvDieren.SelectedRows[0].DataBoundItem;

                // Open het toevoegscherm in de bewerk-modus
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

                    // Verwijder op basis van het unieke Chipnummer
                    lijst.RemoveAll(d => d.Chipnummer == gekozenDier.Chipnummer);

                    DataManager.SlaDierenOp(lijst);
                    VerversGrid(); 
                }
            }
            else
            {
                MessageBox.Show("Selecteer eerst een dier om te verwijderen.");
            }
        }

        private void btnZoekenDieren_Click(object sender, EventArgs e)
        {
            string zoekTerm = txbZoekenDieren.Text.ToLower().Trim();

            // Lijst zoekbalk legen
            if (string.IsNullOrEmpty(zoekTerm))
            {
                VerversGrid();
                return;
            }

            // Haal de volledige lijst op
            List<Dier> volledigeLijst = DataManager.LaadDieren();

            // Filter de lijst op Naam OF Eigenaar 
            var gefilterdeLijst = volledigeLijst.Where(d =>
                (d.Naam != null && d.Naam.ToLower().Contains(zoekTerm)) ||
                (d.Eigenaar != null && d.Eigenaar.ToLower().Contains(zoekTerm))
            ).ToList();

            // Toon de gefilterde resultaten
            dgvDieren.DataSource = gefilterdeLijst;
        }

        private void txbZoekenDieren_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbZoekenDieren.Text))
            {
                VerversGrid();
            }
        }

        private void txbZoekenDieren_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnZoekenDieren_Click(this, new EventArgs()); // Voert de zoekknop-code uit
                e.SuppressKeyPress = true; // Stopt het Windows-geluidje
            }
        }
    }
}
