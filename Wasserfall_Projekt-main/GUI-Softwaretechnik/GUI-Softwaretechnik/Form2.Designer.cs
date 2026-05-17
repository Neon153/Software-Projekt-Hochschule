namespace GUI_Softwaretechnik
{
    partial class Menue_Mitarbeiter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menue_Mitarbeiter));
            this.abmelden = new System.Windows.Forms.Button();
            this.time = new System.Windows.Forms.Button();
            this.urlaub = new System.Windows.Forms.Button();
            this.krank = new System.Windows.Forms.Button();
            this.posteingang = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Lbl_Infos_time = new System.Windows.Forms.Label();
            this.Pnl_Leg_Url_bea = new System.Windows.Forms.Panel();
            this.Lbl_Leg_Url_bea = new System.Windows.Forms.Label();
            this.Lbl_Leg_Url_gen = new System.Windows.Forms.Label();
            this.Pnl_Leg_Url_gen = new System.Windows.Forms.Panel();
            this.Lbl_Leg_Kra = new System.Windows.Forms.Label();
            this.Pnl_Leg_Kra = new System.Windows.Forms.Panel();
            this.Lbl_Leg_Gleit = new System.Windows.Forms.Label();
            this.Pnl_Leg_Gleit = new System.Windows.Forms.Panel();
            this.Kalender_Menu_Mitarbeiter = new Forms_Zeitmanagement.Kalender();
            this.progressBarGleitzeit = new System.Windows.Forms.ProgressBar();
            this.progressBarUrlaub = new System.Windows.Forms.ProgressBar();
            this.Btn_Mit_Suchen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // abmelden
            // 
            this.abmelden.Location = new System.Drawing.Point(756, 527);
            this.abmelden.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.abmelden.Name = "abmelden";
            this.abmelden.Size = new System.Drawing.Size(105, 37);
            this.abmelden.TabIndex = 0;
            this.abmelden.Text = "Abmelden";
            this.abmelden.UseVisualStyleBackColor = true;
            this.abmelden.Click += new System.EventHandler(this.abmelden_Click);
            // 
            // time
            // 
            this.time.Location = new System.Drawing.Point(35, 23);
            this.time.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(151, 50);
            this.time.TabIndex = 1;
            this.time.Text = "Ein und Ausstempeln";
            this.time.UseVisualStyleBackColor = true;
            this.time.Click += new System.EventHandler(this.time_Click);
            // 
            // urlaub
            // 
            this.urlaub.Location = new System.Drawing.Point(35, 117);
            this.urlaub.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.urlaub.Name = "urlaub";
            this.urlaub.Size = new System.Drawing.Size(151, 50);
            this.urlaub.TabIndex = 2;
            this.urlaub.Text = "Urlaub Beantragen";
            this.urlaub.UseVisualStyleBackColor = true;
            this.urlaub.Click += new System.EventHandler(this.urlaub_Click);
            // 
            // krank
            // 
            this.krank.Location = new System.Drawing.Point(35, 211);
            this.krank.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.krank.Name = "krank";
            this.krank.Size = new System.Drawing.Size(151, 50);
            this.krank.TabIndex = 3;
            this.krank.Text = "Krankmelden";
            this.krank.UseVisualStyleBackColor = true;
            this.krank.Click += new System.EventHandler(this.krank_Click);
            // 
            // posteingang
            // 
            this.posteingang.Location = new System.Drawing.Point(35, 305);
            this.posteingang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.posteingang.Name = "posteingang";
            this.posteingang.Size = new System.Drawing.Size(151, 50);
            this.posteingang.TabIndex = 4;
            this.posteingang.Text = "Posteingang";
            this.posteingang.UseVisualStyleBackColor = true;
            this.posteingang.Click += new System.EventHandler(this.posteingang_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 14.25F);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(607, 364);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 22);
            this.label10.TabIndex = 30;
            this.label10.Text = "30 h";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 14.25F);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(607, 294);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 22);
            this.label9.TabIndex = 29;
            this.label9.Text = "5/10 h";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 14.25F);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(318, 317);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(201, 22);
            this.label8.TabIndex = 26;
            this.label8.Text = "Gleitzeit diesen Monat:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 14.25F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(364, 364);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 22);
            this.label7.TabIndex = 25;
            this.label7.Text = "Gleitzeit Gesamt:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 14.25F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(627, 486);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 22);
            this.label6.TabIndex = 24;
            this.label6.Text = "5";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 14.25F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(413, 486);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 22);
            this.label5.TabIndex = 23;
            this.label5.Text = "Kranktage:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 14.25F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(607, 411);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 22);
            this.label4.TabIndex = 22;
            this.label4.Text = "20/30";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(299, 427);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(215, 22);
            this.label3.TabIndex = 21;
            this.label3.Text = "Verfügbare Urlaubstage:";
            // 
            // Lbl_Infos_time
            // 
            this.Lbl_Infos_time.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Infos_time.Location = new System.Drawing.Point(214, 38);
            this.Lbl_Infos_time.Name = "Lbl_Infos_time";
            this.Lbl_Infos_time.Size = new System.Drawing.Size(190, 114);
            this.Lbl_Infos_time.TabIndex = 45;
            this.Lbl_Infos_time.Text = "Klicken Sie auf das gewünschte Datum um einen Status zu erhalten";
            // 
            // Pnl_Leg_Url_bea
            // 
            this.Pnl_Leg_Url_bea.BackColor = System.Drawing.Color.Yellow;
            this.Pnl_Leg_Url_bea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pnl_Leg_Url_bea.Location = new System.Drawing.Point(363, 195);
            this.Pnl_Leg_Url_bea.Name = "Pnl_Leg_Url_bea";
            this.Pnl_Leg_Url_bea.Size = new System.Drawing.Size(30, 10);
            this.Pnl_Leg_Url_bea.TabIndex = 46;
            // 
            // Lbl_Leg_Url_bea
            // 
            this.Lbl_Leg_Url_bea.AutoSize = true;
            this.Lbl_Leg_Url_bea.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Leg_Url_bea.Location = new System.Drawing.Point(229, 192);
            this.Lbl_Leg_Url_bea.Name = "Lbl_Leg_Url_bea";
            this.Lbl_Leg_Url_bea.Size = new System.Drawing.Size(128, 14);
            this.Lbl_Leg_Url_bea.TabIndex = 47;
            this.Lbl_Leg_Url_bea.Text = "Urlaub/Gleitzeit beantragt";
            // 
            // Lbl_Leg_Url_gen
            // 
            this.Lbl_Leg_Url_gen.AutoSize = true;
            this.Lbl_Leg_Url_gen.Font = new System.Drawing.Font("Arial", 8F);
            this.Lbl_Leg_Url_gen.Location = new System.Drawing.Point(267, 210);
            this.Lbl_Leg_Url_gen.Name = "Lbl_Leg_Url_gen";
            this.Lbl_Leg_Url_gen.Size = new System.Drawing.Size(90, 14);
            this.Lbl_Leg_Url_gen.TabIndex = 49;
            this.Lbl_Leg_Url_gen.Text = "Urlaub genehmigt";
            this.Lbl_Leg_Url_gen.Click += new System.EventHandler(this.Lbl_Leg_Url_gen_Click);
            // 
            // Pnl_Leg_Url_gen
            // 
            this.Pnl_Leg_Url_gen.BackColor = System.Drawing.Color.Green;
            this.Pnl_Leg_Url_gen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pnl_Leg_Url_gen.Location = new System.Drawing.Point(363, 215);
            this.Pnl_Leg_Url_gen.Name = "Pnl_Leg_Url_gen";
            this.Pnl_Leg_Url_gen.Size = new System.Drawing.Size(30, 10);
            this.Pnl_Leg_Url_gen.TabIndex = 48;
            // 
            // Lbl_Leg_Kra
            // 
            this.Lbl_Leg_Kra.AutoSize = true;
            this.Lbl_Leg_Kra.Font = new System.Drawing.Font("Arial", 8F);
            this.Lbl_Leg_Kra.Location = new System.Drawing.Point(321, 235);
            this.Lbl_Leg_Kra.Name = "Lbl_Leg_Kra";
            this.Lbl_Leg_Kra.Size = new System.Drawing.Size(35, 14);
            this.Lbl_Leg_Kra.TabIndex = 51;
            this.Lbl_Leg_Kra.Text = "Krank";
            this.Lbl_Leg_Kra.Click += new System.EventHandler(this.Lbl_Leg_Kra_Click);
            // 
            // Pnl_Leg_Kra
            // 
            this.Pnl_Leg_Kra.BackColor = System.Drawing.Color.IndianRed;
            this.Pnl_Leg_Kra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pnl_Leg_Kra.Location = new System.Drawing.Point(363, 238);
            this.Pnl_Leg_Kra.Name = "Pnl_Leg_Kra";
            this.Pnl_Leg_Kra.Size = new System.Drawing.Size(30, 10);
            this.Pnl_Leg_Kra.TabIndex = 50;
            // 
            // Lbl_Leg_Gleit
            // 
            this.Lbl_Leg_Gleit.AutoSize = true;
            this.Lbl_Leg_Gleit.Font = new System.Drawing.Font("Arial", 8F);
            this.Lbl_Leg_Gleit.Location = new System.Drawing.Point(312, 256);
            this.Lbl_Leg_Gleit.Name = "Lbl_Leg_Gleit";
            this.Lbl_Leg_Gleit.Size = new System.Drawing.Size(45, 14);
            this.Lbl_Leg_Gleit.TabIndex = 53;
            this.Lbl_Leg_Gleit.Text = "Gleitzeit";
            this.Lbl_Leg_Gleit.Click += new System.EventHandler(this.Lbl_Leg_Gleit_Click);
            // 
            // Pnl_Leg_Gleit
            // 
            this.Pnl_Leg_Gleit.BackColor = System.Drawing.Color.LightSkyBlue;
            this.Pnl_Leg_Gleit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pnl_Leg_Gleit.Location = new System.Drawing.Point(363, 259);
            this.Pnl_Leg_Gleit.Name = "Pnl_Leg_Gleit";
            this.Pnl_Leg_Gleit.Size = new System.Drawing.Size(30, 10);
            this.Pnl_Leg_Gleit.TabIndex = 52;
            // 
            // Kalender_Menu_Mitarbeiter
            // 
            this.Kalender_Menu_Mitarbeiter.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.Kalender_Menu_Mitarbeiter.IsColorToggleEnabled = true;
            this.Kalender_Menu_Mitarbeiter.Location = new System.Drawing.Point(407, 23);
            this.Kalender_Menu_Mitarbeiter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Kalender_Menu_Mitarbeiter.Name = "Kalender_Menu_Mitarbeiter";
            this.Kalender_Menu_Mitarbeiter.Size = new System.Drawing.Size(452, 255);
            this.Kalender_Menu_Mitarbeiter.TabIndex = 31;
            this.Kalender_Menu_Mitarbeiter.RequestDataForMonth += new System.EventHandler<System.DateTime>(this.Kalender_Menu_Mitarbeiter_RequestDataForMonth);
            this.Kalender_Menu_Mitarbeiter.Load += new System.EventHandler(this.Kalender_Menu_Mitarbeiter_Load_1);
            this.Kalender_Menu_Mitarbeiter.PaddingChanged += new System.EventHandler(this.Kalender_Menu_Mitarbeiter_PaddingChanged);
            // 
            // progressBarGleitzeit
            // 
            this.progressBarGleitzeit.Location = new System.Drawing.Point(551, 320);
            this.progressBarGleitzeit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.progressBarGleitzeit.Maximum = 10;
            this.progressBarGleitzeit.Name = "progressBarGleitzeit";
            this.progressBarGleitzeit.Size = new System.Drawing.Size(159, 21);
            this.progressBarGleitzeit.TabIndex = 54;
            // 
            // progressBarUrlaub
            // 
            this.progressBarUrlaub.Location = new System.Drawing.Point(551, 437);
            this.progressBarUrlaub.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.progressBarUrlaub.Maximum = 30;
            this.progressBarUrlaub.Name = "progressBarUrlaub";
            this.progressBarUrlaub.Size = new System.Drawing.Size(159, 21);
            this.progressBarUrlaub.TabIndex = 55;
            // 
            // Btn_Mit_Suchen
            // 
            this.Btn_Mit_Suchen.Location = new System.Drawing.Point(35, 383);
            this.Btn_Mit_Suchen.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Btn_Mit_Suchen.Name = "Btn_Mit_Suchen";
            this.Btn_Mit_Suchen.Size = new System.Drawing.Size(151, 50);
            this.Btn_Mit_Suchen.TabIndex = 56;
            this.Btn_Mit_Suchen.Text = "Mitarbeiter suchen";
            this.Btn_Mit_Suchen.UseVisualStyleBackColor = true;
            // 
            // Menue_Mitarbeiter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(932, 580);
            this.Controls.Add(this.Btn_Mit_Suchen);
            this.Controls.Add(this.progressBarUrlaub);
            this.Controls.Add(this.progressBarGleitzeit);
            this.Controls.Add(this.Lbl_Leg_Gleit);
            this.Controls.Add(this.Pnl_Leg_Gleit);
            this.Controls.Add(this.Lbl_Leg_Kra);
            this.Controls.Add(this.Pnl_Leg_Kra);
            this.Controls.Add(this.Lbl_Leg_Url_gen);
            this.Controls.Add(this.Pnl_Leg_Url_gen);
            this.Controls.Add(this.Lbl_Leg_Url_bea);
            this.Controls.Add(this.Pnl_Leg_Url_bea);
            this.Controls.Add(this.Lbl_Infos_time);
            this.Controls.Add(this.Kalender_Menu_Mitarbeiter);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.posteingang);
            this.Controls.Add(this.krank);
            this.Controls.Add(this.urlaub);
            this.Controls.Add(this.time);
            this.Controls.Add(this.abmelden);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Menue_Mitarbeiter";
            this.Text = "Menü";
            this.Activated += new System.EventHandler(this.Menue_Mitarbeiter_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Menue_Mitarbeiter_FormClosing);
            this.Load += new System.EventHandler(this.Menue_Mitarbeiter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button abmelden;
        private System.Windows.Forms.Button time;
        private System.Windows.Forms.Button urlaub;
        private System.Windows.Forms.Button krank;
        private System.Windows.Forms.Button posteingang;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Forms_Zeitmanagement.Kalender Kalender_Menu_Mitarbeiter;
        private System.Windows.Forms.Label Lbl_Infos_time;
        private System.Windows.Forms.Panel Pnl_Leg_Url_bea;
        private System.Windows.Forms.Label Lbl_Leg_Url_bea;
        private System.Windows.Forms.Label Lbl_Leg_Url_gen;
        private System.Windows.Forms.Panel Pnl_Leg_Url_gen;
        private System.Windows.Forms.Label Lbl_Leg_Kra;
        private System.Windows.Forms.Panel Pnl_Leg_Kra;
        private System.Windows.Forms.Label Lbl_Leg_Gleit;
        private System.Windows.Forms.Panel Pnl_Leg_Gleit;
        private System.Windows.Forms.ProgressBar progressBarGleitzeit;
        private System.Windows.Forms.ProgressBar progressBarUrlaub;
        private System.Windows.Forms.Button Btn_Mit_Suchen;
    }
}