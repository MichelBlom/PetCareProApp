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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlHeaderInstellingen.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeaderInstellingen
            // 
            this.pnlHeaderInstellingen.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlHeaderInstellingen.Controls.Add(this.lblHeaderInstellingen);
            this.pnlHeaderInstellingen.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderInstellingen.Location = new System.Drawing.Point(10, 10);
            this.pnlHeaderInstellingen.Name = "pnlHeaderInstellingen";
            this.pnlHeaderInstellingen.Size = new System.Drawing.Size(780, 50);
            this.pnlHeaderInstellingen.TabIndex = 0;
            // 
            // lblHeaderInstellingen
            // 
            this.lblHeaderInstellingen.AutoSize = true;
            this.lblHeaderInstellingen.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderInstellingen.Location = new System.Drawing.Point(8, 10);
            this.lblHeaderInstellingen.Name = "lblHeaderInstellingen";
            this.lblHeaderInstellingen.Size = new System.Drawing.Size(141, 31);
            this.lblHeaderInstellingen.TabIndex = 1;
            this.lblHeaderInstellingen.Text = "Instellingen";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(10, 540);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(780, 60);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(10, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(780, 480);
            this.panel2.TabIndex = 2;
            // 
            // ucInstellingen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlHeaderInstellingen);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(800, 610);
            this.MinimumSize = new System.Drawing.Size(800, 610);
            this.Name = "ucInstellingen";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(800, 610);
            this.pnlHeaderInstellingen.ResumeLayout(false);
            this.pnlHeaderInstellingen.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeaderInstellingen;
        private System.Windows.Forms.Label lblHeaderInstellingen;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}
