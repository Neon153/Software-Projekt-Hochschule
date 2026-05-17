namespace GUI_Softwaretechnik
{
    partial class Krankmelden
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Krankmelden));
            this.anfang = new System.Windows.Forms.DateTimePicker();
            this.ende = new System.Windows.Forms.DateTimePicker();
            this.Lanfang = new System.Windows.Forms.Label();
            this.Lende = new System.Windows.Forms.Label();
            this.Bkrankheiteinreichen = new System.Windows.Forms.Button();
            this.KrankheitsTage = new System.Windows.Forms.Label();
            this.back_to_menue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // anfang
            // 
            this.anfang.Font = new System.Drawing.Font("Arial", 12F);
            this.anfang.Location = new System.Drawing.Point(392, 104);
            this.anfang.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.anfang.Name = "anfang";
            this.anfang.Size = new System.Drawing.Size(494, 44);
            this.anfang.TabIndex = 0;
            this.anfang.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // ende
            // 
            this.ende.Font = new System.Drawing.Font("Arial", 12F);
            this.ende.Location = new System.Drawing.Point(392, 214);
            this.ende.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ende.Name = "ende";
            this.ende.Size = new System.Drawing.Size(494, 44);
            this.ende.TabIndex = 1;
            this.ende.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // Lanfang
            // 
            this.Lanfang.AutoSize = true;
            this.Lanfang.Font = new System.Drawing.Font("Arial", 12F);
            this.Lanfang.Location = new System.Drawing.Point(28, 112);
            this.Lanfang.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lanfang.Name = "Lanfang";
            this.Lanfang.Size = new System.Drawing.Size(313, 36);
            this.Lanfang.TabIndex = 2;
            this.Lanfang.Text = "Anfang der Krankheit";
            // 
            // Lende
            // 
            this.Lende.AutoSize = true;
            this.Lende.Font = new System.Drawing.Font("Arial", 12F);
            this.Lende.Location = new System.Drawing.Point(52, 214);
            this.Lende.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lende.Name = "Lende";
            this.Lende.Size = new System.Drawing.Size(285, 36);
            this.Lende.TabIndex = 3;
            this.Lende.Text = "Ende der Krankheit";
            // 
            // Bkrankheiteinreichen
            // 
            this.Bkrankheiteinreichen.Location = new System.Drawing.Point(392, 448);
            this.Bkrankheiteinreichen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Bkrankheiteinreichen.Name = "Bkrankheiteinreichen";
            this.Bkrankheiteinreichen.Size = new System.Drawing.Size(232, 80);
            this.Bkrankheiteinreichen.TabIndex = 4;
            this.Bkrankheiteinreichen.Text = "Einreichen";
            this.Bkrankheiteinreichen.UseVisualStyleBackColor = true;
            this.Bkrankheiteinreichen.Click += new System.EventHandler(this.Bkrankheiteinreichen_Click);
            // 
            // KrankheitsTage
            // 
            this.KrankheitsTage.Font = new System.Drawing.Font("Arial", 12F);
            this.KrankheitsTage.Location = new System.Drawing.Point(386, 302);
            this.KrankheitsTage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.KrankheitsTage.Name = "KrankheitsTage";
            this.KrankheitsTage.Size = new System.Drawing.Size(648, 120);
            this.KrankheitsTage.TabIndex = 5;
            // 
            // back_to_menue
            // 
            this.back_to_menue.Location = new System.Drawing.Point(928, 584);
            this.back_to_menue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.back_to_menue.Name = "back_to_menue";
            this.back_to_menue.Size = new System.Drawing.Size(232, 98);
            this.back_to_menue.TabIndex = 6;
            this.back_to_menue.Text = "Zurück";
            this.back_to_menue.UseVisualStyleBackColor = true;
            this.back_to_menue.Click += new System.EventHandler(this.back_to_menue_Click);
            // 
            // Krankmelden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(1200, 732);
            this.Controls.Add(this.back_to_menue);
            this.Controls.Add(this.KrankheitsTage);
            this.Controls.Add(this.Bkrankheiteinreichen);
            this.Controls.Add(this.Lende);
            this.Controls.Add(this.Lanfang);
            this.Controls.Add(this.ende);
            this.Controls.Add(this.anfang);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Krankmelden";
            this.Text = "Krankmelden";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Krankmelden_FormClosing);
            this.Load += new System.EventHandler(this.Krankmelden_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker anfang;
        private System.Windows.Forms.DateTimePicker ende;
        private System.Windows.Forms.Label Lanfang;
        private System.Windows.Forms.Label Lende;
        private System.Windows.Forms.Button Bkrankheiteinreichen;
        private System.Windows.Forms.Label KrankheitsTage;
        private System.Windows.Forms.Button back_to_menue;
    }
}