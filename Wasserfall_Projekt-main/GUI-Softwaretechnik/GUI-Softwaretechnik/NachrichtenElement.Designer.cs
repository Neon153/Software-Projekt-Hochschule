namespace GUI_Softwaretechnik
{
    partial class NachrichtenElement
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.LblBetreff = new System.Windows.Forms.Label();
            this.LblInhalt = new System.Windows.Forms.Label();
            this.BtnBestätigen = new System.Windows.Forms.Button();
            this.BtnAblehnen = new System.Windows.Forms.Button();
            this.BtnLöschen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LblBetreff
            // 
            this.LblBetreff.AutoSize = true;
            this.LblBetreff.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblBetreff.Location = new System.Drawing.Point(27, 27);
            this.LblBetreff.Name = "LblBetreff";
            this.LblBetreff.Size = new System.Drawing.Size(84, 19);
            this.LblBetreff.TabIndex = 0;
            this.LblBetreff.Text = "LblBetreff";
            this.LblBetreff.Click += new System.EventHandler(this.LblBetreff_Click);
            // 
            // LblInhalt
            // 
            this.LblInhalt.AutoSize = true;
            this.LblInhalt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblInhalt.Location = new System.Drawing.Point(49, 72);
            this.LblInhalt.Name = "LblInhalt";
            this.LblInhalt.Size = new System.Drawing.Size(64, 18);
            this.LblInhalt.TabIndex = 1;
            this.LblInhalt.Text = "LblInhalt";
            this.LblInhalt.Click += new System.EventHandler(this.LblInhalt_Click);
            // 
            // BtnBestätigen
            // 
            this.BtnBestätigen.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBestätigen.Location = new System.Drawing.Point(21, 134);
            this.BtnBestätigen.Name = "BtnBestätigen";
            this.BtnBestätigen.Size = new System.Drawing.Size(75, 23);
            this.BtnBestätigen.TabIndex = 2;
            this.BtnBestätigen.Text = "Bestätigen";
            this.BtnBestätigen.UseVisualStyleBackColor = true;
            this.BtnBestätigen.Click += new System.EventHandler(this.BtnBestätigen_Click);
            // 
            // BtnAblehnen
            // 
            this.BtnAblehnen.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAblehnen.Location = new System.Drawing.Point(142, 134);
            this.BtnAblehnen.Name = "BtnAblehnen";
            this.BtnAblehnen.Size = new System.Drawing.Size(75, 23);
            this.BtnAblehnen.TabIndex = 3;
            this.BtnAblehnen.Text = "Ablehnen";
            this.BtnAblehnen.UseVisualStyleBackColor = true;
            this.BtnAblehnen.Click += new System.EventHandler(this.BtnAblehnen_Click);
            // 
            // BtnLöschen
            // 
            this.BtnLöschen.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLöschen.Location = new System.Drawing.Point(391, 134);
            this.BtnLöschen.Name = "BtnLöschen";
            this.BtnLöschen.Size = new System.Drawing.Size(75, 23);
            this.BtnLöschen.TabIndex = 4;
            this.BtnLöschen.Text = "Löschen";
            this.BtnLöschen.UseVisualStyleBackColor = true;
            this.BtnLöschen.Click += new System.EventHandler(this.BtnLöschen_Click);
            // 
            // NachrichtenElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.BtnLöschen);
            this.Controls.Add(this.BtnAblehnen);
            this.Controls.Add(this.BtnBestätigen);
            this.Controls.Add(this.LblInhalt);
            this.Controls.Add(this.LblBetreff);
            this.Name = "NachrichtenElement";
            this.Size = new System.Drawing.Size(479, 171);
            this.Load += new System.EventHandler(this.NachrichtenElement_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblBetreff;
        private System.Windows.Forms.Label LblInhalt;
        private System.Windows.Forms.Button BtnBestätigen;
        private System.Windows.Forms.Button BtnAblehnen;
        private System.Windows.Forms.Button BtnLöschen;
    }
}
