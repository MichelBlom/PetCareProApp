namespace PetCareProApp
{
    partial class ucEigenaren
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeaderEIgenaren = new System.Windows.Forms.Panel();
            this.btnZoekenEigenaren = new System.Windows.Forms.Button();
            this.txbZoekenEigenaren = new System.Windows.Forms.TextBox();
            this.lblHeaderEigenaren = new System.Windows.Forms.Label();
            this.pnlFooterEigenaren = new System.Windows.Forms.Panel();
            this.btnToevoegenEigenaren = new System.Windows.Forms.Button();
            this.btnBewerkenEigenaren = new System.Windows.Forms.Button();
            this.btnVerwijderEigenaren = new System.Windows.Forms.Button();
            this.pnlContentEigenaren = new System.Windows.Forms.Panel();
            this.dgvEigenaren = new System.Windows.Forms.DataGridView();
            this.colNaam = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colWoonplaats = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStraat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHuisNummer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPostCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelefoon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHuisdier = new System.Windows.Forms.DataGridViewLinkColumn();
            this.pnlHeaderEIgenaren.SuspendLayout();
            this.pnlFooterEigenaren.SuspendLayout();
            this.pnlContentEigenaren.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEigenaren)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeaderEIgenaren
            // 
            this.pnlHeaderEIgenaren.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlHeaderEIgenaren.Controls.Add(this.btnZoekenEigenaren);
            this.pnlHeaderEIgenaren.Controls.Add(this.txbZoekenEigenaren);
            this.pnlHeaderEIgenaren.Controls.Add(this.lblHeaderEigenaren);
            this.pnlHeaderEIgenaren.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderEIgenaren.Location = new System.Drawing.Point(10, 10);
            this.pnlHeaderEIgenaren.Name = "pnlHeaderEIgenaren";
            this.pnlHeaderEIgenaren.Size = new System.Drawing.Size(780, 50);
            this.pnlHeaderEIgenaren.TabIndex = 0;
            // 
            // btnZoekenEigenaren
            // 
            this.btnZoekenEigenaren.BackColor = System.Drawing.Color.Gainsboro;
            this.btnZoekenEigenaren.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnZoekenEigenaren.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnZoekenEigenaren.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoekenEigenaren.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZoekenEigenaren.ForeColor = System.Drawing.Color.Black;
            this.btnZoekenEigenaren.Location = new System.Drawing.Point(668, 10);
            this.btnZoekenEigenaren.Name = "btnZoekenEigenaren";
            this.btnZoekenEigenaren.Size = new System.Drawing.Size(100, 30);
            this.btnZoekenEigenaren.TabIndex = 4;
            this.btnZoekenEigenaren.Text = "Zoeken";
            this.btnZoekenEigenaren.UseVisualStyleBackColor = false;
            this.btnZoekenEigenaren.Click += new System.EventHandler(this.btnZoekenEigenaren_Click);
            // 
            // txbZoekenEigenaren
            // 
            this.txbZoekenEigenaren.BackColor = System.Drawing.Color.White;
            this.txbZoekenEigenaren.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbZoekenEigenaren.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbZoekenEigenaren.Location = new System.Drawing.Point(462, 13);
            this.txbZoekenEigenaren.Name = "txbZoekenEigenaren";
            this.txbZoekenEigenaren.Size = new System.Drawing.Size(200, 27);
            this.txbZoekenEigenaren.TabIndex = 2;
            // 
            // lblHeaderEigenaren
            // 
            this.lblHeaderEigenaren.AutoSize = true;
            this.lblHeaderEigenaren.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderEigenaren.Location = new System.Drawing.Point(8, 10);
            this.lblHeaderEigenaren.Name = "lblHeaderEigenaren";
            this.lblHeaderEigenaren.Size = new System.Drawing.Size(228, 31);
            this.lblHeaderEigenaren.TabIndex = 0;
            this.lblHeaderEigenaren.Text = "Overzicht eigenaren";
            // 
            // pnlFooterEigenaren
            // 
            this.pnlFooterEigenaren.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlFooterEigenaren.Controls.Add(this.btnToevoegenEigenaren);
            this.pnlFooterEigenaren.Controls.Add(this.btnBewerkenEigenaren);
            this.pnlFooterEigenaren.Controls.Add(this.btnVerwijderEigenaren);
            this.pnlFooterEigenaren.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooterEigenaren.Location = new System.Drawing.Point(10, 540);
            this.pnlFooterEigenaren.Name = "pnlFooterEigenaren";
            this.pnlFooterEigenaren.Size = new System.Drawing.Size(780, 60);
            this.pnlFooterEigenaren.TabIndex = 2;
            // 
            // btnToevoegenEigenaren
            // 
            this.btnToevoegenEigenaren.BackColor = System.Drawing.Color.Gainsboro;
            this.btnToevoegenEigenaren.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToevoegenEigenaren.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnToevoegenEigenaren.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToevoegenEigenaren.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToevoegenEigenaren.ForeColor = System.Drawing.Color.Black;
            this.btnToevoegenEigenaren.Location = new System.Drawing.Point(396, 15);
            this.btnToevoegenEigenaren.Name = "btnToevoegenEigenaren";
            this.btnToevoegenEigenaren.Size = new System.Drawing.Size(120, 30);
            this.btnToevoegenEigenaren.TabIndex = 6;
            this.btnToevoegenEigenaren.Text = "Toevoegen";
            this.btnToevoegenEigenaren.UseVisualStyleBackColor = false;
            this.btnToevoegenEigenaren.Click += new System.EventHandler(this.btnToevoegenEigenaren_Click);
            // 
            // btnBewerkenEigenaren
            // 
            this.btnBewerkenEigenaren.BackColor = System.Drawing.Color.Gainsboro;
            this.btnBewerkenEigenaren.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBewerkenEigenaren.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnBewerkenEigenaren.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBewerkenEigenaren.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBewerkenEigenaren.ForeColor = System.Drawing.Color.Black;
            this.btnBewerkenEigenaren.Location = new System.Drawing.Point(522, 15);
            this.btnBewerkenEigenaren.Name = "btnBewerkenEigenaren";
            this.btnBewerkenEigenaren.Size = new System.Drawing.Size(120, 30);
            this.btnBewerkenEigenaren.TabIndex = 5;
            this.btnBewerkenEigenaren.Text = "Bewerken";
            this.btnBewerkenEigenaren.UseVisualStyleBackColor = false;
            this.btnBewerkenEigenaren.Click += new System.EventHandler(this.btnBewerkenEigenaren_Click);
            // 
            // btnVerwijderEigenaren
            // 
            this.btnVerwijderEigenaren.BackColor = System.Drawing.Color.Gainsboro;
            this.btnVerwijderEigenaren.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerwijderEigenaren.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnVerwijderEigenaren.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerwijderEigenaren.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerwijderEigenaren.ForeColor = System.Drawing.Color.Black;
            this.btnVerwijderEigenaren.Location = new System.Drawing.Point(648, 15);
            this.btnVerwijderEigenaren.Name = "btnVerwijderEigenaren";
            this.btnVerwijderEigenaren.Size = new System.Drawing.Size(120, 30);
            this.btnVerwijderEigenaren.TabIndex = 4;
            this.btnVerwijderEigenaren.Text = "Verwijderen";
            this.btnVerwijderEigenaren.UseVisualStyleBackColor = false;
            this.btnVerwijderEigenaren.Click += new System.EventHandler(this.btnVerwijderEigenaren_Click);
            // 
            // pnlContentEigenaren
            // 
            this.pnlContentEigenaren.Controls.Add(this.dgvEigenaren);
            this.pnlContentEigenaren.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContentEigenaren.Location = new System.Drawing.Point(10, 60);
            this.pnlContentEigenaren.Name = "pnlContentEigenaren";
            this.pnlContentEigenaren.Size = new System.Drawing.Size(780, 480);
            this.pnlContentEigenaren.TabIndex = 3;
            // 
            // dgvEigenaren
            // 
            this.dgvEigenaren.AllowUserToAddRows = false;
            this.dgvEigenaren.AllowUserToDeleteRows = false;
            this.dgvEigenaren.AllowUserToResizeRows = false;
            this.dgvEigenaren.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEigenaren.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvEigenaren.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEigenaren.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEigenaren.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEigenaren.ColumnHeadersHeight = 29;
            this.dgvEigenaren.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvEigenaren.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNaam,
            this.colWoonplaats,
            this.colStraat,
            this.colHuisNummer,
            this.colPostCode,
            this.colTelefoon,
            this.colEmail,
            this.colHuisdier});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEigenaren.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEigenaren.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEigenaren.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvEigenaren.Location = new System.Drawing.Point(0, 0);
            this.dgvEigenaren.MultiSelect = false;
            this.dgvEigenaren.Name = "dgvEigenaren";
            this.dgvEigenaren.ReadOnly = true;
            this.dgvEigenaren.RowHeadersVisible = false;
            this.dgvEigenaren.RowHeadersWidth = 51;
            this.dgvEigenaren.RowTemplate.Height = 24;
            this.dgvEigenaren.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEigenaren.Size = new System.Drawing.Size(780, 480);
            this.dgvEigenaren.TabIndex = 3;
            // 
            // colNaam
            // 
            this.colNaam.DataPropertyName = "Naam";
            this.colNaam.HeaderText = "Naam";
            this.colNaam.MinimumWidth = 6;
            this.colNaam.Name = "colNaam";
            this.colNaam.ReadOnly = true;
            // 
            // colWoonplaats
            // 
            this.colWoonplaats.DataPropertyName = "Woonplaats";
            this.colWoonplaats.HeaderText = "Woonplaats";
            this.colWoonplaats.MinimumWidth = 6;
            this.colWoonplaats.Name = "colWoonplaats";
            this.colWoonplaats.ReadOnly = true;
            // 
            // colStraat
            // 
            this.colStraat.DataPropertyName = "Straat";
            this.colStraat.HeaderText = "Straat";
            this.colStraat.MinimumWidth = 6;
            this.colStraat.Name = "colStraat";
            this.colStraat.ReadOnly = true;
            // 
            // colHuisNummer
            // 
            this.colHuisNummer.DataPropertyName = "Huisnummer";
            this.colHuisNummer.HeaderText = "Huisnummer";
            this.colHuisNummer.MinimumWidth = 6;
            this.colHuisNummer.Name = "colHuisNummer";
            this.colHuisNummer.ReadOnly = true;
            // 
            // colPostCode
            // 
            this.colPostCode.DataPropertyName = "Postcode";
            this.colPostCode.HeaderText = "Postcode";
            this.colPostCode.MinimumWidth = 6;
            this.colPostCode.Name = "colPostCode";
            this.colPostCode.ReadOnly = true;
            // 
            // colTelefoon
            // 
            this.colTelefoon.DataPropertyName = "Telefoon";
            this.colTelefoon.HeaderText = "Telefoon";
            this.colTelefoon.MinimumWidth = 6;
            this.colTelefoon.Name = "colTelefoon";
            this.colTelefoon.ReadOnly = true;
            // 
            // colEmail
            // 
            this.colEmail.DataPropertyName = "Email";
            this.colEmail.HeaderText = "E-mail";
            this.colEmail.MinimumWidth = 6;
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            // 
            // colHuisdier
            // 
            this.colHuisdier.DataPropertyName = "Huisdier";
            this.colHuisdier.HeaderText = "Huisdier";
            this.colHuisdier.MinimumWidth = 6;
            this.colHuisdier.Name = "colHuisdier";
            this.colHuisdier.ReadOnly = true;
            this.colHuisdier.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colHuisdier.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ucEigenaren
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlContentEigenaren);
            this.Controls.Add(this.pnlFooterEigenaren);
            this.Controls.Add(this.pnlHeaderEIgenaren);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(800, 610);
            this.MinimumSize = new System.Drawing.Size(800, 610);
            this.Name = "ucEigenaren";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(800, 610);
            this.pnlHeaderEIgenaren.ResumeLayout(false);
            this.pnlHeaderEIgenaren.PerformLayout();
            this.pnlFooterEigenaren.ResumeLayout(false);
            this.pnlContentEigenaren.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEigenaren)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeaderEIgenaren;
        private System.Windows.Forms.Label lblHeaderEigenaren;
        private System.Windows.Forms.Panel pnlFooterEigenaren;
        private System.Windows.Forms.Panel pnlContentEigenaren;
        private System.Windows.Forms.TextBox txbZoekenEigenaren;
        private System.Windows.Forms.Button btnToevoegenEigenaren;
        private System.Windows.Forms.Button btnBewerkenEigenaren;
        private System.Windows.Forms.Button btnVerwijderEigenaren;
        private System.Windows.Forms.DataGridView dgvEigenaren;
        private System.Windows.Forms.Button btnZoekenEigenaren;
        private System.Windows.Forms.DataGridViewLinkColumn colNaam;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWoonplaats;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStraat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHuisNummer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPostCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelefoon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewLinkColumn colHuisdier;
    }
}
