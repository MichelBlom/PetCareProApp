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
        public MainForm() // Constructor
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
            // Controleer of button actief is
            if (!(sender is Button actieveBtn)) return;

            // Reset knoppen in het navigatiepaneel
            foreach (Control c in pnlNavigation.Controls)
            {
                if (c is Button btn)
                {
                    btn.BackColor = Color.LightGray;
                    btn.ForeColor = Color.Black;
                }
            }

            // Stijl geklikte knop
            actieveBtn.BackColor = Color.White;
            actieveBtn.ForeColor = Color.RoyalBlue;

            // Hover kleur bij actieve knop
            //actieveBtn.FlatAppearance.MouseOverBackColor = Color.White;

            // Verplaats en toon de indicator
            pnlSelectionIndicator.Height = actieveBtn.Height; // Zorg dat de hoogte matcht
            pnlSelectionIndicator.Top = actieveBtn.Top;       // Zet hem op dezelfde hoogte
            pnlSelectionIndicator.Visible = true;
            pnlSelectionIndicator.BringToFront();             // Zorg dat hij bovenop ligt
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ActiveerMenuKnop(sender);
            ToonScherm(new ucDashboard());
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Dashboard scherm weergave bij starten applicatie
            ToonScherm(new ucDashboard());

            // Maakt Dashboard knop visueel actief
            ActiveerMenuKnop(btnDashboard);
        }

        private void btnDieren_Click(object sender, EventArgs e)
        {
            ActiveerMenuKnop(sender);
            ToonScherm(new ucDieren());
        }

        private void btnEigenaren_Click(object sender, EventArgs e)
        {
            ActiveerMenuKnop(sender);
            ToonScherm(new ucEigenaren());
        }

        private void btnKalender_Click(object sender, EventArgs e)
        {
            ActiveerMenuKnop(sender);
            ToonScherm(new ucKalender());
        }

        private void btnInstellingen_Click(object sender, EventArgs e)
        {
            ActiveerMenuKnop(sender);
            ToonScherm(new ucInstellingen());
        }
    }
}