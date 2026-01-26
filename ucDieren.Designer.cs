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
            this.pnlHeaderDieren = new System.Windows.Forms.Panel();
            this.lblHeaderDieren = new System.Windows.Forms.Label();
            this.pnlContentDieren = new System.Windows.Forms.Panel();
            this.pnlHeaderDieren.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeaderDieren
            // 
            this.pnlHeaderDieren.BackColor = System.Drawing.Color.White;
            this.pnlHeaderDieren.Controls.Add(this.lblHeaderDieren);
            this.pnlHeaderDieren.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderDieren.Location = new System.Drawing.Point(0, 0);
            this.pnlHeaderDieren.MaximumSize = new System.Drawing.Size(800, 40);
            this.pnlHeaderDieren.MinimumSize = new System.Drawing.Size(800, 40);
            this.pnlHeaderDieren.Name = "pnlHeaderDieren";
            this.pnlHeaderDieren.Size = new System.Drawing.Size(800, 40);
            this.pnlHeaderDieren.TabIndex = 0;
            // 
            // lblHeaderDieren
            // 
            this.lblHeaderDieren.AutoSize = true;
            this.lblHeaderDieren.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderDieren.Location = new System.Drawing.Point(3, 5);
            this.lblHeaderDieren.Name = "lblHeaderDieren";
            this.lblHeaderDieren.Size = new System.Drawing.Size(85, 31);
            this.lblHeaderDieren.TabIndex = 1;
            this.lblHeaderDieren.Text = "Dieren";
            // 
            // pnlContentDieren
            // 
            this.pnlContentDieren.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContentDieren.Location = new System.Drawing.Point(0, 40);
            this.pnlContentDieren.Name = "pnlContentDieren";
            this.pnlContentDieren.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.pnlContentDieren.Size = new System.Drawing.Size(800, 570);
            this.pnlContentDieren.TabIndex = 1;
            // 
            // ucDieren
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlContentDieren);
            this.Controls.Add(this.pnlHeaderDieren);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(800, 610);
            this.MinimumSize = new System.Drawing.Size(800, 610);
            this.Name = "ucDieren";
            this.Size = new System.Drawing.Size(800, 610);
            this.pnlHeaderDieren.ResumeLayout(false);
            this.pnlHeaderDieren.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeaderDieren;
        private System.Windows.Forms.Label lblHeaderDieren;
        private System.Windows.Forms.Panel pnlContentDieren;
    }
}
