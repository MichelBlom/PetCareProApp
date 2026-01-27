namespace PetCareProApp
{
    partial class ucDieren
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
            this.pnlHeaderDieren = new System.Windows.Forms.Panel();
            this.lblHeaderDieren = new System.Windows.Forms.Label();
            this.pnlFooterDieren = new System.Windows.Forms.Panel();
            this.dgvDieren = new System.Windows.Forms.DataGridView();
            this.ColumnNaam = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColumnSoort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLeeftijd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnGeslacht = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEigenaar = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColumnChipnr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnZoekenDieren = new System.Windows.Forms.Button();
            this.txbZoekenDieren = new System.Windows.Forms.TextBox();
            this.btnVerwijderDieren = new System.Windows.Forms.Button();
            this.btnBewerkenDieren = new System.Windows.Forms.Button();
            this.btnToevoegenDieren = new System.Windows.Forms.Button();
            this.pnlHeaderDieren.SuspendLayout();
            this.pnlFooterDieren.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDieren)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeaderDieren
            // 
            this.pnlHeaderDieren.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlHeaderDieren.Controls.Add(this.txbZoekenDieren);
            this.pnlHeaderDieren.Controls.Add(this.lblHeaderDieren);
            this.pnlHeaderDieren.Controls.Add(this.btnZoekenDieren);
            this.pnlHeaderDieren.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderDieren.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlHeaderDieren.Location = new System.Drawing.Point(10, 10);
            this.pnlHeaderDieren.Name = "pnlHeaderDieren";
            this.pnlHeaderDieren.Size = new System.Drawing.Size(780, 50);
            this.pnlHeaderDieren.TabIndex = 0;
            // 
            // lblHeaderDieren
            // 
            this.lblHeaderDieren.AutoSize = true;
            this.lblHeaderDieren.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderDieren.Location = new System.Drawing.Point(3, 11);
            this.lblHeaderDieren.Name = "lblHeaderDieren";
            this.lblHeaderDieren.Size = new System.Drawing.Size(169, 28);
            this.lblHeaderDieren.TabIndex = 1;
            this.lblHeaderDieren.Text = "Overzicht dieren";
            // 
            // pnlFooterDieren
            // 
            this.pnlFooterDieren.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlFooterDieren.Controls.Add(this.btnToevoegenDieren);
            this.pnlFooterDieren.Controls.Add(this.btnBewerkenDieren);
            this.pnlFooterDieren.Controls.Add(this.btnVerwijderDieren);
            this.pnlFooterDieren.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooterDieren.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlFooterDieren.Location = new System.Drawing.Point(10, 540);
            this.pnlFooterDieren.Name = "pnlFooterDieren";
            this.pnlFooterDieren.Size = new System.Drawing.Size(780, 60);
            this.pnlFooterDieren.TabIndex = 1;
            // 
            // dgvDieren
            // 
            this.dgvDieren.AllowUserToAddRows = false;
            this.dgvDieren.AllowUserToDeleteRows = false;
            this.dgvDieren.AllowUserToResizeRows = false;
            this.dgvDieren.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDieren.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgvDieren.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDieren.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDieren.ColumnHeadersHeight = 29;
            this.dgvDieren.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDieren.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnNaam,
            this.ColumnSoort,
            this.ColumnLeeftijd,
            this.ColumnGeslacht,
            this.ColumnRas,
            this.ColumnEigenaar,
            this.ColumnChipnr});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDieren.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDieren.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDieren.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvDieren.Location = new System.Drawing.Point(10, 60);
            this.dgvDieren.Name = "dgvDieren";
            this.dgvDieren.ReadOnly = true;
            this.dgvDieren.RowHeadersVisible = false;
            this.dgvDieren.RowHeadersWidth = 51;
            this.dgvDieren.RowTemplate.Height = 24;
            this.dgvDieren.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDieren.Size = new System.Drawing.Size(780, 480);
            this.dgvDieren.TabIndex = 2;
            // 
            // ColumnNaam
            // 
            this.ColumnNaam.HeaderText = "Naam";
            this.ColumnNaam.MinimumWidth = 6;
            this.ColumnNaam.Name = "ColumnNaam";
            this.ColumnNaam.ReadOnly = true;
            // 
            // ColumnSoort
            // 
            this.ColumnSoort.HeaderText = "Soort";
            this.ColumnSoort.MinimumWidth = 6;
            this.ColumnSoort.Name = "ColumnSoort";
            this.ColumnSoort.ReadOnly = true;
            // 
            // ColumnLeeftijd
            // 
            this.ColumnLeeftijd.HeaderText = "Leeftijd";
            this.ColumnLeeftijd.MinimumWidth = 6;
            this.ColumnLeeftijd.Name = "ColumnLeeftijd";
            this.ColumnLeeftijd.ReadOnly = true;
            // 
            // ColumnGeslacht
            // 
            this.ColumnGeslacht.HeaderText = "Geslacht";
            this.ColumnGeslacht.MinimumWidth = 6;
            this.ColumnGeslacht.Name = "ColumnGeslacht";
            this.ColumnGeslacht.ReadOnly = true;
            // 
            // ColumnRas
            // 
            this.ColumnRas.HeaderText = "Ras";
            this.ColumnRas.MinimumWidth = 6;
            this.ColumnRas.Name = "ColumnRas";
            this.ColumnRas.ReadOnly = true;
            // 
            // ColumnEigenaar
            // 
            this.ColumnEigenaar.HeaderText = "Eigenaar";
            this.ColumnEigenaar.MinimumWidth = 6;
            this.ColumnEigenaar.Name = "ColumnEigenaar";
            this.ColumnEigenaar.ReadOnly = true;
            // 
            // ColumnChipnr
            // 
            this.ColumnChipnr.HeaderText = "Chipnummer";
            this.ColumnChipnr.MinimumWidth = 6;
            this.ColumnChipnr.Name = "ColumnChipnr";
            this.ColumnChipnr.ReadOnly = true;
            // 
            // btnZoekenDieren
            // 
            this.btnZoekenDieren.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnZoekenDieren.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnZoekenDieren.FlatAppearance.BorderSize = 2;
            this.btnZoekenDieren.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoekenDieren.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZoekenDieren.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnZoekenDieren.Location = new System.Drawing.Point(665, 10);
            this.btnZoekenDieren.Name = "btnZoekenDieren";
            this.btnZoekenDieren.Size = new System.Drawing.Size(100, 30);
            this.btnZoekenDieren.TabIndex = 0;
            this.btnZoekenDieren.Text = "Zoeken";
            this.btnZoekenDieren.UseVisualStyleBackColor = true;
            // 
            // txbZoekenDieren
            // 
            this.txbZoekenDieren.BackColor = System.Drawing.Color.White;
            this.txbZoekenDieren.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbZoekenDieren.Location = new System.Drawing.Point(459, 12);
            this.txbZoekenDieren.Name = "txbZoekenDieren";
            this.txbZoekenDieren.Size = new System.Drawing.Size(200, 27);
            this.txbZoekenDieren.TabIndex = 1;
            // 
            // btnVerwijderDieren
            // 
            this.btnVerwijderDieren.BackColor = System.Drawing.Color.Red;
            this.btnVerwijderDieren.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerwijderDieren.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnVerwijderDieren.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerwijderDieren.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerwijderDieren.ForeColor = System.Drawing.Color.White;
            this.btnVerwijderDieren.Location = new System.Drawing.Point(456, 15);
            this.btnVerwijderDieren.Name = "btnVerwijderDieren";
            this.btnVerwijderDieren.Size = new System.Drawing.Size(120, 30);
            this.btnVerwijderDieren.TabIndex = 1;
            this.btnVerwijderDieren.Text = "Verwijderen";
            this.btnVerwijderDieren.UseVisualStyleBackColor = false;
            // 
            // btnBewerkenDieren
            // 
            this.btnBewerkenDieren.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnBewerkenDieren.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBewerkenDieren.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnBewerkenDieren.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBewerkenDieren.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBewerkenDieren.ForeColor = System.Drawing.Color.White;
            this.btnBewerkenDieren.Location = new System.Drawing.Point(330, 15);
            this.btnBewerkenDieren.Name = "btnBewerkenDieren";
            this.btnBewerkenDieren.Size = new System.Drawing.Size(120, 30);
            this.btnBewerkenDieren.TabIndex = 2;
            this.btnBewerkenDieren.Text = "Bewerken";
            this.btnBewerkenDieren.UseVisualStyleBackColor = false;
            // 
            // btnToevoegenDieren
            // 
            this.btnToevoegenDieren.BackColor = System.Drawing.Color.Green;
            this.btnToevoegenDieren.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToevoegenDieren.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnToevoegenDieren.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToevoegenDieren.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToevoegenDieren.ForeColor = System.Drawing.Color.White;
            this.btnToevoegenDieren.Location = new System.Drawing.Point(204, 15);
            this.btnToevoegenDieren.Name = "btnToevoegenDieren";
            this.btnToevoegenDieren.Size = new System.Drawing.Size(120, 30);
            this.btnToevoegenDieren.TabIndex = 3;
            this.btnToevoegenDieren.Text = "Toevoegen";
            this.btnToevoegenDieren.UseVisualStyleBackColor = false;
            this.btnToevoegenDieren.Click += new System.EventHandler(this.btnToevoegenDieren_Click);
            // 
            // ucDieren
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dgvDieren);
            this.Controls.Add(this.pnlFooterDieren);
            this.Controls.Add(this.pnlHeaderDieren);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(800, 610);
            this.MinimumSize = new System.Drawing.Size(800, 610);
            this.Name = "ucDieren";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(800, 610);
            this.pnlHeaderDieren.ResumeLayout(false);
            this.pnlHeaderDieren.PerformLayout();
            this.pnlFooterDieren.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDieren)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeaderDieren;
        private System.Windows.Forms.Label lblHeaderDieren;
        private System.Windows.Forms.Panel pnlFooterDieren;
        private System.Windows.Forms.DataGridView dgvDieren;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnNaam;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSoort;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLeeftijd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnGeslacht;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRas;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnEigenaar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnChipnr;
        private System.Windows.Forms.Button btnZoekenDieren;
        private System.Windows.Forms.TextBox txbZoekenDieren;
        private System.Windows.Forms.Button btnVerwijderDieren;
        private System.Windows.Forms.Button btnToevoegenDieren;
        private System.Windows.Forms.Button btnBewerkenDieren;
    }
}
