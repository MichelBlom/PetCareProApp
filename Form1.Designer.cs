namespace PetCareProApp
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pnlNavigation = new System.Windows.Forms.Panel();
            this.lblVersieMain = new System.Windows.Forms.Label();
            this.pnlSelectionIndicator = new System.Windows.Forms.Panel();
            this.btnInstellingen = new System.Windows.Forms.Button();
            this.btnKalender = new System.Windows.Forms.Button();
            this.btnEigenaren = new System.Windows.Forms.Button();
            this.btnDieren = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlHeader.SuspendLayout();
            this.pnlNavigation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.RoyalBlue;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHeader.Controls.Add(this.btnClose);
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.MaximumSize = new System.Drawing.Size(0, 30);
            this.pnlHeader.MinimumSize = new System.Drawing.Size(0, 30);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1000, 30);
            this.pnlHeader.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(968, 0);
            this.btnClose.MaximumSize = new System.Drawing.Size(30, 30);
            this.btnClose.MinimumSize = new System.Drawing.Size(30, 30);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(3, 4);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(98, 23);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "PetCarePro";
            // 
            // pnlNavigation
            // 
            this.pnlNavigation.BackColor = System.Drawing.Color.LightGray;
            this.pnlNavigation.Controls.Add(this.lblVersieMain);
            this.pnlNavigation.Controls.Add(this.pnlSelectionIndicator);
            this.pnlNavigation.Controls.Add(this.btnInstellingen);
            this.pnlNavigation.Controls.Add(this.btnKalender);
            this.pnlNavigation.Controls.Add(this.btnEigenaren);
            this.pnlNavigation.Controls.Add(this.btnDieren);
            this.pnlNavigation.Controls.Add(this.btnDashboard);
            this.pnlNavigation.Controls.Add(this.pictureBox1);
            this.pnlNavigation.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlNavigation.Location = new System.Drawing.Point(0, 30);
            this.pnlNavigation.MaximumSize = new System.Drawing.Size(200, 610);
            this.pnlNavigation.MinimumSize = new System.Drawing.Size(200, 610);
            this.pnlNavigation.Name = "pnlNavigation";
            this.pnlNavigation.Size = new System.Drawing.Size(200, 610);
            this.pnlNavigation.TabIndex = 1;
            // 
            // lblVersieMain
            // 
            this.lblVersieMain.AutoSize = true;
            this.lblVersieMain.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersieMain.Location = new System.Drawing.Point(61, 582);
            this.lblVersieMain.Name = "lblVersieMain";
            this.lblVersieMain.Size = new System.Drawing.Size(69, 17);
            this.lblVersieMain.TabIndex = 2;
            this.lblVersieMain.Text = "Versie 1.03";
            // 
            // pnlSelectionIndicator
            // 
            this.pnlSelectionIndicator.BackColor = System.Drawing.Color.RoyalBlue;
            this.pnlSelectionIndicator.Location = new System.Drawing.Point(0, 163);
            this.pnlSelectionIndicator.Name = "pnlSelectionIndicator";
            this.pnlSelectionIndicator.Size = new System.Drawing.Size(8, 40);
            this.pnlSelectionIndicator.TabIndex = 0;
            // 
            // btnInstellingen
            // 
            this.btnInstellingen.BackColor = System.Drawing.Color.LightGray;
            this.btnInstellingen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInstellingen.FlatAppearance.BorderSize = 0;
            this.btnInstellingen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstellingen.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInstellingen.Image = global::PetCareProApp.Properties.Resources.customize;
            this.btnInstellingen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInstellingen.Location = new System.Drawing.Point(0, 347);
            this.btnInstellingen.Margin = new System.Windows.Forms.Padding(0);
            this.btnInstellingen.Name = "btnInstellingen";
            this.btnInstellingen.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnInstellingen.Size = new System.Drawing.Size(200, 40);
            this.btnInstellingen.TabIndex = 1;
            this.btnInstellingen.Text = "  INSTELLINGEN";
            this.btnInstellingen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInstellingen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInstellingen.UseVisualStyleBackColor = false;
            this.btnInstellingen.Click += new System.EventHandler(this.btnInstellingen_Click);
            // 
            // btnKalender
            // 
            this.btnKalender.BackColor = System.Drawing.Color.LightGray;
            this.btnKalender.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKalender.FlatAppearance.BorderSize = 0;
            this.btnKalender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKalender.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKalender.Image = global::PetCareProApp.Properties.Resources.calendar;
            this.btnKalender.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKalender.Location = new System.Drawing.Point(0, 301);
            this.btnKalender.Margin = new System.Windows.Forms.Padding(0);
            this.btnKalender.Name = "btnKalender";
            this.btnKalender.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnKalender.Size = new System.Drawing.Size(200, 40);
            this.btnKalender.TabIndex = 1;
            this.btnKalender.Text = "  KALENDER";
            this.btnKalender.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKalender.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnKalender.UseVisualStyleBackColor = false;
            this.btnKalender.Click += new System.EventHandler(this.btnKalender_Click);
            // 
            // btnEigenaren
            // 
            this.btnEigenaren.BackColor = System.Drawing.Color.LightGray;
            this.btnEigenaren.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEigenaren.FlatAppearance.BorderSize = 0;
            this.btnEigenaren.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEigenaren.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEigenaren.Image = global::PetCareProApp.Properties.Resources.employees_woman_man;
            this.btnEigenaren.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEigenaren.Location = new System.Drawing.Point(0, 255);
            this.btnEigenaren.Margin = new System.Windows.Forms.Padding(0);
            this.btnEigenaren.Name = "btnEigenaren";
            this.btnEigenaren.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnEigenaren.Size = new System.Drawing.Size(200, 40);
            this.btnEigenaren.TabIndex = 1;
            this.btnEigenaren.Text = "  EIGENAREN";
            this.btnEigenaren.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEigenaren.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEigenaren.UseVisualStyleBackColor = false;
            this.btnEigenaren.Click += new System.EventHandler(this.btnEigenaren_Click);
            // 
            // btnDieren
            // 
            this.btnDieren.BackColor = System.Drawing.Color.LightGray;
            this.btnDieren.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDieren.FlatAppearance.BorderSize = 0;
            this.btnDieren.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDieren.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDieren.Image = global::PetCareProApp.Properties.Resources.paw;
            this.btnDieren.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDieren.Location = new System.Drawing.Point(0, 209);
            this.btnDieren.Margin = new System.Windows.Forms.Padding(0);
            this.btnDieren.Name = "btnDieren";
            this.btnDieren.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnDieren.Size = new System.Drawing.Size(200, 40);
            this.btnDieren.TabIndex = 1;
            this.btnDieren.Text = "  DIEREN";
            this.btnDieren.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDieren.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDieren.UseVisualStyleBackColor = false;
            this.btnDieren.Click += new System.EventHandler(this.btnDieren_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.LightGray;
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.Image = global::PetCareProApp.Properties.Resources.home__4_;
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Location = new System.Drawing.Point(0, 163);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(0);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(200, 40);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "  DASHBOARD";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PetCareProApp.Properties.Resources.petcarepro4;
            this.pictureBox1.Location = new System.Drawing.Point(-49, -18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(296, 209);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pnlMain
            // 
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(200, 30);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(800, 610);
            this.pnlMain.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 640);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlNavigation);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(1000, 640);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1000, 640);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PetCarePro";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlNavigation.ResumeLayout(false);
            this.pnlNavigation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlNavigation;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnInstellingen;
        private System.Windows.Forms.Button btnKalender;
        private System.Windows.Forms.Button btnEigenaren;
        private System.Windows.Forms.Button btnDieren;
        private System.Windows.Forms.Panel pnlSelectionIndicator;
        private System.Windows.Forms.Label lblVersieMain;
    }
}

