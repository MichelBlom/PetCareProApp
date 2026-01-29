using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace PetCareProApp
{
    public partial class ucProfielEigenaar : UserControl
    {
        private Eigenaar _huidigeEigenaar;
        private string _bronScherm = "Overzicht";

        public ucProfielEigenaar()
        {
            InitializeComponent();
        }

        public void VulData(Eigenaar eigenaar, string bron = "Overzicht")
        {
            _huidigeEigenaar = eigenaar;
            _bronScherm = bron;

            // Linkerkolom: Info
            lblHeaderProfielEigenaar.Text = $"Profiel van {eigenaar.Naam}";
            lblNaamProfielEigenaar.Text = eigenaar.Naam;
            lblWoonplaatsProfielEigenaar.Text = eigenaar.Woonplaats;
            lblPostcodeProfielEigenaar.Text = eigenaar.Postcode;
            lblStraatProfielEigenaar.Text = $"{eigenaar.Straat} {eigenaar.Huisnummer}";
            lblEmailProfielEigenaar.Text = eigenaar.Email;
            lblOpmerkingenProfielEigenaar.Text = eigenaar.Opmerkingen;

            HerlaadDierenLijst();
        }

        private void HerlaadDierenLijst()
        {
            flpDierenProfielEigenaar.Controls.Clear();

            var alleDieren = DataManager.LaadDieren();
            var eigenDieren = alleDieren.Where(d => d.Eigenaar == _huidigeEigenaar.Naam).ToList();

            if (!eigenDieren.Any())
            {
                Label lblLeeg = new Label
                {
                    Text = "Geen huisdieren gevonden.",
                    AutoSize = true,
                    ForeColor = Color.Gray,
                    Padding = new Padding(10)
                };
                flpDierenProfielEigenaar.Controls.Add(lblLeeg);
                return;
            }

            foreach (var dier in eigenDieren)
            {
                Panel pnlDierCard = new Panel
                {
                    Size = new Size(130, 150),
                    BackColor = Color.White,
                    Margin = new Padding(10),
                    Cursor = Cursors.Hand
                };

                PictureBox pcbDier = new PictureBox
                {
                    Size = new Size(130, 110),
                    Location = new Point(0, 0),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BorderStyle = BorderStyle.None
                };

                string fotoPad = DataManager.KrijgFotoPad(dier.FotoBestandsnaam);
                if (File.Exists(fotoPad))
                {
                    pcbDier.ImageLocation = fotoPad;
                }
                else
                {
                    pcbDier.BackColor = Color.LightGray;
                }

                Label lblNaam = new Label
                {
                    Text = dier.Naam,
                    Size = new Size(130, 40),
                    Location = new Point(0, 110),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    BackColor = Color.FromArgb(240, 240, 240)
                };

                // NAVIGATIE LOGICA AANGEPAST
                EventHandler gaNaarDier = (s, e) =>
                {
                    if (this.ParentForm is MainForm mainForm)
                    {
                        mainForm.ActiveerMenuKnopInCode("btnDieren");
                        ucProfielPaginaDieren dierProfiel = new ucProfielPaginaDieren();

                        // HIER ZAT DE FOUT: We geven nu "ProfielEigenaar" mee
                        dierProfiel.VulData(dier, "ProfielEigenaar");

                        mainForm.ToonScherm(dierProfiel);
                    }
                };

                pnlDierCard.Click += gaNaarDier;
                pcbDier.Click += gaNaarDier;
                lblNaam.Click += gaNaarDier;

                pnlDierCard.Controls.Add(pcbDier);
                pnlDierCard.Controls.Add(lblNaam);
                flpDierenProfielEigenaar.Controls.Add(pnlDierCard);
            }
        }

        private void btnTerugProfielEigenaar_Click(object sender, EventArgs e)
        {
            if (this.ParentForm is MainForm mainForm)
            {
                if (_bronScherm == "DierenLijst")
                {
                    mainForm.ActiveerMenuKnopInCode("btnDieren");
                    mainForm.ToonScherm(new ucDieren());
                }
                else
                {
                    mainForm.ActiveerMenuKnopInCode("btnEigenaren");
                    mainForm.ToonScherm(new ucEigenaren());
                }
            }
        }

        private void btnBewerkenProfielEigenaar_Click(object sender, EventArgs e)
        {
            if (this.ParentForm is MainForm mainForm && _huidigeEigenaar != null)
            {
                mainForm.ToonScherm(new ucEigenaarToevoegen(_huidigeEigenaar, true));
            }
        }

        private void btnVerwijderenProfielEigenaar_Click(object sender, EventArgs e)
        {
            if (_huidigeEigenaar == null) return;

            if (MessageBox.Show($"Weet je zeker dat je {_huidigeEigenaar.Naam} wilt verwijderen?",
                "Bevestig", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var lijst = DataManager.LaadEigenaren();
                lijst.RemoveAll(x => x.Naam == _huidigeEigenaar.Naam && x.Email == _huidigeEigenaar.Email);
                DataManager.SlaEigenarenOp(lijst);

                if (this.ParentForm is MainForm mainForm)
                {
                    mainForm.ActiveerMenuKnopInCode("btnEigenaren");
                    mainForm.ToonScherm(new ucEigenaren());
                }
            }
        }

        private void btnHuisdierProfielEigenaar_Click(object sender, EventArgs e)
        {
            if (this.ParentForm is MainForm mainForm)
            {
                mainForm.ActiveerMenuKnopInCode("btnDieren");
                ucDierenToevoegen toevoegScherm = new ucDierenToevoegen();

                // Optioneel: Je kunt hier de eigenaarnaam alvast "klaarzetten" 
                // als ucDierenToevoegen daar een methode voor heeft.
                mainForm.ToonScherm(toevoegScherm);
            }
        }
    }
}

