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
    }
}
