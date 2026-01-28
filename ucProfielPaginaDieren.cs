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

        public ucProfielPaginaDieren()
        {
            InitializeComponent();
        }


        public void VulData(Dier dier)
        {
            // Sla het object op
            huidigDier = dier;

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
                mainForm.ToonScherm(new ucDieren());
            }
        }

        private void lblEigenaarDierProfiel_Click(object sender, EventArgs e)
        {

        }

        private void btnBewerkenProfielDieren_Click(object sender, EventArgs e)
        {
            if (huidigDier != null && this.ParentForm is MainForm mainForm)
            {
                ucDierenToevoegen bewerkScherm = new ucDierenToevoegen();

                // We geven 'true' mee zodat het scherm weet dat we van het profiel komen
                bewerkScherm.LaadDierVoorBewerken(huidigDier, true);

                mainForm.ToonScherm(bewerkScherm);
            }
        }

        private void btnVerwijderenProfielDieren_Click(object sender, EventArgs e)
        {
            if (huidigDier != null)
            {
                // Vraag om bevestiging
                var resultaat = MessageBox.Show($"Weet je zeker dat je {huidigDier.Naam} wilt verwijderen?",
                                                "Dier verwijderen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (resultaat == DialogResult.Yes)
                {
                    // Laad de huidige lijst
                    List<Dier> lijst = DataManager.LaadDieren();

                    // Verwijder het dier (op uniek Chipnummer)
                    lijst.RemoveAll(d => d.Chipnummer == huidigDier.Chipnummer);

                    // Sla de bijgewerkte lijst op
                    DataManager.SlaDierenOp(lijst);

                    // Ga terug naar het overzicht 
                    if (this.ParentForm is MainForm mainForm)
                    {
                        mainForm.ToonScherm(new ucDieren());
                    }
                }
            }
        }
    }
}
