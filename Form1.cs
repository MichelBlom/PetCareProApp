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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public void ToonScherm(UserControl scherm)
        {
            pnlMain.Controls.Clear(); // Maak het hoofdvak leeg
            scherm.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(scherm);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ActiveerMenuKnop(object sender)
        {
            // Reset alle knoppen naar de standaard 'niet-actief' stijl
            foreach (Control c in pnlNavigation.Controls)
            {
                if (c is Button btn)
                {
                    btn.BackColor = Color.LightGray; 
                    btn.ForeColor = Color.Black;   
                }
            }

            // 2. Stijl de geklikte knop
            Button actieveBtn = (Button)sender;
            actieveBtn.BackColor = Color.White;  
            actieveBtn.ForeColor = Color.RoyalBlue;  
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ActiveerMenuKnop(sender);
            ToonScherm(new ucDashboard());
            //pnlSelectionIndicator.Top = actieveBtn.Top;
            pnlSelectionIndicator.Visible = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // 1. Zorg dat het Dashboard scherm direct getoond wordt
            ToonScherm(new ucDashboard());

            // 2. Maak de Dashboard knop visueel actief
            ActiveerMenuKnop(btnDashboard);
        }

        private void btnDieren_Click(object sender, EventArgs e)
        {
            ActiveerMenuKnop(sender);
            ToonScherm(new ucDieren());
            //pnlSelectionIndicator.Top = actieveBtn.Top;
            pnlSelectionIndicator.Visible = true;
        }

        private void btnEigenaren_Click(object sender, EventArgs e)
        {
            ActiveerMenuKnop(sender);
            ToonScherm(new ucEigenaren());
            //pnlSelectionIndicator.Top = actieveBtn.Top;
            pnlSelectionIndicator.Visible = true;
        }

        private void btnKalender_Click(object sender, EventArgs e)
        {
            ActiveerMenuKnop(sender);
            ToonScherm(new ucKalender());
            //pnlSelectionIndicator.Top = actieveBtn.Top;
            pnlSelectionIndicator.Visible = true;
        }

        private void btnInstellingen_Click(object sender, EventArgs e)
        {
            ActiveerMenuKnop(sender);
            ToonScherm(new ucInstellingen());
            //pnlSelectionIndicator.Top = actieveBtn.Top;
            pnlSelectionIndicator.Visible = true;
        }
    }
}