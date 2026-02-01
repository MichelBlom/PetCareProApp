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
        private Dier _bronDier = null;

        public ucProfielEigenaar()
        {
            InitializeComponent();
        }

        // Constructor voor directe aanroep
        public ucProfielEigenaar(Eigenaar eigenaar) : this()
        {
            VulData(eigenaar, "Dashboard");
        }

        public void VulData(Eigenaar eigenaar, string bron = "Overzicht", Dier bronDier = null)
        {
            _huidigeEigenaar = eigenaar;
            _bronScherm = bron;
            _bronDier = bronDier;

            // Vul alle labels met eigenaar-gegevens
            lblHeaderProfielEigenaar.Text = $"Profiel van {eigenaar.Naam}";
            lblNaamProfielEigenaar.Text = eigenaar.Naam;
            lblStraatProfielEigenaar.Text = eigenaar.Straat;
            lblHuisNummerProfielEigenaar.Text = eigenaar.Huisnummer.ToString();
            lblPostcodeProfielEigenaar.Text = eigenaar.Postcode;
            lblWoonplaatsProfielEigenaar.Text = eigenaar.Woonplaats;
            lblEmailProfielEigenaar.Text = eigenaar.Email;
            lblTelefoonProfielEigenaar.Text = eigenaar.Telefoonnummer;
            lblOpmerkingenProfielEigenaar.Text = eigenaar.Opmerkingen;

            HerlaadDierenLijst();
        }

        private void HerlaadDierenLijst()
        {
            flpDierenProfielEigenaar.Controls.Clear();
            var alleDieren = DataManager.LaadDieren();
            var eigenDieren = alleDieren.Where(d => d.Eigenaar == _huidigeEigenaar.Naam).ToList();

            // Toon melding als er geen dieren zijn gekoppeld
            if (!eigenDieren.Any())
            {
                Label lblLeeg = new Label { Text = "Geen huisdieren gevonden.", AutoSize = true, ForeColor = Color.Gray, Padding = new Padding(10) };
                flpDierenProfielEigenaar.Controls.Add(lblLeeg);
                return;
            }

            // Genereer visuele kaarten voor elk huisdier
            foreach (var dier in eigenDieren)
            {
                Panel pnlDierCard = new Panel { Size = new Size(130, 150), BackColor = Color.White, Margin = new Padding(10), Cursor = Cursors.Hand };
                PictureBox pcbDier = new PictureBox { Size = new Size(130, 110), Location = new Point(0, 0), SizeMode = PictureBoxSizeMode.Zoom, BorderStyle = BorderStyle.None };

                string fotoPad = DataManager.KrijgFotoPad(dier.FotoBestandsnaam);

                // Laad foto of toon placeholder
                if (!string.IsNullOrEmpty(dier.FotoBestandsnaam) && File.Exists(fotoPad)) pcbDier.ImageLocation = fotoPad;
                else pcbDier.BackColor = Color.LightGray;

                Label lblNaam = new Label { Text = dier.Naam, Size = new Size(130, 40), Location = new Point(0, 110), TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 9, FontStyle.Bold), BackColor = Color.FromArgb(240, 240, 240) };

                // Klik-event om naar het specifieke dierprofiel te gaan
                EventHandler gaNaarDier = (s, e) =>
                {
                    if (this.ParentForm is MainForm mainForm)
                    {
                        mainForm.ActiveerMenuKnopInCode("btnDieren");
                        ucProfielPaginaDieren dierProfiel = new ucProfielPaginaDieren();
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
                // Bepaal de juiste terugkeer-locatie op basis van de herkomst
                if (_bronScherm == "Dashboard")
                {
                    mainForm.ToonScherm(new ucDashboard());
                }
                else if (_bronScherm == "DierProfiel" && _bronDier != null)
                {
                    mainForm.ActiveerMenuKnopInCode("btnDieren");
                    ucProfielPaginaDieren dierScherm = new ucProfielPaginaDieren();
                    dierScherm.VulData(_bronDier, "ProfielEigenaar");
                    mainForm.ToonScherm(dierScherm);
                }
                else if (_bronScherm == "DierenLijst")
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
            // Open bewerkscherm voor de huidige eigenaar
            if (this.ParentForm is MainForm mainForm && _huidigeEigenaar != null)
            {
                mainForm.ToonScherm(new ucEigenaarToevoegen(_huidigeEigenaar, true));
            }
        }

        private void btnVerwijderenProfielEigenaar_Click(object sender, EventArgs e)
        {
            // Verwijder eigenaar na bevestiging en keer terug naar overzicht
            if (_huidigeEigenaar == null) return;
            if (MessageBox.Show($"Weet je zeker dat je {_huidigeEigenaar.Naam} wilt verwijderen?", "Bevestig", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
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
            // Direct een nieuw huisdier toevoegen gekoppeld aan deze eigenaar
            if (this.ParentForm is MainForm mainForm && _huidigeEigenaar != null)
            {
                mainForm.ActiveerMenuKnopInCode("btnDieren");
                ucDierenToevoegen toevoegScherm = new ucDierenToevoegen();
                toevoegScherm.PrepareerVoorNieuwDierVanafEigenaar(_huidigeEigenaar.Naam);
                mainForm.ToonScherm(toevoegScherm);
            }
        }
    }
}

