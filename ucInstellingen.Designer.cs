namespace PetCareProApp
{
    partial class ucInstellingen
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
            this.pnlHeaderInstellingen = new System.Windows.Forms.Panel();
            this.lblHeaderInstellingen = new System.Windows.Forms.Label();
            this.pnlContentInstellingen = new System.Windows.Forms.Panel();
            this.pnlHeaderInstellingen.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeaderInstellingen
            // 
            this.pnlHeaderInstellingen.Controls.Add(this.lblHeaderInstellingen);
            this.pnlHeaderInstellingen.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderInstellingen.Location = new System.Drawing.Point(0, 0);
            this.pnlHeaderInstellingen.Name = "pnlHeaderInstellingen";
            this.pnlHeaderInstellingen.Size = new System.Drawing.Size(800, 40);
            this.pnlHeaderInstellingen.TabIndex = 0;
            // 
            // lblHeaderInstellingen
            // 
            this.lblHeaderInstellingen.AutoSize = true;
            this.lblHeaderInstellingen.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderInstellingen.Location = new System.Drawing.Point(3, 5);
            this.lblHeaderInstellingen.Name = "lblHeaderInstellingen";
            this.lblHeaderInstellingen.Size = new System.Drawing.Size(141, 31);
            this.lblHeaderInstellingen.TabIndex = 1;
            this.lblHeaderInstellingen.Text = "Instellingen";
            // 
            // pnlContentInstellingen
            // 
            this.pnlContentInstellingen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContentInstellingen.Location = new System.Drawing.Point(0, 40);
            this.pnlContentInstellingen.Name = "pnlContentInstellingen";
            this.pnlContentInstellingen.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.pnlContentInstellingen.Size = new System.Drawing.Size(800, 570);
            this.pnlContentInstellingen.TabIndex = 1;
            // 
            // ucInstellingen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlContentInstellingen);
            this.Controls.Add(this.pnlHeaderInstellingen);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(800, 610);
            this.MinimumSize = new System.Drawing.Size(800, 610);
            this.Name = "ucInstellingen";
            this.Size = new System.Drawing.Size(800, 610);
            this.pnlHeaderInstellingen.ResumeLayout(false);
            this.pnlHeaderInstellingen.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeaderInstellingen;
        private System.Windows.Forms.Label lblHeaderInstellingen;
        private System.Windows.Forms.Panel pnlContentInstellingen;
    }
}
