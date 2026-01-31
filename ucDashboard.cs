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
        /// Haalt data op en ververst het volledige dashboard.
        /// </summary>
        public void RefreshDashboard()
        {
            // We zorgen dat de mappen bestaan voordat we gaan laden
            DataManager.Initialiseer();

            List<Reservering> alleReserveringen = DataManager.LaadReserveringen();
            List<Eigenaar> alleEigenaren = DataManager.LaadEigenaren();
            List<Dier> alleDieren = DataManager.LaadDieren();

            UpdateStatistieken(alleReserveringen, alleEigenaren);
            VulGrids(alleReserveringen, alleDieren);
        }

        private void UpdateStatistieken(List<Reservering> reserveringen, List<Eigenaar> eigenaren)
        {
            // AANGEPAST: We tellen nu dieren met status "Ingecheckt" OF "Gepland" als gasten
            var huidigeGastenLijst = reserveringen.Where(r =>
                !string.IsNullOrEmpty(r.Status) &&
                (r.Status.Trim().Equals("Ingecheckt", StringComparison.OrdinalIgnoreCase) ||
                 r.Status.Trim().Equals("Gepland", StringComparison.OrdinalIgnoreCase))).ToList();

            // 1. Huidige Gasten Label
            lblHuidigeGastenDashboard.Text = huidigeGastenLijst.Count.ToString();

            // 2. Vrije Hokken Label (100 - bezette hokken)
            int bezetteHokkenCount = huidigeGastenLijst
                .Select(r => r.Verblijf)
                .Where(v => !string.IsNullOrEmpty(v) && v != "(Geen)")
                .Distinct()
                .Count();

            lblVrijeHokkenDashboard.Text = (TOTAAL_HOKKEN - bezetteHokkenCount).ToString();

            // 3. Aantal Klanten Label
            lblAantalKlantenDashboard.Text = eigenaren.Count.ToString();

            // 4. Totaal aantal Check-ins (Alle reserveringen ooit)
            lblAantalCheckInsDashboard.Text = reserveringen.Count.ToString();
        }

        private void VulGrids(List<Reservering> reserveringen, List<Dier> dieren)
        {
            dgvCkeckInDashboard.Rows.Clear();
            dgvCheckOutDashboard.Rows.Clear();
            DateTime vandaag = DateTime.Today;

            // Alleen reserveringen die exact vandaag starten of eindigen
            var aankomstVandaag = reserveringen.Where(r => r.StartDatum.Date == vandaag).ToList();
            var vertrekVandaag = reserveringen.Where(r => r.EindDatum.Date == vandaag).ToList();

            foreach (var res in aankomstVandaag)
            {
                dgvCkeckInDashboard.Rows.Add(res.Verblijf, res.DierNaam, ZoekEigenaarNaam(res.DierChipnummer, dieren));
            }

            foreach (var res in vertrekVandaag)
            {
                dgvCheckOutDashboard.Rows.Add(res.Verblijf, res.DierNaam, ZoekEigenaarNaam(res.DierChipnummer, dieren));
            }
        }

        private string ZoekEigenaarNaam(string chipnummer, List<Dier> dieren)
        {
            var dier = dieren.FirstOrDefault(d => d.Chipnummer == chipnummer);
            return dier != null ? dier.Eigenaar : "Onbekend";
        }
    }
}
