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
    public partial class Infos_Mitarbeiter : Form
    {

        bool zurueckGeklickt = false; 
        public Infos_Mitarbeiter()
        {
            InitializeComponent();
        }

        private void Infos_Mitarbeiter_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                System.Windows.Forms.Application.Exit();

            }
        }
    }
}
