namespace PetCareProApp
{
    partial class ucDierenToevoegen
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
            this.pnlHeaderDierenToevoegen = new System.Windows.Forms.Panel();
            this.lblHeaderDierenToevoegen = new System.Windows.Forms.Label();
            this.pnlFooterDierenToevoegen = new System.Windows.Forms.Panel();
            this.pnlHeaderDierenToevoegen.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeaderDierenToevoegen
            // 
            this.pnlHeaderDierenToevoegen.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlHeaderDierenToevoegen.Controls.Add(this.lblHeaderDierenToevoegen);
            this.pnlHeaderDierenToevoegen.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderDierenToevoegen.Location = new System.Drawing.Point(10, 10);
            this.pnlHeaderDierenToevoegen.MaximumSize = new System.Drawing.Size(780, 50);
            this.pnlHeaderDierenToevoegen.MinimumSize = new System.Drawing.Size(780, 50);
            this.pnlHeaderDierenToevoegen.Name = "pnlHeaderDierenToevoegen";
            this.pnlHeaderDierenToevoegen.Size = new System.Drawing.Size(780, 50);
            this.pnlHeaderDierenToevoegen.TabIndex = 0;
            // 
            // lblHeaderDierenToevoegen
            // 
            this.lblHeaderDierenToevoegen.AutoSize = true;
            this.lblHeaderDierenToevoegen.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderDierenToevoegen.Location = new System.Drawing.Point(4, 11);
            this.lblHeaderDierenToevoegen.Name = "lblHeaderDierenToevoegen";
            this.lblHeaderDierenToevoegen.Size = new System.Drawing.Size(222, 28);
            this.lblHeaderDierenToevoegen.TabIndex = 0;
            this.lblHeaderDierenToevoegen.Text = "Nieuw dier toevoegen";
            // 
            // pnlFooterDierenToevoegen
            // 
            this.pnlFooterDierenToevoegen.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlFooterDierenToevoegen.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooterDierenToevoegen.Location = new System.Drawing.Point(10, 540);
            this.pnlFooterDierenToevoegen.Name = "pnlFooterDierenToevoegen";
            this.pnlFooterDierenToevoegen.Size = new System.Drawing.Size(780, 60);
            this.pnlFooterDierenToevoegen.TabIndex = 1;
            // 
            // ucDierenToevoegen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlFooterDierenToevoegen);
            this.Controls.Add(this.pnlHeaderDierenToevoegen);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(800, 610);
            this.MinimumSize = new System.Drawing.Size(800, 610);
            this.Name = "ucDierenToevoegen";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(800, 610);
            this.pnlHeaderDierenToevoegen.ResumeLayout(false);
            this.pnlHeaderDierenToevoegen.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeaderDierenToevoegen;
        private System.Windows.Forms.Label lblHeaderDierenToevoegen;
        private System.Windows.Forms.Panel pnlFooterDierenToevoegen;
    }
}
