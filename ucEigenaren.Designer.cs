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
            this.pnlHeaderEIgenaren = new System.Windows.Forms.Panel();
            this.lblHeaderEigenaren = new System.Windows.Forms.Label();
            this.pnlContentigenaren = new System.Windows.Forms.Panel();
            this.pnlHeaderEIgenaren.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeaderEIgenaren
            // 
            this.pnlHeaderEIgenaren.Controls.Add(this.lblHeaderEigenaren);
            this.pnlHeaderEIgenaren.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderEIgenaren.Location = new System.Drawing.Point(0, 0);
            this.pnlHeaderEIgenaren.Name = "pnlHeaderEIgenaren";
            this.pnlHeaderEIgenaren.Size = new System.Drawing.Size(800, 40);
            this.pnlHeaderEIgenaren.TabIndex = 0;
            // 
            // lblHeaderEigenaren
            // 
            this.lblHeaderEigenaren.AutoSize = true;
            this.lblHeaderEigenaren.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderEigenaren.Location = new System.Drawing.Point(3, 5);
            this.lblHeaderEigenaren.Name = "lblHeaderEigenaren";
            this.lblHeaderEigenaren.Size = new System.Drawing.Size(120, 31);
            this.lblHeaderEigenaren.TabIndex = 0;
            this.lblHeaderEigenaren.Text = "Eigenaren";
            // 
            // pnlContentigenaren
            // 
            this.pnlContentigenaren.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContentigenaren.Location = new System.Drawing.Point(0, 40);
            this.pnlContentigenaren.Name = "pnlContentigenaren";
            this.pnlContentigenaren.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.pnlContentigenaren.Size = new System.Drawing.Size(800, 570);
            this.pnlContentigenaren.TabIndex = 1;
            // 
            // ucEigenaren
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlContentigenaren);
            this.Controls.Add(this.pnlHeaderEIgenaren);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(800, 610);
            this.MinimumSize = new System.Drawing.Size(800, 610);
            this.Name = "ucEigenaren";
            this.Size = new System.Drawing.Size(800, 610);
            this.pnlHeaderEIgenaren.ResumeLayout(false);
            this.pnlHeaderEIgenaren.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeaderEIgenaren;
        private System.Windows.Forms.Label lblHeaderEigenaren;
        private System.Windows.Forms.Panel pnlContentigenaren;
    }
}
