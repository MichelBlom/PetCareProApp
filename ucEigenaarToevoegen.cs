using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PetCareProApp
{
    public partial class ucEigenaarToevoegen : UserControl
    {
        public ucEigenaarToevoegen()
        {
            InitializeComponent();
        }

        private void btnOpslaan_Click(object sender, EventArgs e)
        {
            // 1. Validatie
            if (string.IsNullOrWhiteSpace(txbNaamEigenaarToevoegen.Text))
            {
                MessageBox.Show("De naam is verplicht.");
                return;
            }

            // 2. Maak het object aan (Binnen de klik-methode!)
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

            try
            {
                // 3. Opslaan via de DataManager
                var lijst = DataManager.LaadEigenaren();
                lijst.Add(nieuweEigenaar);
                DataManager.SlaEigenarenOp(lijst);

                MessageBox.Show("Eigenaar opgeslagen!");
                NavigeerNaarOverzicht();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fout bij opslaan: {ex.Message}");
            }
        }

        // Hulpmethode voor navigatie (moet ook binnen de class staan)
        private void NavigeerNaarOverzicht()
        {
            if (this.ParentForm is MainForm mainForm)
            {
                mainForm.ToonScherm(new ucEigenaren());
            }
        }

        // Tip: Zorg dat je in de designer ook een 'Click' event maakt voor je annuleer-knop!
        private void btnAnnuleren_Click(object sender, EventArgs e)
        {
            NavigeerNaarOverzicht();
        }

        private void btnOpslaanEigenaarToevoegen_Click(object sender, EventArgs e)
        {
            UitvoerenOpslag();
        }

        private void UitvoerenOpslag()
        {
            // 1. Validatie
            if (string.IsNullOrWhiteSpace(txbNaamEigenaarToevoegen.Text))
            {
                MessageBox.Show("De naam is verplicht.");
                return;
            }

            // 2. Maak het object aan
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

            try
            {
                // 3. Opslaan
                var lijst = DataManager.LaadEigenaren();
                lijst.Add(nieuweEigenaar);
                DataManager.SlaEigenarenOp(lijst);

                MessageBox.Show("Eigenaar opgeslagen!");

                // 4. Terug naar overzicht
                if (this.ParentForm is MainForm mainForm)
                {
                    mainForm.ToonScherm(new ucEigenaren());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fout bij opslaan: {ex.Message}");
            }
        }
        private void btnAnnulerenEigenaarToevoegen_Click(object sender, EventArgs e)
        {
            if (this.ParentForm is MainForm mainForm)
            {
                mainForm.ToonScherm(new ucEigenaren());
            }
        }
    }
}
