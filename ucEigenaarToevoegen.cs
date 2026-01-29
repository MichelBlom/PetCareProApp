using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PetCareProApp
{
    public partial class ucEigenaarToevoegen : UserControl
    {
        private Eigenaar _bewerkEigenaar = null;
        private bool kwamVanDierToevoegen = false; // NIEUW: Houdt de status bij

        // Constructor voor NIEUW
        public ucEigenaarToevoegen()
        {
            InitializeComponent();
            lblHeaderEigenaarToevoegen.Text = "Eigenaar toevoegen";
        }

        // Constructor voor BEWERKEN
        public ucEigenaarToevoegen(Eigenaar eigenaar)
        {
            InitializeComponent();
            _bewerkEigenaar = eigenaar;
            lblHeaderEigenaarToevoegen.Text = "Eigenaar bewerken";
            VulVeldenIn();
        }

        // NIEUW: Deze methode lost de error in ucDierenToevoegen op
        public void StelTerugkeerIn(bool status)
        {
            kwamVanDierToevoegen = status;
        }

        private void VulVeldenIn()
        {
            txbNaamEigenaarToevoegen.Text = _bewerkEigenaar.Naam;
            txbEmailEigenaarToevoegen.Text = _bewerkEigenaar.Email;
            txbTelefoonEigenaarToevoegen.Text = _bewerkEigenaar.Telefoonnummer;
            txbWoonplaatsEigenaarToevoegen.Text = _bewerkEigenaar.Woonplaats;
            nmrHuisNummerEigenaarToevoegen.Value = _bewerkEigenaar.Huisnummer;
            txbStraatEigenaarToevoegen.Text = _bewerkEigenaar.Straat;
            txbPostcodeEigenaarToevoegen.Text = _bewerkEigenaar.Postcode;
            txbOpmerkingenEigenaarToevoegen.Text = _bewerkEigenaar.Opmerkingen;
        }

        private void UitvoerenOpslag()
        {
            if (string.IsNullOrWhiteSpace(txbNaamEigenaarToevoegen.Text))
            {
                MessageBox.Show("De naam is verplicht.");
                return;
            }

            try
            {
                var lijst = DataManager.LaadEigenaren();

                if (_bewerkEigenaar != null)
                {
                    var index = lijst.FindIndex(e => e.Naam == _bewerkEigenaar.Naam && e.Email == _bewerkEigenaar.Email);
                    if (index != -1)
                    {
                        lijst[index].Naam = txbNaamEigenaarToevoegen.Text;
                        lijst[index].Email = txbEmailEigenaarToevoegen.Text;
                        lijst[index].Telefoonnummer = txbTelefoonEigenaarToevoegen.Text;
                        lijst[index].Woonplaats = txbWoonplaatsEigenaarToevoegen.Text;
                        lijst[index].Huisnummer = (int)nmrHuisNummerEigenaarToevoegen.Value;
                        lijst[index].Straat = txbStraatEigenaarToevoegen.Text;
                        lijst[index].Postcode = txbPostcodeEigenaarToevoegen.Text;
                        lijst[index].Opmerkingen = txbOpmerkingenEigenaarToevoegen.Text;
                    }
                }
                else
                {
                    Eigenaar nieuweEigenaar = new Eigenaar
                    {
                        Naam = txbNaamEigenaarToevoegen.Text,
                        Email = txbEmailEigenaarToevoegen.Text,
                        Telefoonnummer = txbTelefoonEigenaarToevoegen.Text,
                        Woonplaats = txbWoonplaatsEigenaarToevoegen.Text,
                        Huisnummer = (int)nmrHuisNummerEigenaarToevoegen.Value,
                        Straat = txbStraatEigenaarToevoegen.Text,
                        Postcode = txbPostcodeEigenaarToevoegen.Text,
                        Opmerkingen = txbOpmerkingenEigenaarToevoegen.Text
                    };
                    lijst.Add(nieuweEigenaar);
                }

                DataManager.SlaEigenarenOp(lijst);
                MessageBox.Show("Gegevens succesvol opgeslagen!");

                // Na succesvol opslaan navigeren
                NavigeerNaarOverzicht();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fout bij opslaan: {ex.Message}");
            }
        }

        private void NavigeerNaarOverzicht()
        {
            if (this.ParentForm is MainForm mainForm)
            {
                if (kwamVanDierToevoegen)
                {
                    // Zet indicator terug op Dieren en open dat scherm
                    mainForm.ActiveerMenuKnopInCode("btnDieren");
                    mainForm.ToonScherm(new ucDierenToevoegen());
                }
                else
                {
                    // Standaard gedrag
                    mainForm.ToonScherm(new ucEigenaren());
                }
            }
        }

        private void btnOpslaanEigenaarToevoegen_Click(object sender, EventArgs e)
        {
            UitvoerenOpslag();
        }

        private void btnAnnulerenEigenaarToevoegen_Click(object sender, EventArgs e)
        {
            NavigeerNaarOverzicht();
        }
    }
}

