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

        /// <summary>
        /// Deze methode zorgt ervoor dat de navigatie naar de Eigenaren-sectie 
        /// correct wordt afgehandeld, inclusief de visuele indicator.
        /// </summary>
        public void GaNaarEigenarenScherm(UserControl specifiekScherm = null)
        {
            // 1. Maak de Eigenaren-knop visueel actief
            ActiveerMenuKnop(btnEigenaren);

            // 2. Toon het gevraagde scherm (bijv. toevoegen) of het standaard overzicht
            if (specifiekScherm != null)
            {
                ToonScherm(specifiekScherm);
            }
            else
            {
                ToonScherm(new ucEigenaren());
            }
        }

        // NIEUW: Hiermee kunnen we de indicator verplaatsen op basis van de knopnaam
        public void ActiveerMenuKnopInCode(string knopNaam)
        {
            Control[] controls = pnlNavigation.Controls.Find(knopNaam, true);
            if (controls.Length > 0 && controls[0] is Button btn)
            {
                ActiveerMenuKnop(btn);
            }
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

            // Verplaats en toon de indicator
            pnlSelectionIndicator.Height = actieveBtn.Height;
            pnlSelectionIndicator.Top = actieveBtn.Top;
            pnlSelectionIndicator.Visible = true;
            pnlSelectionIndicator.BringToFront();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ActiveerMenuKnop(sender);
            ToonScherm(new ucDashboard());
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ToonScherm(new ucDashboard());
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