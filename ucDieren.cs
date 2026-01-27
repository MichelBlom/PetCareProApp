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

        private void ucDieren_Load(object sender, EventArgs e)
        {
            DataManager.Initialiseer(); // Zorgt dat de mappen bestaan
            VerversGrid();
        }

        private void VerversGrid()
        {
            List<Dier> lijst = DataManager.LaadDieren();
            dgvDieren.AutoGenerateColumns = false;

            // Koppeling van kolommen aan eigenschappen van Dier
            ColumnNaam.DataPropertyName = "Naam";
            ColumnSoort.DataPropertyName = "Soort";
            ColumnLeeftijd.DataPropertyName = "Leeftijd";
            ColumnRas.DataPropertyName = "Ras";
            ColumnGeslacht.DataPropertyName = "Geslacht";
            ColumnChipnr.DataPropertyName = "Chipnummer";
            ColumnEigenaar.DataPropertyName = "Eigenaar";
            ColumnVerblijf.DataPropertyName = "Verblijf";

            dgvDieren.DataSource = lijst;
        }
    }
}
