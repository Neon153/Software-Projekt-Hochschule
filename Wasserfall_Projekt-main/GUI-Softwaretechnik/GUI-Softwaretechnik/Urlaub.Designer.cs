namespace GUI_Softwaretechnik
{
    partial class Urlaub
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Urlaub));
            this.backtomenue = new System.Windows.Forms.Button();
            this.anfang = new System.Windows.Forms.DateTimePicker();
            this.ende = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnBeantragen = new System.Windows.Forms.Button();
            this.Lbl_Info = new System.Windows.Forms.Label();
            this.RadGleitzeit = new System.Windows.Forms.RadioButton();
            this.RadUrlaubstage = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // backtomenue
            // 
            this.backtomenue.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backtomenue.Location = new System.Drawing.Point(952, 558);
            this.backtomenue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.backtomenue.Name = "backtomenue";
            this.backtomenue.Size = new System.Drawing.Size(188, 73);
            this.backtomenue.TabIndex = 1;
            this.backtomenue.Text = "Zurück";
            this.backtomenue.UseVisualStyleBackColor = true;
            this.backtomenue.Click += new System.EventHandler(this.button1_Click);
            // 
            // anfang
            // 
            this.anfang.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.anfang.Location = new System.Drawing.Point(186, 212);
            this.anfang.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.anfang.Name = "anfang";
            this.anfang.Size = new System.Drawing.Size(530, 44);
            this.anfang.TabIndex = 2;
            // 
            // ende
            // 
            this.ende.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ende.Location = new System.Drawing.Point(186, 350);
            this.ende.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ende.Name = "ende";
            this.ende.Size = new System.Drawing.Size(530, 44);
            this.ende.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(180, 158);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(334, 36);
            this.label1.TabIndex = 4;
            this.label1.Text = "Urlaub beantragen von";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(180, 288);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 36);
            this.label2.TabIndex = 5;
            this.label2.Text = "bis";
            // 
            // BtnBeantragen
            // 
            this.BtnBeantragen.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBeantragen.Location = new System.Drawing.Point(292, 558);
            this.BtnBeantragen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnBeantragen.Name = "BtnBeantragen";
            this.BtnBeantragen.Size = new System.Drawing.Size(216, 79);
            this.BtnBeantragen.TabIndex = 6;
            this.BtnBeantragen.Text = "Beantragen";
            this.BtnBeantragen.UseVisualStyleBackColor = true;
            this.BtnBeantragen.Click += new System.EventHandler(this.BtnBantragen_Click);
            // 
            // Lbl_Info
            // 
            this.Lbl_Info.AutoSize = true;
            this.Lbl_Info.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Info.Location = new System.Drawing.Point(180, 458);
            this.Lbl_Info.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Lbl_Info.Name = "Lbl_Info";
            this.Lbl_Info.Size = new System.Drawing.Size(98, 36);
            this.Lbl_Info.TabIndex = 7;
            this.Lbl_Info.Text = "label3";
            // 
            // RadGleitzeit
            // 
            this.RadGleitzeit.AutoSize = true;
            this.RadGleitzeit.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadGleitzeit.Location = new System.Drawing.Point(828, 217);
            this.RadGleitzeit.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.RadGleitzeit.Name = "RadGleitzeit";
            this.RadGleitzeit.Size = new System.Drawing.Size(159, 40);
            this.RadGleitzeit.TabIndex = 8;
            this.RadGleitzeit.TabStop = true;
            this.RadGleitzeit.Text = "Gleitzeit";
            this.RadGleitzeit.UseVisualStyleBackColor = true;
            // 
            // RadUrlaubstage
            // 
            this.RadUrlaubstage.AutoSize = true;
            this.RadUrlaubstage.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadUrlaubstage.Location = new System.Drawing.Point(828, 358);
            this.RadUrlaubstage.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.RadUrlaubstage.Name = "RadUrlaubstage";
            this.RadUrlaubstage.Size = new System.Drawing.Size(215, 40);
            this.RadUrlaubstage.TabIndex = 9;
            this.RadUrlaubstage.TabStop = true;
            this.RadUrlaubstage.Text = "Urlaubstage";
            this.RadUrlaubstage.UseVisualStyleBackColor = true;
            // 
            // Urlaub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(1200, 704);
            this.Controls.Add(this.RadUrlaubstage);
            this.Controls.Add(this.RadGleitzeit);
            this.Controls.Add(this.Lbl_Info);
            this.Controls.Add(this.BtnBeantragen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ende);
            this.Controls.Add(this.anfang);
            this.Controls.Add(this.backtomenue);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Urlaub";
            this.Text = "Urlaub";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Urlaub_FormClosing);
            this.Load += new System.EventHandler(this.Urlaub_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button backtomenue;
        private System.Windows.Forms.DateTimePicker anfang;
        private System.Windows.Forms.DateTimePicker ende;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnBeantragen;
        private System.Windows.Forms.Label Lbl_Info;
        private System.Windows.Forms.RadioButton RadGleitzeit;
        private System.Windows.Forms.RadioButton RadUrlaubstage;
    }
}