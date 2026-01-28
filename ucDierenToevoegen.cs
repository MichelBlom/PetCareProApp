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
    public partial class ucDierenToevoegen : UserControl
    {
        private Dier dierOmTeBewerken = null;

        private bool kwamVanProfiel = false;

        private string geselecteerdFotoPad = "";

        
        public ucDierenToevoegen()
        {
            InitializeComponent();
        }

        private void btnAnnulerenDierToevoegen_Click(object sender, EventArgs e)
        {
            // Terug naar het overzicht
            if (this.ParentForm is MainForm mainForm)
            {
                if (kwamVanProfiel && dierOmTeBewerken != null)
                {
                    // Ga terug naar het profiel
                    ucProfielPaginaDieren profiel = new ucProfielPaginaDieren();
                    profiel.VulData(dierOmTeBewerken);
                    mainForm.ToonScherm(profiel);
                }
                else
                {
                    // Ga naar het overzicht (standaard)
                    mainForm.ToonScherm(new ucDieren());
                }
            }
        }

        private void lblSoortDierToevoegen_Click(object sender, EventArgs e)
        {

        }

        private void lblOpmerkingenDierToevoegen_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) // Button foto uploaden bij dier toevoegen!!!
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Afbeeldingen|*.jpg;*.jpeg;*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                geselecteerdFotoPad = ofd.FileName;
                pcbFotoDierToevoegen.ImageLocation = geselecteerdFotoPad;
            }
        }

        private void btnOpslaanDierToevoegen_Click(object sender, EventArgs e)
        {
            // 1. INPUT VALIDATIE (Verplichte velden)
            string foutmelding = "";
            if (string.IsNullOrWhiteSpace(txbNaamDierToevoegen.Text)) foutmelding += "- Naam\n";
            if (string.IsNullOrWhiteSpace(txbChipNrDierToevoegen.Text)) foutmelding += "- Chipnummer\n";
            if (string.IsNullOrWhiteSpace(cmbSoortDierToevoegen.Text)) foutmelding += "- Soort\n";
            // if (string.IsNullOrWhiteSpace(cmbVerblijfDierToevoegen.Text)) foutmelding += "- Verblijf\n";
            if (!rdbManDierToevoegen.Checked && !rdbVrouwDierToevoegen.Checked) foutmelding += "- Geslacht\n";

            if (!string.IsNullOrEmpty(foutmelding))
            {
                MessageBox.Show("De volgende velden zijn verplicht:\n\n" + foutmelding, "Gegevens incompleet", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Haal de lijst op voor de volgende checks
            List<Dier> lijst = DataManager.LaadDieren();

            // 1b. UNIEK CHIPNUMMER CHECK (Alleen bij nieuw dier)
            if (dierOmTeBewerken == null)
            {
                if (lijst.Any(d => d.Chipnummer == txbChipNrDierToevoegen.Text))
                {
                    MessageBox.Show("Dit chipnummer bestaat al in het systeem.", "Dubbel Chipnummer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // 2. DATA VOORBEREIDEN
            int leeftijd = (int)nmrLeeftijdDierToevoegen.Value;
            string gekozenGeslacht = rdbManDierToevoegen.Checked ? "Man" : "Vrouw";

            if (dierOmTeBewerken != null)
            {
                // BEWERKEN
                int index = lijst.FindIndex(d => d.Chipnummer == dierOmTeBewerken.Chipnummer);
                if (index != -1)
                {
                    dierOmTeBewerken.Naam = txbNaamDierToevoegen.Text;
                    dierOmTeBewerken.Eigenaar = cmbEigenaarDierToevoegen.Text;
                    dierOmTeBewerken.Leeftijd = leeftijd;
                    dierOmTeBewerken.Soort = cmbSoortDierToevoegen.Text;
                    dierOmTeBewerken.Ras = txbRasDierToevoegen.Text;
                    dierOmTeBewerken.Geslacht = gekozenGeslacht;
                    dierOmTeBewerken.Chipnummer = txbChipNrDierToevoegen.Text;
                    dierOmTeBewerken.Verblijf = cmbVerblijfDierToevoegen.Text;
                    dierOmTeBewerken.Opmerkingen = txbOpmerkingenDierToevoegen.Text;
                    lijst[index] = dierOmTeBewerken;
                }
            }
            else
            {
                // NIEUW
                dierOmTeBewerken = new Dier
                {
                    Naam = txbNaamDierToevoegen.Text,
                    Eigenaar = cmbEigenaarDierToevoegen.Text,
                    Leeftijd = leeftijd,
                    Soort = cmbSoortDierToevoegen.Text,
                    Ras = txbRasDierToevoegen.Text,
                    Geslacht = gekozenGeslacht,
                    Chipnummer = txbChipNrDierToevoegen.Text,
                    Verblijf = cmbVerblijfDierToevoegen.Text,
                    Opmerkingen = txbOpmerkingenDierToevoegen.Text
                };
                lijst.Add(dierOmTeBewerken);
            }

            // 3. OPSLAAN EN NAVIGEREN
            DataManager.SlaDierenOp(lijst);

            if (this.ParentForm is MainForm mainForm)
            {
                if (kwamVanProfiel)
                {
                    ucProfielPaginaDieren profielPagina = new ucProfielPaginaDieren();
                    profielPagina.VulData(dierOmTeBewerken);
                    mainForm.ToonScherm(profielPagina);
                }
                else
                {
                    mainForm.ToonScherm(new ucDieren());
                }
            }
        }
        public void LaadDierVoorBewerken(Dier dier, bool vanafProfiel = false)
        {
            dierOmTeBewerken = dier;
            kwamVanProfiel = vanafProfiel;

            // Verander de header
            lblHeaderDierenToevoegen.Text = "Dier bewerken";

            // Vul de combobox met vrije hokken + het hok waar hij nu al in zit
            cmbVerblijfDierToevoegen.DataSource = DataManager.KrijgBeschikbareHokken(dier.Verblijf);

            // Selecteer het huidige hok in de combobox. Als het leeg is, pakt hij automatisch de eerste: (Geen)
            if (!string.IsNullOrEmpty(dier.Verblijf) && cmbVerblijfDierToevoegen.Items.Contains(dier.Verblijf))
            {
                cmbVerblijfDierToevoegen.SelectedItem = dier.Verblijf;
            }
            else
            {
                cmbVerblijfDierToevoegen.SelectedIndex = 0; // Dit is (Geen)
            }

            cmbSoortDierToevoegen.SelectedItem = dier.Soort; // Selecteer de huidige soort in de combobox

            txbNaamDierToevoegen.Text = dier.Naam;
            cmbSoortDierToevoegen.Text = dier.Soort;
            nmrLeeftijdDierToevoegen.Value = dier.Leeftijd;
            txbRasDierToevoegen.Text = dier.Ras;
            txbChipNrDierToevoegen.Text = dier.Chipnummer;
            cmbEigenaarDierToevoegen.Text = dier.Eigenaar;
            txbOpmerkingenDierToevoegen.Text = dier.Opmerkingen;

            if (dier.Geslacht == "Man") rdbManDierToevoegen.Checked = true; else rdbVrouwDierToevoegen.Checked = true;

            // Toon de huidige foto
            if (!string.IsNullOrEmpty(dier.FotoBestandsnaam))
            {
                pcbFotoDierToevoegen.ImageLocation = DataManager.KrijgFotoPad(dier.FotoBestandsnaam);
            }
        }

        private void ucDierenToevoegen_Load(object sender, EventArgs e)
        {
            // Als we een nieuw dier toevoegen, zijn alle vrije hokken beschikbaar
            if (dierOmTeBewerken == null)
            {
                cmbVerblijfDierToevoegen.DataSource = DataManager.KrijgBeschikbareHokken();

                // Forceer de selectie op het eerste item ("(Geen)")
                if (cmbVerblijfDierToevoegen.Items.Count > 0)
                {
                    cmbVerblijfDierToevoegen.SelectedIndex = 0;
                }
            }
        }
    }
}
