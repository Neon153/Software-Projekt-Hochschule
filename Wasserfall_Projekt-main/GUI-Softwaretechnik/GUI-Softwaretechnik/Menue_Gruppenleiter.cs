using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_Softwaretechnik
{
    public partial class Menue_Gruppenleiter : Form
    {
        private Menue_Mitarbeiter m1 = new Menue_Mitarbeiter();
        Login form1;
        bool zurueckGeklickt = false;
        private static object f1;

        public Menue_Gruppenleiter(Login fr1)
        {
            InitializeComponent();
            form1 = fr1;
            Kalender_Menu_Gruppenleiter.IsColorToggleEnabled = false;
        }

        private void Menue_Gruppenleiter_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                System.Windows.Forms.Application.Exit();

            }
        }

        private void urlaub_Click(object sender, EventArgs e)
        {

        }

        private void krank_Click(object sender, EventArgs e)
        {

        }

        private void posteingang_Click(object sender, EventArgs e)
        {
            Posteingang P1 = new Posteingang(form3: this);
            P1.Show();
            this.Hide();
        }

        private void Menue_Gruppenleiter_Load(object sender, EventArgs e)
        {

        }

        private void abmelden_Click(object sender, EventArgs e)
        {
            zurueckGeklickt = true;
            form1.Show();
            this.Close();
        }
    }
}
