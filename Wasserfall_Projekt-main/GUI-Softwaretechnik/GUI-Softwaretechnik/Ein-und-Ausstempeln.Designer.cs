namespace GUI_Softwaretechnik
{
    partial class ein_und_ausstempeln
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ein_und_ausstempeln));
            this.back1 = new System.Windows.Forms.Button();
            this.anfangszeit = new System.Windows.Forms.TextBox();
            this.endzeit = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.workingtime1 = new System.Windows.Forms.Label();
            this.show_Date = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // back1
            // 
            this.back1.Location = new System.Drawing.Point(918, 563);
            this.back1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.back1.Name = "back1";
            this.back1.Size = new System.Drawing.Size(224, 83);
            this.back1.TabIndex = 0;
            this.back1.Text = "Zurück";
            this.back1.UseVisualStyleBackColor = true;
            this.back1.Click += new System.EventHandler(this.back1_Click);
            // 
            // anfangszeit
            // 
            this.anfangszeit.Font = new System.Drawing.Font("Arial", 12F);
            this.anfangszeit.Location = new System.Drawing.Point(450, 87);
            this.anfangszeit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.anfangszeit.Multiline = true;
            this.anfangszeit.Name = "anfangszeit";
            this.anfangszeit.Size = new System.Drawing.Size(236, 62);
            this.anfangszeit.TabIndex = 1;
            this.anfangszeit.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // endzeit
            // 
            this.endzeit.Font = new System.Drawing.Font("Arial", 12F);
            this.endzeit.Location = new System.Drawing.Point(450, 187);
            this.endzeit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.endzeit.Multiline = true;
            this.endzeit.Name = "endzeit";
            this.endzeit.Size = new System.Drawing.Size(236, 62);
            this.endzeit.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10F);
            this.label1.Location = new System.Drawing.Point(272, 96);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Anfangszeit";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10F);
            this.label2.Location = new System.Drawing.Point(320, 196);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 32);
            this.label2.TabIndex = 4;
            this.label2.Text = "Endzeit";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(450, 260);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(236, 88);
            this.button1.TabIndex = 5;
            this.button1.Text = "Einreichen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(80, 563);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(224, 88);
            this.button2.TabIndex = 6;
            this.button2.Text = "Korrigieren";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // workingtime1
            // 
            this.workingtime1.AutoSize = true;
            this.workingtime1.Font = new System.Drawing.Font("Arial", 12F);
            this.workingtime1.Location = new System.Drawing.Point(518, 354);
            this.workingtime1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.workingtime1.Name = "workingtime1";
            this.workingtime1.Size = new System.Drawing.Size(0, 36);
            this.workingtime1.TabIndex = 7;
            // 
            // show_Date
            // 
            this.show_Date.AutoSize = true;
            this.show_Date.Font = new System.Drawing.Font("Arial", 12F);
            this.show_Date.Location = new System.Drawing.Point(442, 13);
            this.show_Date.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.show_Date.Name = "show_Date";
            this.show_Date.Size = new System.Drawing.Size(99, 36);
            this.show_Date.TabIndex = 8;
            this.show_Date.Text = "[Date]";
            // 
            // ein_und_ausstempeln
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(1200, 704);
            this.Controls.Add(this.show_Date);
            this.Controls.Add(this.workingtime1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.endzeit);
            this.Controls.Add(this.anfangszeit);
            this.Controls.Add(this.back1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ein_und_ausstempeln";
            this.Text = "Ein und Ausstempeln";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ein_und_ausstempeln_FormClosing);
            this.Load += new System.EventHandler(this.ein_und_ausstempeln_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button back1;
        private System.Windows.Forms.TextBox anfangszeit;
        private System.Windows.Forms.TextBox endzeit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label workingtime1;
        private System.Windows.Forms.Label show_Date;
    }
}