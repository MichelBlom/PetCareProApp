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
    public partial class ucDashboard : UserControl
    {
        private const int TOTAAL_HOKKEN = 100;

        public ucDashboard()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Deze methode haalt de data op via de DataManager en vult alle velden op het dashboard.
        /// </summary>
        public void RefreshDashboard()
        {
            // 1. Data ophalen uit de DataManager
            List<Reservering> alleReserveringen = DataManager.LaadReserveringen();
            List<Eigenaar> alleEigenaren = DataManager.LaadEigenaren();
            List<Dier> alleDieren = DataManager.LaadDieren();

            // 2. Statistieken (Labels) bijwerken
            UpdateStatistieken(alleReserveringen, alleEigenaren);

            // 3. Grids vullen met data voor vandaag
            VulGrids(alleReserveringen, alleDieren);
        }

        private void UpdateStatistieken(List<Reservering> reserveringen, List<Eigenaar> eigenaren)
        {
            // Huidige gasten: dieren die nu op dit moment de status "Ingecheckt" hebben
            int huidigeGastenCount = reserveringen.Count(r => r.Status == "Ingecheckt");
            lblHuidigeGastenDashboard.Text = huidigeGastenCount.ToString();

            // Vrije hokken: 100 min het aantal unieke hokken dat momenteel bezet is
            int bezetteHokkenCount = reserveringen
                .Where(r => r.Status == "Ingecheckt")
                .Select(r => r.Verblijf)
                .Distinct()
                .Count();
            lblVrijeHokkenDashboard.Text = (TOTAAL_HOKKEN - bezetteHokkenCount).ToString();

            // Aantal klanten: Totaal aantal eigenaren in de lijst
            lblAantalKlantenDashboard.Text = eigenaren.Count.ToString();

            // Aantal Check-ins: Het totaal aantal reserveringen ooit gemaakt
            lblAantalCheckInsDashboard.Text = reserveringen.Count.ToString();
        }

        private void VulGrids(List<Reservering> reserveringen, List<Dier> dieren)
        {
            dgvCkeckInDashboard.Rows.Clear();
            dgvCheckOutDashboard.Rows.Clear();
            DateTime vandaag = DateTime.Today;

            // Filter reserveringen voor vandaag
            var aankomstVandaag = reserveringen.Where(r => r.StartDatum.Date == vandaag).ToList();
            var vertrekVandaag = reserveringen.Where(r => r.EindDatum.Date == vandaag).ToList();

            // Vul Aankomst Grid
            foreach (var res in aankomstVandaag)
            {
                string eigenaarNaam = ZoekEigenaarNaam(res.DierChipnummer, dieren);
                dgvCkeckInDashboard.Rows.Add(res.Verblijf, res.DierNaam, eigenaarNaam);
            }

            // Vul Vertrek Grid
            foreach (var res in vertrekVandaag)
            {
                string eigenaarNaam = ZoekEigenaarNaam(res.DierChipnummer, dieren);
                dgvCheckOutDashboard.Rows.Add(res.Verblijf, res.DierNaam, eigenaarNaam);
            }
        }

        private string ZoekEigenaarNaam(string chipnummer, List<Dier> dieren)
        {
            var dier = dieren.FirstOrDefault(d => d.Chipnummer == chipnummer);
            return dier != null ? dier.Eigenaar : "Onbekend";
        }
    }
}
