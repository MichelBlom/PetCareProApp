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
        public ucProfielPaginaDieren()
        {
            InitializeComponent();
        }


        public void VulData(Dier dier)
        {
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
            if (File.Exists(fotoPad))
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
    }
}
