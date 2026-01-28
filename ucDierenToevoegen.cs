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

        private string geselecteerdFotoPad = "";

        private string tijdelijkFotoPad = "";
        public ucDierenToevoegen()
        {
            InitializeComponent();
        }

        private void btnAnnulerenDierToevoegen_Click(object sender, EventArgs e)
        {
            // Terug naar het overzicht
            if (this.ParentForm is MainForm mainForm)
            {
                mainForm.ToonScherm(new ucDieren());
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
            // Maak het object aan
            Dier nieuwDier = new Dier();
            nieuwDier.Naam = txbNaamDierToevoegen.Text;
            nieuwDier.Soort = cmbSoortDierToevoegen.Text;
            nieuwDier.Ras = txbRasDierToevoegen.Text;
            nieuwDier.Leeftijd = (int)nmrLeeftijdDierToevoegen.Value;
            nieuwDier.Chipnummer = txbChipNrDierToevoegen.Text;
            nieuwDier.Eigenaar = cmbEigenaarDierToevoegen.Text;
            nieuwDier.Verblijf = cmbVerblijfDierToevoegen.Text;
            nieuwDier.Opmerkingen = txbOpmerkingenDierToevoegen.Text;
            nieuwDier.Geslacht = rdbManDierToevoegen.Checked ? "Man" : "Vrouw";
            

            // Verwerk de foto (kopieer naar de interne map)
            if (!string.IsNullOrEmpty(geselecteerdFotoPad))
            {
                nieuwDier.FotoBestandsnaam = DataManager.KopieerFoto(geselecteerdFotoPad);
            }

            // Toevoegen aan de lijst en opslaan
            List<Dier> lijst = DataManager.LaadDieren();
            lijst.Add(nieuwDier);
            DataManager.SlaDierenOp(lijst);

            // Ga terug naar het overzicht
            MainForm parent = (MainForm)this.ParentForm;
            parent.ToonScherm(new ucDieren());

            List<Dier> lijst = DataManager.LaadDieren();
            Dier dier;

            if (dierOmTeBewerken == null)
            {
                // Nieuw dier
                dier = new Dier();
                lijst.Add(dier);
            }
            else
            {
                // Zoek het bestaande dier in de lijst op basis van bijvoorbeeld Chipnummer of Naam
                dier = lijst.FirstOrDefault(d => d.Chipnummer == dierOmTeBewerken.Chipnummer);
            }

            // Vul/Update de gegevens
            dier.Naam = txbNaamDierToevoegen.Text;
            dier.Geslacht = rdbManDierToevoegen.Checked ? "Man" : "Vrouw";
            dier.Ras = txbRasDierToevoegen.Text;
            dier.Leeftijd = (int)nmrLeeftijdDierToevoegen.Value;
            dier.Chipnummer = txbChipNrDierToevoegen.Text;
            dier.Eigenaar = cmbEigenaarDierToevoegen.Text;
            dier.Verblijf = cmbVerblijfDierToevoegen.Text;
            dier.Opmerkingen = txbOpmerkingenDierToevoegen.Text;
            // ... vul alle andere velden in zoals je al deed ...

            if (!string.IsNullOrEmpty(tijdelijkFotoPad))
            {
                dier.FotoBestandsnaam = DataManager.KopieerFoto(tijdelijkFotoPad);
            }

            DataManager.SlaDierenOp(lijst);
            ((MainForm)this.ParentForm).ToonScherm(new ucDieren());
        }

        public void LaadDierVoorBewerken(Dier dier)
        {
            dierOmTeBewerken = dier;

            // Verander de header (zorg dat lblHeader de naam is van je label bovenaan)
            lblHeaderDierenToevoegen.Text = "Dier bewerken";

            // Vul de velden
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
