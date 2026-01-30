using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PetCareProApp
{
    public partial class ucDierenToevoegen : UserControl
    {
        private Dier dierOmTeBewerken = null;
        private bool kwamVanProfiel = false;
        private string geselecteerdFotoPad = "";
        private string _bronEigenaarNaam = "";

        public ucDierenToevoegen()
        {
            InitializeComponent();

            // Zet de minimale datum op vandaag voor beide pickers
            dtpIcheckenToevoegenDieren.MinDate = DateTime.Today;
            dtpUitcheckenToevoegenDieren.MinDate = DateTime.Today;
        }

        public void PrepareerVoorNieuwDierVanafEigenaar(string eigenaarNaam)
        {
            _bronEigenaarNaam = eigenaarNaam;
            kwamVanProfiel = true;

            VulEigenaren();

            if (cmbEigenaarDierToevoegen.Items.Contains(eigenaarNaam))
            {
                cmbEigenaarDierToevoegen.SelectedItem = eigenaarNaam;
            }
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
            if (string.IsNullOrEmpty(_bronEigenaarNaam))
            {
                VulEigenaren();
            }

            if (dierOmTeBewerken == null)
            {
                cmbVerblijfDierToevoegen.DataSource = DataManager.KrijgBeschikbareHokken();
                if (cmbVerblijfDierToevoegen.Items.Count > 0)
                {
                    cmbVerblijfDierToevoegen.SelectedIndex = 0;
                }

                if (string.IsNullOrEmpty(_bronEigenaarNaam))
                {
                    cmbEigenaarDierToevoegen.SelectedIndex = 0;
                }
            }
        }

        public void LaadDierVoorBewerken(Dier dier, bool vanafProfiel = false)
        {
            dierOmTeBewerken = dier;
            kwamVanProfiel = vanafProfiel;
            _bronEigenaarNaam = dier.Eigenaar;

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

            if (!string.IsNullOrEmpty(foutmelding))
            {
                MessageBox.Show("Velden verplicht:\n" + foutmelding);
                return;
            }

            List<Dier> lijst = DataManager.LaadDieren();
            string gekozenEigenaar = cmbEigenaarDierToevoegen.SelectedIndex == 0 ? "" : cmbEigenaarDierToevoegen.Text;

            // Foto logica behouden
            string fotoBestandsnaam = (dierOmTeBewerken != null) ? dierOmTeBewerken.FotoBestandsnaam : "";
            if (!string.IsNullOrEmpty(geselecteerdFotoPad))
            {
                string extensie = Path.GetExtension(geselecteerdFotoPad);
                fotoBestandsnaam = txbChipNrDierToevoegen.Text + extensie;
                string doelPad = DataManager.KrijgFotoPad(fotoBestandsnaam);
                try
                {
                    string map = Path.GetDirectoryName(doelPad);
                    if (!Directory.Exists(map)) Directory.CreateDirectory(map);
                    File.Copy(geselecteerdFotoPad, doelPad, true);
                }
                catch (Exception ex) { MessageBox.Show("Fout bij opslaan foto: " + ex.Message); }
            }

            bool wasBewerking = (dierOmTeBewerken != null);

            if (wasBewerking)
            {
                int index = lijst.FindIndex(d => d.Chipnummer == dierOmTeBewerken.Chipnummer);
                if (index != -1)
                {
                    UpdateDierVelden(dierOmTeBewerken, gekozenEigenaar);
                    dierOmTeBewerken.FotoBestandsnaam = fotoBestandsnaam;
                    lijst[index] = dierOmTeBewerken;
                }
            }
            else
            {
                dierOmTeBewerken = new Dier();
                UpdateDierVelden(dierOmTeBewerken, gekozenEigenaar);
                dierOmTeBewerken.FotoBestandsnaam = fotoBestandsnaam;
                lijst.Add(dierOmTeBewerken);
            }

            DataManager.SlaDierenOp(lijst);

            // NAVIGATIE LOGICA
            if (this.ParentForm is MainForm mainForm)
            {
                if (wasBewerking)
                {
                    // Altijd terug naar het dierprofiel na een bewerking
                    ucProfielPaginaDieren dierProfiel = new ucProfielPaginaDieren();
                    string bronVoorTerugknop = kwamVanProfiel ? "ProfielEigenaar" : "Overzicht";
                    dierProfiel.VulData(dierOmTeBewerken, bronVoorTerugknop);
                    mainForm.ToonScherm(dierProfiel);
                }
                else if (kwamVanProfiel && !string.IsNullOrEmpty(gekozenEigenaar))
                {
                    // Nieuw dier vanaf eigenaar -> Terug naar eigenaar
                    var eigenaar = DataManager.LaadEigenaren().FirstOrDefault(x => x.Naam == gekozenEigenaar);
                    if (eigenaar != null)
                    {
                        ucProfielEigenaar profiel = new ucProfielEigenaar();
                        profiel.VulData(eigenaar);
                        mainForm.ToonScherm(profiel);
                    }
                    else mainForm.ToonScherm(new ucDieren());
                }
                else
                {
                    mainForm.ToonScherm(new ucDieren());
                }
            }
        }

        private void UpdateDierVelden(Dier d, string eigenaar)
        {
            d.Naam = txbNaamDierToevoegen.Text;
            d.Eigenaar = eigenaar;
            d.Leeftijd = (int)nmrLeeftijdDierToevoegen.Value;
            d.Soort = cmbSoortDierToevoegen.Text;
            d.Ras = txbRasDierToevoegen.Text;
            d.Geslacht = rdbManDierToevoegen.Checked ? "Man" : "Vrouw";
            d.Chipnummer = txbChipNrDierToevoegen.Text;
            d.Verblijf = cmbVerblijfDierToevoegen.Text;
            d.Opmerkingen = txbOpmerkingenDierToevoegen.Text;
        }

        private void btnAnnulerenDierToevoegen_Click(object sender, EventArgs e)
        {
            if (this.ParentForm is MainForm mainForm)
            {
                if (dierOmTeBewerken != null)
                {
                    ucProfielPaginaDieren dierProfiel = new ucProfielPaginaDieren();
                    dierProfiel.VulData(dierOmTeBewerken, kwamVanProfiel ? "ProfielEigenaar" : "Overzicht");
                    mainForm.ToonScherm(dierProfiel);
                }
                else if (kwamVanProfiel)
                {
                    var eigenaar = DataManager.LaadEigenaren().FirstOrDefault(x => x.Naam == _bronEigenaarNaam);
                    if (eigenaar != null)
                    {
                        ucProfielEigenaar profiel = new ucProfielEigenaar();
                        profiel.VulData(eigenaar);
                        mainForm.ToonScherm(profiel);
                    }
                    else mainForm.ToonScherm(new ucDieren());
                }
                else mainForm.ToonScherm(new ucDieren());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog { Filter = "Afbeeldingen|*.jpg;*.jpeg;*.png" };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                geselecteerdFotoPad = ofd.FileName;
                pcbFotoDierToevoegen.ImageLocation = geselecteerdFotoPad;
            }
        }

        private void linkLabelEigenaarDierToevoegen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.ParentForm is MainForm mainForm)
            {
                ucEigenaarToevoegen eigenaarScherm = new ucEigenaarToevoegen();
                eigenaarScherm.StelTerugkeerIn(true);
                mainForm.GaNaarEigenarenScherm(eigenaarScherm);
            }
        }

        private void lblSoortDierToevoegen_Click(object sender, EventArgs e) { }
        private void lblOpmerkingenDierToevoegen_Click(object sender, EventArgs e) { }

        private void pnlLeftDierenToevoegen_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}


