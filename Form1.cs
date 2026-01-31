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
            pnlMain.Controls.Clear();
            scherm.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(scherm);

            // AUTOMATISCHE MENU ACTIVATIE op basis van de schermnaam
            string typeNaam = scherm.GetType().Name;

            if (typeNaam.Contains("Dier"))
            {
                // Activeert btnDieren voor: ucDieren, ucDierenToevoegen, ucProfielPaginaDieren
                ActiveerMenuKnopInCode("btnDieren");
            }
            else if (typeNaam.Contains("Eigen"))
            {
                // Activeert btnEigenaren voor: ucEigenaren, ucEigenaarToevoegen, ucProfielEigenaar
                ActiveerMenuKnopInCode("btnEigenaren");
            }
            else if (typeNaam.Contains("Kalender") || typeNaam.Contains("Planning"))
            {
                ActiveerMenuKnopInCode("btnKalender");
            }
            else if (typeNaam.Contains("Dashboard"))
            {
                ActiveerMenuKnopInCode("btnDashboard");
            }
            else if (typeNaam.Contains("Instellingen"))
            {
                ActiveerMenuKnopInCode("btnInstellingen");
            }
        }

        public void GaNaarEigenarenScherm(UserControl specifiekScherm = null)
        {
            if (specifiekScherm != null) ToonScherm(specifiekScherm);
            else ToonScherm(new ucEigenaren());
        }

        public void ActiveerMenuKnopInCode(string knopNaam)
        {
            Control[] controls = pnlNavigation.Controls.Find(knopNaam, true);
            if (controls.Length > 0 && controls[0] is Button btn)
            {
                ActiveerMenuKnop(btn);
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => Application.Exit();

        private void ActiveerMenuKnop(object sender)
        {
            if (!(sender is Button actieveBtn)) return;

            foreach (Control c in pnlNavigation.Controls)
            {
                if (c is Button btn)
                {
                    btn.BackColor = Color.LightGray;
                    btn.ForeColor = Color.Black;
                }
            }

            actieveBtn.BackColor = Color.White;
            actieveBtn.ForeColor = Color.RoyalBlue;

            pnlSelectionIndicator.Height = actieveBtn.Height;
            pnlSelectionIndicator.Top = actieveBtn.Top;
            pnlSelectionIndicator.Visible = true;
            pnlSelectionIndicator.BringToFront();
        }

        private void btnDashboard_Click(object sender, EventArgs e) => ToonScherm(new ucDashboard());
        private void MainForm_Load(object sender, EventArgs e) => ToonScherm(new ucDashboard());
        private void btnDieren_Click(object sender, EventArgs e) => ToonScherm(new ucDieren());
        private void btnEigenaren_Click(object sender, EventArgs e) => ToonScherm(new ucEigenaren());
        private void btnKalender_Click(object sender, EventArgs e) => ToonScherm(new ucKalender());
        private void btnInstellingen_Click(object sender, EventArgs e) => ToonScherm(new ucInstellingen());
    }
}