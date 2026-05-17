namespace GUI_Softwaretechnik
{
    partial class Posteingang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Posteingang));
            this.BtnZurueck_Posteingang_Menue = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // BtnZurueck_Posteingang_Menue
            // 
            this.BtnZurueck_Posteingang_Menue.Location = new System.Drawing.Point(1252, 731);
            this.BtnZurueck_Posteingang_Menue.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.BtnZurueck_Posteingang_Menue.Name = "BtnZurueck_Posteingang_Menue";
            this.BtnZurueck_Posteingang_Menue.Size = new System.Drawing.Size(150, 44);
            this.BtnZurueck_Posteingang_Menue.TabIndex = 3;
            this.BtnZurueck_Posteingang_Menue.Text = "Zurück";
            this.BtnZurueck_Posteingang_Menue.UseVisualStyleBackColor = true;
            this.BtnZurueck_Posteingang_Menue.Click += new System.EventHandler(this.BtnZurueck_Posteingang_Menue_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(164, 60);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(996, 715);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // Posteingang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(1600, 865);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.BtnZurueck_Posteingang_Menue);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Posteingang";
            this.Text = "Posteingang";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Posteingang_FormClosing);
            this.Load += new System.EventHandler(this.Posteingang_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BtnZurueck_Posteingang_Menue;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}