using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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

            // Koppel klik-event voor navigatie via de tabel
            dgvEigenaren.CellClick += dgvEigenaren_CellClick;
        }

        private void InstellenPlaceholder()
        {
            // Initialiseer de zoekbalk met placeholder tekst
            txbZoekenEigenaren.Text = ZoekPlaceholder;
            txbZoekenEigenaren.ForeColor = Color.Gray;

            // Verwijder placeholder wanneer gebruiker in het veld klikt
            txbZoekenEigenaren.Enter += (s, e) =>
            {
                if (txbZoekenEigenaren.Text == ZoekPlaceholder)
                {
                    txbZoekenEigenaren.Text = "";
                    txbZoekenEigenaren.ForeColor = Color.Black;
                }
            };

            // Herstel placeholder bij leeg veld
            txbZoekenEigenaren.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txbZoekenEigenaren.Text))
                {
                    txbZoekenEigenaren.Text = ZoekPlaceholder;
                    txbZoekenEigenaren.ForeColor = Color.Gray;
                }
            };

            // Start zoeken zodra op Enter wordt gedrukt
            txbZoekenEigenaren.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    VulTabel(txbZoekenEigenaren.Text);
                    e.SuppressKeyPress = true;
                }
            };

            // Update de resultaten direct tijdens het typen
            txbZoekenEigenaren.TextChanged += (s, e) =>
            {
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

            // Vult tabel met data
            var weergaveLijst = alleEigenaren.Select(e => new EigenaarTabelView
            {
                Naam = e.Naam,
                Email = e.Email,
                Telefoon = e.Telefoonnummer,
                Postcode = e.Postcode,
                Straat = e.Straat,
                Huisnummer = e.Huisnummer,
                Woonplaats = e.Woonplaats,
                // Koppel huisdieren van deze eigenaar aan de tekstkolom
                Huisdier = string.Join(", ", alleDieren.Where(d => d.Eigenaar == e.Naam).Select(d => d.Naam)),
                DeEigenaar = e
            }).ToList();

            // Filter toepassen op basis van de zoekopdracht
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

            // Maak specifieke kolommen herkenbaar als klikbare links
            foreach (DataGridViewColumn col in dgvEigenaren.Columns)
            {
                if (col.DataPropertyName == "Naam" || col.DataPropertyName == "Huisdier")
                {
                    col.DefaultCellStyle.ForeColor = Color.Blue;
                    Font linkFont = new Font(dgvEigenaren.Font, FontStyle.Underline);
                    col.DefaultCellStyle.Font = linkFont;
                }
            }
        }

        private void btnZoekenEigenaren_Click(object sender, EventArgs e)
        {
            // Handmatig zoeken via de zoekknop
            VulTabel(txbZoekenEigenaren.Text);
        }

        private void btnToevoegenEigenaren_Click(object sender, EventArgs e)
        {
            // Open het formulier om een nieuwe eigenaar aan te maken
            if (this.ParentForm is MainForm mainForm)
            {
                mainForm.ToonScherm(new ucEigenaarToevoegen());
            }
        }

        private void btnBewerkenEigenaren_Click(object sender, EventArgs e)
        {
            // Open bewerkscherm voor de geselecteerde eigenaar
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
            // Verwijder geselecteerde eigenaar na bevestiging
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
            // Navigeer naar de profielpagina van de geselecteerde eigenaar
            if (dgvEigenaren.CurrentRow?.DataBoundItem is EigenaarTabelView geselecteerdeView)
            {
                Eigenaar deEigenaar = geselecteerdeView.DeEigenaar;
                if (this.ParentForm is MainForm mainForm)
                {
                    ucProfielEigenaar profiel = new ucProfielEigenaar();
                    profiel.VulData(deEigenaar, "Overzicht");
                    mainForm.ToonScherm(profiel);
                }
            }
            else
            {
                MessageBox.Show("Selecteer eerst een eigenaar om het profiel te bekijken.");
            }
        }

        private void dgvEigenaren_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var kolom = dgvEigenaren.Columns[e.ColumnIndex];
                var cellValue = dgvEigenaren.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

                // Navigatie naar eigenaarsprofiel via de naam
                if (kolom.Name == "Naam" || kolom.DataPropertyName == "Naam")
                {
                    if (dgvEigenaren.Rows[e.RowIndex].DataBoundItem is EigenaarTabelView view)
                    {
                        if (this.ParentForm is MainForm mainForm)
                        {
                            ucProfielEigenaar profiel = new ucProfielEigenaar();
                            profiel.VulData(view.DeEigenaar, "Overzicht");
                            mainForm.ToonScherm(profiel);
                        }
                    }
                }
                // Navigatie naar dierprofiel via de huisdier
                else if (kolom.Name == "Huisdier" || kolom.DataPropertyName == "Huisdier")
                {
                    if (!string.IsNullOrWhiteSpace(cellValue))
                    {
                        string eersteDierNaam = cellValue.Split(',')[0].Trim();
                        var dier = DataManager.LaadDieren().FirstOrDefault(d => d.Naam == eersteDierNaam);

                        if (dier != null && this.ParentForm is MainForm mainForm)
                        {
                            mainForm.ActiveerMenuKnopInCode("btnDieren");
                            ucProfielPaginaDieren dierProfiel = new ucProfielPaginaDieren();
                            dierProfiel.VulData(dier, "EigenarenOverzicht");
                            mainForm.ToonScherm(dierProfiel);
                        }
                    }
                }
            }
        }
    }

    // Klasse voor data in de DataGridView
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

        // Verberg de ruwe data van de eigenaar voor de tabelweergave
        [System.ComponentModel.Browsable(false)]
        public Eigenaar DeEigenaar { get; set; }
    }
}
