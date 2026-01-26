namespace PetCareProApp
{
    partial class ucDashboard
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
            this.pnlUcHeaderDashboard = new System.Windows.Forms.Panel();
            this.lblHeaderUcDashboard = new System.Windows.Forms.Label();
            this.pnlContentDashboard = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.pnlUcHeaderDashboard.SuspendLayout();
            this.pnlContentDashboard.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlUcHeaderDashboard
            // 
            this.pnlUcHeaderDashboard.BackColor = System.Drawing.Color.White;
            this.pnlUcHeaderDashboard.Controls.Add(this.lblHeaderUcDashboard);
            this.pnlUcHeaderDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUcHeaderDashboard.Location = new System.Drawing.Point(0, 0);
            this.pnlUcHeaderDashboard.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlUcHeaderDashboard.Name = "pnlUcHeaderDashboard";
            this.pnlUcHeaderDashboard.Size = new System.Drawing.Size(800, 40);
            this.pnlUcHeaderDashboard.TabIndex = 0;
            // 
            // lblHeaderUcDashboard
            // 
            this.lblHeaderUcDashboard.AutoSize = true;
            this.lblHeaderUcDashboard.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderUcDashboard.Location = new System.Drawing.Point(4, 5);
            this.lblHeaderUcDashboard.Name = "lblHeaderUcDashboard";
            this.lblHeaderUcDashboard.Size = new System.Drawing.Size(130, 31);
            this.lblHeaderUcDashboard.TabIndex = 0;
            this.lblHeaderUcDashboard.Text = "Dashboard";
            // 
            // pnlContentDashboard
            // 
            this.pnlContentDashboard.Controls.Add(this.button3);
            this.pnlContentDashboard.Controls.Add(this.button2);
            this.pnlContentDashboard.Controls.Add(this.button1);
            this.pnlContentDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContentDashboard.Location = new System.Drawing.Point(0, 40);
            this.pnlContentDashboard.MaximumSize = new System.Drawing.Size(800, 570);
            this.pnlContentDashboard.MinimumSize = new System.Drawing.Size(800, 570);
            this.pnlContentDashboard.Name = "pnlContentDashboard";
            this.pnlContentDashboard.Size = new System.Drawing.Size(800, 570);
            this.pnlContentDashboard.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightGray;
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightGray;
            this.button2.Location = new System.Drawing.Point(3, 544);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.LightGray;
            this.button3.Location = new System.Drawing.Point(722, 544);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // ucDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlContentDashboard);
            this.Controls.Add(this.pnlUcHeaderDashboard);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(800, 610);
            this.MinimumSize = new System.Drawing.Size(800, 610);
            this.Name = "ucDashboard";
            this.Size = new System.Drawing.Size(800, 610);
            this.pnlUcHeaderDashboard.ResumeLayout(false);
            this.pnlUcHeaderDashboard.PerformLayout();
            this.pnlContentDashboard.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlUcHeaderDashboard;
        private System.Windows.Forms.Label lblHeaderUcDashboard;
        private System.Windows.Forms.Panel pnlContentDashboard;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
    }
}
