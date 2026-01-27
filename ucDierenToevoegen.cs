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
    }
}
