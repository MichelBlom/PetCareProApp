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
    public partial class ucKalender : UserControl
    {
        private DateTime huidigeMaandag;

        public ucKalender()
        {
            InitializeComponent();

            // Event koppelen voor het laden van het scherm
            this.Load += UcKalender_Load;

            // Events koppelen voor navigatie
            btnVorigePlanning.Click += BtnVorigePlanning_Click;
            btnVolgendePlanning.Click += BtnVolgendePlanning_Click;
            dtpWeekPlanning.ValueChanged += DtpWeekPlanning_ValueChanged;
        }

        private void UcKalender_Load(object sender, EventArgs e)
        {
            // Zet de datum bij opstarten op vandaag en update de header
            InstellenWeek(DateTime.Now);
        }

        private void InstellenWeek(DateTime datum)
        {
            // Zoek de maandag van de gekozen week
            int verschil = (int)datum.DayOfWeek - (int)DayOfWeek.Monday;
            if (verschil < 0) verschil += 7; // Correctie als het zondag is

            huidigeMaandag = datum.AddDays(-verschil).Date;

            // Update de DateTimePicker zonder een oneindige loop te triggeren
            dtpWeekPlanning.ValueChanged -= DtpWeekPlanning_ValueChanged;
            dtpWeekPlanning.Value = huidigeMaandag;
            dtpWeekPlanning.ValueChanged += DtpWeekPlanning_ValueChanged;

            UpdateHeaderDatums();
        }

        private void UpdateHeaderDatums()
        {
            // Zet de teksten in de labels (Ma 02/02 etc.)
            lblMaPlanning.Text = $"Ma {huidigeMaandag:dd/MM}";
            lblDiPlanning.Text = $"Di {huidigeMaandag.AddDays(1):dd/MM}";
            lblWoPlanning.Text = $"Wo {huidigeMaandag.AddDays(2):dd/MM}";
            lblDoPlanning.Text = $"Do {huidigeMaandag.AddDays(3):dd/MM}";
            lblVrPlanning.Text = $"Vr {huidigeMaandag.AddDays(4):dd/MM}";
            lblZaPlanning.Text = $"Za {huidigeMaandag.AddDays(5):dd/MM}";
            lblZoPlanning.Text = $"Zo {huidigeMaandag.AddDays(6):dd/MM}";
        }

        private void BtnVorigePlanning_Click(object sender, EventArgs e)
        {
            InstellenWeek(huidigeMaandag.AddDays(-7));
        }

        private void BtnVolgendePlanning_Click(object sender, EventArgs e)
        {
            InstellenWeek(huidigeMaandag.AddDays(7));
        }

        private void DtpWeekPlanning_ValueChanged(object sender, EventArgs e)
        {
            InstellenWeek(dtpWeekPlanning.Value);
        }
    }
}
