namespace GUI_Softwaretechnik
{
    partial class Korrektur
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Korrektur));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.back_to_ein_und_ausstemplen = new System.Windows.Forms.Button();
            this.anfangszeit = new System.Windows.Forms.TextBox();
            this.endzeit = new System.Windows.Forms.TextBox();
            this.einreichen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.workingtime1 = new System.Windows.Forms.Label();
            this.korrektTime = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // back_to_ein_und_ausstemplen
            // 
            this.back_to_ein_und_ausstemplen.Location = new System.Drawing.Point(972, 612);
            this.back_to_ein_und_ausstemplen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.back_to_ein_und_ausstemplen.Name = "back_to_ein_und_ausstemplen";
            this.back_to_ein_und_ausstemplen.Size = new System.Drawing.Size(184, 62);
            this.back_to_ein_und_ausstemplen.TabIndex = 4;
            this.back_to_ein_und_ausstemplen.Text = "Zurück";
            this.back_to_ein_und_ausstemplen.UseVisualStyleBackColor = true;
            this.back_to_ein_und_ausstemplen.Click += new System.EventHandler(this.back_to_ein_und_ausstemplen_Click);
            // 
            // anfangszeit
            // 
            this.anfangszeit.Font = new System.Drawing.Font("Arial", 12F);
            this.anfangszeit.Location = new System.Drawing.Point(436, 69);
            this.anfangszeit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.anfangszeit.Multiline = true;
            this.anfangszeit.Name = "anfangszeit";
            this.anfangszeit.Size = new System.Drawing.Size(236, 62);
            this.anfangszeit.TabIndex = 8;
            // 
            // endzeit
            // 
            this.endzeit.Font = new System.Drawing.Font("Arial", 12F);
            this.endzeit.Location = new System.Drawing.Point(436, 175);
            this.endzeit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.endzeit.Multiline = true;
            this.endzeit.Name = "endzeit";
            this.endzeit.Size = new System.Drawing.Size(236, 62);
            this.endzeit.TabIndex = 9;
            // 
            // einreichen
            // 
            this.einreichen.Location = new System.Drawing.Point(436, 248);
            this.einreichen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.einreichen.Name = "einreichen";
            this.einreichen.Size = new System.Drawing.Size(238, 88);
            this.einreichen.TabIndex = 10;
            this.einreichen.Text = "Einreichen";
            this.einreichen.UseVisualStyleBackColor = true;
            this.einreichen.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10F);
            this.label1.Location = new System.Drawing.Point(272, 85);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 32);
            this.label1.TabIndex = 11;
            this.label1.Text = "Anfangszeit";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10F);
            this.label2.Location = new System.Drawing.Point(320, 187);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 32);
            this.label2.TabIndex = 12;
            this.label2.Text = "Endzeit";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // workingtime1
            // 
            this.workingtime1.AutoSize = true;
            this.workingtime1.Font = new System.Drawing.Font("Arial", 12F);
            this.workingtime1.Location = new System.Drawing.Point(504, 340);
            this.workingtime1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.workingtime1.Name = "workingtime1";
            this.workingtime1.Size = new System.Drawing.Size(0, 36);
            this.workingtime1.TabIndex = 13;
            // 
            // korrektTime
            // 
            this.korrektTime.Location = new System.Drawing.Point(436, 25);
            this.korrektTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.korrektTime.Name = "korrektTime";
            this.korrektTime.Size = new System.Drawing.Size(236, 31);
            this.korrektTime.TabIndex = 14;
            // 
            // Korrektur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(1200, 704);
            this.Controls.Add(this.korrektTime);
            this.Controls.Add(this.workingtime1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.einreichen);
            this.Controls.Add(this.endzeit);
            this.Controls.Add(this.anfangszeit);
            this.Controls.Add(this.back_to_ein_und_ausstemplen);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Korrektur";
            this.Text = "korrektur";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Korrektur_FormClosing);
            this.Load += new System.EventHandler(this.Korrektur_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button back_to_ein_und_ausstemplen;
        private System.Windows.Forms.TextBox anfangszeit;
        private System.Windows.Forms.TextBox endzeit;
        private System.Windows.Forms.Button einreichen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label workingtime1;
        private System.Windows.Forms.DateTimePicker korrektTime;
    }
}