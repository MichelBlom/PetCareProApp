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

        private void VulEigenaren()
        {
            var eigenaren = DataManager.LaadEigenaren();
            var namenLijst = eigenaren.Select(e => e.Naam).OrderBy(n => n).ToList();
            namenLijst.Insert(0, "- Selecteer eigenaar -");
            cmbEigenaarDierToevoegen.DataSource = namenLijst;
        }

        private void ucDierenToevoegen_Load(object sender, EventArgs e)
        {
            VulEigenaren();

            if (dierOmTeBewerken == null)
            {
                cmbVerblijfDierToevoegen.DataSource = DataManager.KrijgBeschikbareHokken();
                if (cmbVerblijfDierToevoegen.Items.Count > 0)
                {
                    cmbVerblijfDierToevoegen.SelectedIndex = 0;
                }
                cmbEigenaarDierToevoegen.SelectedIndex = 0;
            }
        }

        private void linkLabelEigenaarDierToevoegen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.ParentForm is MainForm mainForm)
            {
                // We maken het scherm aan
                ucEigenaarToevoegen eigenaarScherm = new ucEigenaarToevoegen();

                // We vertellen het scherm dat we van hier komen (zorg dat deze methode in ucEigenaarToevoegen staat!)
                eigenaarScherm.StelTerugkeerIn(true);

                // Navigeer via de speciale methode op MainForm
                mainForm.GaNaarEigenarenScherm(eigenaarScherm);
            }
        }

        public void LaadDierVoorBewerken(Dier dier, bool vanafProfiel = false)
        {
            dierOmTeBewerken = dier;
            kwamVanProfiel = vanafProfiel;
            VulEigenaren();

            lblHeaderDierenToevoegen.Text = "Dier bewerken";
            cmbVerblijfDierToevoegen.DataSource = DataManager.KrijgBeschikbareHokken(dier.Verblijf);

            if (!string.IsNullOrEmpty(dier.Verblijf) && cmbVerblijfDierToevoegen.Items.Contains(dier.Verblijf))
                cmbVerblijfDierToevoegen.SelectedItem = dier.Verblijf;
            else
                cmbVerblijfDierToevoegen.SelectedIndex = 0;

            cmbSoortDierToevoegen.SelectedItem = dier.Soort;
            txbNaamDierToevoegen.Text = dier.Naam;
            nmrLeeftijdDierToevoegen.Value = dier.Leeftijd;
            txbRasDierToevoegen.Text = dier.Ras;
            txbChipNrDierToevoegen.Text = dier.Chipnummer;
            txbOpmerkingenDierToevoegen.Text = dier.Opmerkingen;

            if (!string.IsNullOrEmpty(dier.Eigenaar) && cmbEigenaarDierToevoegen.Items.Contains(dier.Eigenaar))
                cmbEigenaarDierToevoegen.SelectedItem = dier.Eigenaar;

            if (dier.Geslacht == "Man") rdbManDierToevoegen.Checked = true; else rdbVrouwDierToevoegen.Checked = true;

            if (!string.IsNullOrEmpty(dier.FotoBestandsnaam))
            {
                pcbFotoDierToevoegen.ImageLocation = DataManager.KrijgFotoPad(dier.FotoBestandsnaam);
            }
        }

        private void btnOpslaanDierToevoegen_Click(object sender, EventArgs e)
        {
            string foutmelding = "";
            if (string.IsNullOrWhiteSpace(txbNaamDierToevoegen.Text)) foutmelding += "- Naam\n";
            if (string.IsNullOrWhiteSpace(txbChipNrDierToevoegen.Text)) foutmelding += "- Chipnummer\n";
            if (string.IsNullOrWhiteSpace(cmbSoortDierToevoegen.Text)) foutmelding += "- Soort\n";
            if (!rdbManDierToevoegen.Checked && !rdbVrouwDierToevoegen.Checked) foutmelding += "- Geslacht\n";

            if (!string.IsNullOrEmpty(foutmelding))
            {
                MessageBox.Show("De volgende velden zijn verplicht:\n\n" + foutmelding, "Gegevens incompleet", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<Dier> lijst = DataManager.LaadDieren();
            if (dierOmTeBewerken == null && lijst.Any(d => d.Chipnummer == txbChipNrDierToevoegen.Text))
            {
                MessageBox.Show("Dit chipnummer bestaat al in het systeem.", "Dubbel Chipnummer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string gekozenEigenaar = cmbEigenaarDierToevoegen.Text;
            if (cmbEigenaarDierToevoegen.SelectedIndex == 0) gekozenEigenaar = "";

            if (dierOmTeBewerken != null)
            {
                int index = lijst.FindIndex(d => d.Chipnummer == dierOmTeBewerken.Chipnummer);
                if (index != -1)
                {
                    dierOmTeBewerken.Naam = txbNaamDierToevoegen.Text;
                    dierOmTeBewerken.Eigenaar = gekozenEigenaar;
                    dierOmTeBewerken.Leeftijd = (int)nmrLeeftijdDierToevoegen.Value;
                    dierOmTeBewerken.Soort = cmbSoortDierToevoegen.Text;
                    dierOmTeBewerken.Ras = txbRasDierToevoegen.Text;
                    dierOmTeBewerken.Geslacht = rdbManDierToevoegen.Checked ? "Man" : "Vrouw";
                    dierOmTeBewerken.Chipnummer = txbChipNrDierToevoegen.Text;
                    dierOmTeBewerken.Verblijf = cmbVerblijfDierToevoegen.Text;
                    dierOmTeBewerken.Opmerkingen = txbOpmerkingenDierToevoegen.Text;
                    lijst[index] = dierOmTeBewerken;
                }
            }
            else
            {
                dierOmTeBewerken = new Dier
                {
                    Naam = txbNaamDierToevoegen.Text,
                    Eigenaar = gekozenEigenaar,
                    Leeftijd = (int)nmrLeeftijdDierToevoegen.Value,
                    Soort = cmbSoortDierToevoegen.Text,
                    Ras = txbRasDierToevoegen.Text,
                    Geslacht = rdbManDierToevoegen.Checked ? "Man" : "Vrouw",
                    Chipnummer = txbChipNrDierToevoegen.Text,
                    Verblijf = cmbVerblijfDierToevoegen.Text,
                    Opmerkingen = txbOpmerkingenDierToevoegen.Text
                };
                lijst.Add(dierOmTeBewerken);
            }

            DataManager.SlaDierenOp(lijst);

            if (this.ParentForm is MainForm mainForm)
            {
                if (kwamVanProfiel)
                {
                    ucProfielPaginaDieren profielPagina = new ucProfielPaginaDieren();
                    profielPagina.VulData(dierOmTeBewerken);
                    mainForm.ToonScherm(profielPagina);
                }
                else mainForm.ToonScherm(new ucDieren());
            }
        }

        private void btnAnnulerenDierToevoegen_Click(object sender, EventArgs e)
        {
            if (this.ParentForm is MainForm mainForm)
            {
                if (kwamVanProfiel && dierOmTeBewerken != null)
                {
                    ucProfielPaginaDieren profiel = new ucProfielPaginaDieren();
                    profiel.VulData(dierOmTeBewerken);
                    mainForm.ToonScherm(profiel);
                }
                else mainForm.ToonScherm(new ucDieren());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Afbeeldingen|*.jpg;*.jpeg;*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                geselecteerdFotoPad = ofd.FileName;
                pcbFotoDierToevoegen.ImageLocation = geselecteerdFotoPad;
            }
        }

        private void lblSoortDierToevoegen_Click(object sender, EventArgs e) { }

        private void lblOpmerkingenDierToevoegen_Click(object sender, EventArgs e) { }
    }
}
