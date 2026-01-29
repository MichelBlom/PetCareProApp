using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing; // Nodig voor Color
using System.Linq;
using System.Windows.Forms;

namespace PetCareProApp
{
    public partial class ucEigenaren : UserControl
    {
        private const string ZoekPlaceholder = "Typ naam van dier of eigenaar...";

        public ucEigenaren()
        {
            InitializeComponent();
            InstellenPlaceholder();
            VulTabel();
        }

        private void InstellenPlaceholder()
        {
            txbZoekenEigenaren.Text = ZoekPlaceholder;
            txbZoekenEigenaren.ForeColor = Color.Gray;

            txbZoekenEigenaren.Enter += (s, e) =>
            {
                if (txbZoekenEigenaren.Text == ZoekPlaceholder)
                {
                    txbZoekenEigenaren.Text = "";
                    txbZoekenEigenaren.ForeColor = Color.Black;
                }
            };

            txbZoekenEigenaren.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txbZoekenEigenaren.Text))
                {
                    txbZoekenEigenaren.Text = ZoekPlaceholder;
                    txbZoekenEigenaren.ForeColor = Color.Gray;
                }
            };

            // Enter-toets afvangen zonder piepje
            txbZoekenEigenaren.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    VulTabel(txbZoekenEigenaren.Text);
                    e.SuppressKeyPress = true;
                }
            };

            // Automatisch verversen bij typen of verwijderen
            txbZoekenEigenaren.TextChanged += (s, e) =>
            {
                // Alleen verversen als het niet de placeholder is die we zelf zetten
                if (txbZoekenEigenaren.Text != ZoekPlaceholder)
                {
                    VulTabel(txbZoekenEigenaren.Text);
                }
            };
        }

        public void VulTabel(string filter = "")
        {
            List<Eigenaar> alleEigenaren = DataManager.LaadEigenaren();
            List<Dier> alleDieren = DataManager.LaadDieren();

            dgvEigenaren.AutoGenerateColumns = false;

            var weergaveLijst = alleEigenaren.Select(e => new EigenaarTabelView
            {
                Naam = e.Naam,
                Email = e.Email,
                Telefoon = e.Telefoonnummer,
                Postcode = e.Postcode,
                Straat = e.Straat,
                Huisnummer = e.Huisnummer,
                Woonplaats = e.Woonplaats,
                Huisdier = string.Join(", ", alleDieren.Where(d => d.Eigenaar == e.Naam).Select(d => d.Naam)),
                DeEigenaar = e
            }).ToList();

            if (!string.IsNullOrWhiteSpace(filter) && filter != ZoekPlaceholder)
            {
                string f = filter.ToLower();
                weergaveLijst = weergaveLijst.Where(x =>
                    x.Naam.ToLower().Contains(f) ||
                    x.Huisdier.ToLower().Contains(f)
                ).ToList();
            }

            dgvEigenaren.DataSource = null;
            dgvEigenaren.DataSource = weergaveLijst;
        }

        private void btnZoekenEigenaren_Click(object sender, EventArgs e)
        {
            VulTabel(txbZoekenEigenaren.Text);
        }

        private void btnToevoegenEigenaren_Click(object sender, EventArgs e)
        {
            if (this.ParentForm is MainForm mainForm)
            {
                mainForm.ToonScherm(new ucEigenaarToevoegen());
            }
        }

        private void btnBewerkenEigenaren_Click(object sender, EventArgs e)
        {
            if (dgvEigenaren.CurrentRow?.DataBoundItem is EigenaarTabelView geselecteerdeView)
            {
                Eigenaar deEigenaar = geselecteerdeView.DeEigenaar;
                if (this.ParentForm is MainForm mainForm)
                {
                    mainForm.ToonScherm(new ucEigenaarToevoegen(deEigenaar));
                }
            }
            else
            {
                MessageBox.Show("Selecteer eerst een eigenaar in de tabel om te bewerken.");
            }
        }

        private void btnVerwijderEigenaren_Click(object sender, EventArgs e)
        {
            if (dgvEigenaren.CurrentRow?.DataBoundItem is EigenaarTabelView geselecteerdeView)
            {
                var resultaat = MessageBox.Show($"Weet je zeker dat je {geselecteerdeView.Naam} wilt verwijderen?",
                    "Bevestig verwijderen", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultaat == DialogResult.Yes)
                {
                    var lijst = DataManager.LaadEigenaren();
                    var teVerwijderen = lijst.FirstOrDefault(x => x.Naam == geselecteerdeView.Naam && x.Email == geselecteerdeView.Email);

                    if (teVerwijderen != null)
                    {
                        lijst.Remove(teVerwijderen);
                        DataManager.SlaEigenarenOp(lijst);
                        VulTabel();
                        MessageBox.Show("Eigenaar is verwijderd.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecteer eerst een eigenaar in de tabel.");
            }
        }

        private void btnProfielEigenaren_Click(object sender, EventArgs e)
        {
            if (dgvEigenaren.CurrentRow?.DataBoundItem is EigenaarTabelView geselecteerdeView)
            {
                Eigenaar deEigenaar = geselecteerdeView.DeEigenaar;
                if (this.ParentForm is MainForm mainForm)
                {
                    // Dit gaan we zo in orde maken
                    // mainForm.ToonScherm(new ucEigenaarProfiel(deEigenaar));
                }
            }
            else
            {
                MessageBox.Show("Selecteer eerst een eigenaar om het profiel te bekijken.");
            }
        }
    }

    public class EigenaarTabelView
    {
        public string Naam { get; set; }
        public string Telefoon { get; set; }
        public string Straat { get; set; }
        public string Email { get; set; }
        public string Postcode { get; set; }
        public int Huisnummer { get; set; }
        public string Woonplaats { get; set; }
        public string Huisdier { get; set; }

        [System.ComponentModel.Browsable(false)]
        public Eigenaar DeEigenaar { get; set; }
    }
}
