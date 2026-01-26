namespace PetCareProApp
{
    partial class ucKalender
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
            this.pnlHeaderKalender = new System.Windows.Forms.Panel();
            this.lblHeaderKalender = new System.Windows.Forms.Label();
            this.pnlContentKalender = new System.Windows.Forms.Panel();
            this.pnlHeaderKalender.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeaderKalender
            // 
            this.pnlHeaderKalender.Controls.Add(this.lblHeaderKalender);
            this.pnlHeaderKalender.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderKalender.Location = new System.Drawing.Point(0, 0);
            this.pnlHeaderKalender.MaximumSize = new System.Drawing.Size(800, 40);
            this.pnlHeaderKalender.MinimumSize = new System.Drawing.Size(800, 40);
            this.pnlHeaderKalender.Name = "pnlHeaderKalender";
            this.pnlHeaderKalender.Size = new System.Drawing.Size(800, 40);
            this.pnlHeaderKalender.TabIndex = 0;
            // 
            // lblHeaderKalender
            // 
            this.lblHeaderKalender.AutoSize = true;
            this.lblHeaderKalender.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderKalender.Location = new System.Drawing.Point(3, 5);
            this.lblHeaderKalender.Name = "lblHeaderKalender";
            this.lblHeaderKalender.Size = new System.Drawing.Size(109, 31);
            this.lblHeaderKalender.TabIndex = 0;
            this.lblHeaderKalender.Text = "Kalender";
            // 
            // pnlContentKalender
            // 
            this.pnlContentKalender.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContentKalender.Location = new System.Drawing.Point(0, 40);
            this.pnlContentKalender.Name = "pnlContentKalender";
            this.pnlContentKalender.Size = new System.Drawing.Size(800, 570);
            this.pnlContentKalender.TabIndex = 1;
            // 
            // ucKalender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlContentKalender);
            this.Controls.Add(this.pnlHeaderKalender);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(800, 610);
            this.MinimumSize = new System.Drawing.Size(800, 610);
            this.Name = "ucKalender";
            this.Size = new System.Drawing.Size(800, 610);
            this.pnlHeaderKalender.ResumeLayout(false);
            this.pnlHeaderKalender.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeaderKalender;
        private System.Windows.Forms.Label lblHeaderKalender;
        private System.Windows.Forms.Panel pnlContentKalender;
    }
}
