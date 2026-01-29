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
    public partial class ucProfielPaginaDieren : UserControl
    {
        private Dier huidigDier = null;
        private string _bronScherm = "DierenLijst";

        public ucProfielPaginaDieren()
        {
            InitializeComponent();
        }

        public void VulData(Dier dier, string bron = "DierenLijst")
        {
            huidigDier = dier;
            _bronScherm = bron;

            lblHeaderProfielDieren.Text = "Profiel van " + dier.Naam;
            lblNaamOutputProfielDieren.Text = dier.Naam;
            lblEigenaarOutputProfielDieren.Text = dier.Eigenaar;
            lblOutputOpmerkingenProfielDieren.Text = dier.Opmerkingen;
            lblLeeftijdOutputProfielDieren.Text = dier.Leeftijd.ToString();
            lblSoortOutputProfielDieren.Text = dier.Soort;
            lblRasOutputProfielDieren.Text = dier.Ras;
            lblGeslachtOutputProfielDieren.Text = dier.Geslacht;
            lblChipNrOutputProfielDieren.Text = dier.Chipnummer;
            lblVerblijfOutputProfielDieren.Text = dier.Verblijf;

            string fotoPad = DataManager.KrijgFotoPad(dier.FotoBestandsnaam);
            if (System.IO.File.Exists(fotoPad))
            {
                pcbFotoProfielDieren.ImageLocation = fotoPad;
            }
        }

        private void btnTerugProfielDieren_Click(object sender, EventArgs e)
        {
            if (this.ParentForm is MainForm mainForm)
            {
                // ROUTE A: Terug naar het specifieke Eigenaar Profiel
                if (_bronScherm == "ProfielEigenaar" && huidigDier != null)
                {
                    var eigenaar = DataManager.LaadEigenaren().FirstOrDefault(x => x.Naam == huidigDier.Eigenaar);
                    if (eigenaar != null)
                    {
                        mainForm.ActiveerMenuKnopInCode("btnEigenaren");
                        ucProfielEigenaar profiel = new ucProfielEigenaar();
                        profiel.VulData(eigenaar, "Overzicht");
                        mainForm.ToonScherm(profiel);
                    }
                }
                // ROUTE B: Terug naar Eigenaren Overzicht (via de tabel)
                else if (_bronScherm == "EigenarenOverzicht")
                {
                    mainForm.ActiveerMenuKnopInCode("btnEigenaren");
                    mainForm.ToonScherm(new ucEigenaren());
                }
                // ROUTE C: Standaard terug naar de Dierenlijst
                else
                {
                    mainForm.ActiveerMenuKnopInCode("btnDieren");
                    mainForm.ToonScherm(new ucDieren());
                }
            }
        }

        // Deze methode laten staan voor de Designer koppeling
        private void lblEigenaarDierProfiel_Click(object sender, EventArgs e)
        {
            if (huidigDier != null && !string.IsNullOrEmpty(huidigDier.Eigenaar))
            {
                var eigenaar = DataManager.LaadEigenaren().FirstOrDefault(eig => eig.Naam == huidigDier.Eigenaar);
                if (eigenaar != null && this.ParentForm is MainForm mainForm)
                {
                    mainForm.ActiveerMenuKnopInCode("btnEigenaren");
                    ucProfielEigenaar profielEigenaar = new ucProfielEigenaar();
                    profielEigenaar.VulData(eigenaar, "DierenLijst");
                    mainForm.ToonScherm(profielEigenaar);
                }
            }
        }

        private void btnBewerkenProfielDieren_Click(object sender, EventArgs e)
        {
            if (huidigDier != null && this.ParentForm is MainForm mainForm)
            {
                ucDierenToevoegen bewerkScherm = new ucDierenToevoegen();
                bewerkScherm.LaadDierVoorBewerken(huidigDier, true);
                mainForm.ToonScherm(bewerkScherm);
            }
        }

        private void btnVerwijderenProfielDieren_Click(object sender, EventArgs e)
        {
            if (huidigDier != null)
            {
                var resultaat = MessageBox.Show($"Weet je zeker dat je {huidigDier.Naam} wilt verwijderen?",
                                                "Dier verwijderen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (resultaat == DialogResult.Yes)
                {
                    List<Dier> lijst = DataManager.LaadDieren();
                    lijst.RemoveAll(d => d.Chipnummer == huidigDier.Chipnummer);
                    DataManager.SlaDierenOp(lijst);

                    if (this.ParentForm is MainForm mainForm)
                    {
                        mainForm.ToonScherm(new ucDieren());
                    }
                }
            }
        }
    }
}
