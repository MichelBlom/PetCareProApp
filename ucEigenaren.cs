using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PetCareProApp
{
    public partial class ucEigenaren : UserControl
    {
        public ucEigenaren()
        {
            InitializeComponent();
            // We roepen de tabelvulling aan zodra het scherm start
            VulTabel();
        }

        public void VulTabel()
        {
            // 1. Haal de data op
            List<Eigenaar> alleEigenaren = DataManager.LaadEigenaren();
            List<Dier> alleDieren = DataManager.LaadDieren();

            dgvEigenaren.AutoGenerateColumns = false;

            // 2. Vertaal naar de weergave-lijst
            var weergaveLijst = alleEigenaren.Select(e => new EigenaarTabelView
            {
                Naam = e.Naam,
                Email = e.Email,
                Telefoon = e.Telefoonnummer, // Hier koppelen we het model aan de view-property
                Postcode = e.Postcode,
                Straat = e.Straat,
                Huisnummer = e.Huisnummer,
                Woonplaats = e.Woonplaats,
                Huisdier = string.Join(", ", alleDieren.Where(d => d.Eigenaar == e.Naam).Select(d => d.Naam)),
                DeEigenaar = e
            }).ToList();

            // 3. Koppel aan de grid
            dgvEigenaren.DataSource = null;
            dgvEigenaren.DataSource = weergaveLijst;
        }

        private void btnToevoegenEigenaren_Click(object sender, EventArgs e)
        {
            if (this.ParentForm is MainForm mainForm)
            {
                // We wisselen naar het toevoegscherm
                mainForm.ToonScherm(new ucEigenaarToevoegen());
            }
        }

        private void btnBewerkenEigenaren_Click(object sender, EventArgs e)
        {

        }

        private void btnVerwijderEigenaren_Click(object sender, EventArgs e)
        {
            // 1. Controleer of er een rij geselecteerd is
            if (dgvEigenaren.CurrentRow?.DataBoundItem is EigenaarTabelView geselecteerdeView)
            {
                // 2. Vraag om bevestiging (veiligheid voorop!)
                var resultaat = MessageBox.Show($"Weet je zeker dat je {geselecteerdeView.Naam} wilt verwijderen?",
                    "Bevestig verwijderen", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultaat == DialogResult.Yes)
                {
                    // 3. Laad de echte lijst, zoek de eigenaar en verwijder hem
                    var lijst = DataManager.LaadEigenaren();

                    // We zoeken op naam (of unieke eigenschap) om de juiste te verwijderen
                    var teVerwijderen = lijst.FirstOrDefault(x => x.Naam == geselecteerdeView.Naam);

                    if (teVerwijderen != null)
                    {
                        lijst.Remove(teVerwijderen);
                        DataManager.SlaEigenarenOp(lijst);

                        // 4. Update de tabel direct
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
    }

    // Deze klasse staat hieronder, buiten de UserControl maar binnen de Namespace
    public class EigenaarTabelView
    {
        public string Naam { get; set; }
        public string Telefoon { get; set; } // Veranderd van Telefoonnummer naar Telefoon
        public string Straat { get; set; }
        public string Email { get; set; }
        public string Postcode { get; set; } // Nieuw toegevoegd
        public int Huisnummer { get; set; }   // Nieuw toegevoegd
        public string Woonplaats { get; set; } // Nieuw toegevoegd
        public string Huisdier { get; set; }

        [System.ComponentModel.Browsable(false)]
        public Eigenaar DeEigenaar { get; set; }
    }
}
