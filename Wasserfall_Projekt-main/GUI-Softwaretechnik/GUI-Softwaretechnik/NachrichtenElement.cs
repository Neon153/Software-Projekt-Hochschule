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
    public partial class NachrichtenElement : UserControl
    {
        public NachrichtenElement()
        {
            InitializeComponent();
        }

        private void NachrichtenElement_Load(object sender, EventArgs e)
        {

        }

        private void LblBetreff_Click(object sender, EventArgs e)
        {

        }
        
        private void LblInhalt_Click(object sender, EventArgs e)
        {

        }

        // Für die Datenbindung
        public string NachrichtenBetreff
        {
            get { return LblBetreff.Text; }
            set { LblBetreff.Text = value; }
        }

        public string NachrichtenInhalt
        {
            get { return LblInhalt.Text; }
            set { LblInhalt.Text = value; }
        }

        // Eine eindeutige ID, um die Nachricht in deiner Datenquelle zu finden
        public string ItemID { get; set; }

        // Events, die ausgelöst werden, wenn ein Button geklickt wird
        public event EventHandler Confirmed;
        public event EventHandler Rejected;
        public event EventHandler Deleted;

        private void BtnBestätigen_Click(object sender, EventArgs e)
        {
            Confirmed?.Invoke(this, EventArgs.Empty);
        }

        private void BtnAblehnen_Click(object sender, EventArgs e)
        {
            Rejected?.Invoke(this, EventArgs.Empty);
        }

        private void BtnLöschen_Click(object sender, EventArgs e)
        {
            Deleted?.Invoke(this, EventArgs.Empty);
        }

        // Event-Handler für die Buttons im UserControl

    }
}
