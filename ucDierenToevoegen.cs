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
            // Haal de bestaande lijst op
            List<Dier> lijst = DataManager.LaadDieren();
            Dier dier;

            if (dierOmTeBewerken == null)
            {
                // Maak een nieuw object en voeg toe aan de lijst
                dier = new Dier();
                lijst.Add(dier);
            }
            else
            {
                // BEWERKEN: Zoek het bestaande dier in de lijst op basis van Chipnummer
                dier = lijst.FirstOrDefault(d => d.Chipnummer == dierOmTeBewerken.Chipnummer);

                // Extra veiligheid: mocht chipnummer gewijzigd zijn of niet gevonden, zoek op naam
                if (dier == null)
                {
                    dier = lijst.FirstOrDefault(d => d.Naam == dierOmTeBewerken.Naam);
                }
            }

            
            if (dier != null)
            {
                dier.Naam = txbNaamDierToevoegen.Text;
                dier.Soort = cmbSoortDierToevoegen.Text;
                dier.Ras = txbRasDierToevoegen.Text;
                dier.Leeftijd = (int)nmrLeeftijdDierToevoegen.Value;
                dier.Chipnummer = txbChipNrDierToevoegen.Text;
                dier.Eigenaar = cmbEigenaarDierToevoegen.Text;
                dier.Verblijf = cmbVerblijfDierToevoegen.Text;
                dier.Opmerkingen = txbOpmerkingenDierToevoegen.Text;
                dier.Geslacht = rdbManDierToevoegen.Checked ? "Man" : "Vrouw";

                // Foto verwerken 
                if (!string.IsNullOrEmpty(geselecteerdFotoPad))
                {
                    dier.FotoBestandsnaam = DataManager.KopieerFoto(geselecteerdFotoPad);
                }

                // De hele lijst weer opslaan in de JSON
                DataManager.SlaDierenOp(lijst);
            }

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
                    
                    mainForm.ToonScherm(new ucDieren());
                }
            }
        }
        public void LaadDierVoorBewerken(Dier dier, bool vanafProfiel = false)
        {
            dierOmTeBewerken = dier;

            kwamVanProfiel = vanafProfiel; // Hier onthouden we de herkomst

            // Verander de header
            lblHeaderDierenToevoegen.Text = "Dier bewerken";
            
            txbNaamDierToevoegen.Text = dier.Naam;
            cmbSoortDierToevoegen.Text = dier.Soort;
            nmrLeeftijdDierToevoegen.Value = dier.Leeftijd;
            txbRasDierToevoegen.Text = dier.Ras;
            txbChipNrDierToevoegen.Text = dier.Chipnummer;
            cmbEigenaarDierToevoegen.Text = dier.Eigenaar;
            cmbVerblijfDierToevoegen.Text = dier.Verblijf;
            txbOpmerkingenDierToevoegen.Text = dier.Opmerkingen;

            if (dier.Geslacht == "Man") rdbManDierToevoegen.Checked = true; else rdbVrouwDierToevoegen.Checked = true;

            // Toon de huidige foto
            if (!string.IsNullOrEmpty(dier.FotoBestandsnaam))
            {
                pcbFotoDierToevoegen.ImageLocation = DataManager.KrijgFotoPad(dier.FotoBestandsnaam);
            }
        }
    }
}
