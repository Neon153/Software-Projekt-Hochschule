using Forms_Zeitmanagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_Softwaretechnik
{
    public partial class Menue_Mitarbeiter : Form
    {
        Login form1;
        Menue_Mitarbeiter form2;
        bool zurueckGeklickt = false;  // Variable, um zu überprüfen, ob "Abmelden" geklickt wurde
        private Write_File f2=new Write_File();

        public object F11 { get; }

        public Menue_Mitarbeiter(Login f1)
        {
            InitializeComponent();
            form1 = f1;
            Kalender_Menu_Mitarbeiter.IsColorToggleEnabled = false;           // Farbumschaltung deaktivieren
            Kalender_Menu_Mitarbeiter.RequestDataForMonth += Kalender_Menu_Mitarbeiter_RequestDataForMonth;
            Kalender_Menu_Mitarbeiter.DateClicked += Kalender_Menu_Mitarbeiter_DateClicked; // Ereignisbehandlung für DateClicked hinzufügen 
        }

        public Menue_Mitarbeiter(Login f1, object f11) : this(f1)
        {
            F11 = f11;
        }

        public Menue_Mitarbeiter()
        {
        }

        private void Kalender_Menu_Mitarbeiter_DateClicked(object sender, DateTime e)
        {
            // Dateipfad ist nur lokal im Handler, da die Funktion nun bei jeder Anforderung läuft
            string dateipfad = f2.Get_Current_User_Login();

            // Nur laden, wenn die Datei existiert
            if (!(System.IO.File.Exists(dateipfad)))
            {
                Lbl_Infos_time.Text = "Dokument nicht gefunden!!!";// Optional: Fehlermeldung
                return;
            }
            Lbl_Infos_time.Text = "";// Optional: Meldung wenn Datei gefunden wurde


            string[] zeilen = System.IO.File.ReadAllLines(dateipfad);

            foreach (string zeile in zeilen)
            {
                string[] teile = zeile.Split(',');
                if (teile.Length >= 3) 
                {
                    DateTime datum;
                    if (DateTime.TryParse(teile[0], out datum))
                    {
                        if (datum.Date == e.Date)
                        {
                           string checkin = teile[1];
                           string checkout = teile[2];
                          if (checkin == "0")
                            { string status = teile[3];
                              string statusText = "";
                                   if (status == "U")
                                   {
                                       statusText = "Genehmigter Urlaub";
                                   }
                                   else if (status == "u")
                                   {
                                       statusText = "Beantragter Urlaub";
                                   }
                                   else if (status == "K")
                                   {
                                       statusText = "Krankmeldung";
                                   }
                                   else if (status == "G")
                                   {
                                       statusText = "Gleitzeit";
                                   }
                                    else if (status == "g")
                                   {
                                       statusText = "Beantragte Gleitzeit";
                                    }
                                    else
                                    {
                                     statusText = "Kein Eintrag vorhanden";
                                    }

                                Lbl_Infos_time.Text = $"Status {e.ToShortDateString()}: \n\n{statusText}";
                                return; // Beenden, wenn der Eintrag gefunden wurde
                            }
                            Lbl_Infos_time.Text = $"Status {e.ToShortDateString()}:\n\nEingestempelt: {checkin} Uhr\nAusgestempelt: {checkout} Uhr";
                            return; // Beenden, wenn der Eintrag gefunden wurde
                        }
                    }

                   
                }
            }

            Lbl_Infos_time.Text = $"Kein Eintrag für den {e.ToShortDateString()} gefunden."; // Kein Eintrag für das Datum vorhanden möglicherweiße weil das Datum zu weit vorraus liegt
        }

        private void abmelden_Click(object sender, EventArgs e)
        {
            zurueckGeklickt = true;                                                //Flag setzen wenn abmelden oder zurück geklickt wurde
            form1.Show();
            this.Close();
            
        }

        private void time_Click(object sender, EventArgs e)
        {
            ein_und_ausstempeln form3 = new ein_und_ausstempeln(this);
            form3.Show();
            this.Hide();
        }

        private void krank_Click(object sender, EventArgs e)
        {
            Krankmelden krank = new Krankmelden(this);
            krank.Show();
            Hide();
        }

        private void urlaub_Click(object sender, EventArgs e)
        {
            Urlaub u = new Urlaub(this);
            u.Show();
            Hide();
        }

        private void posteingang_Click(object sender, EventArgs e)
        {
            Posteingang p = new Posteingang(this);
            p.Show();
            Hide();
        }

        private void Menue_Mitarbeiter_FormClosing(object sender, FormClosingEventArgs e)   // Ereignisbehandlung für das Schließen des Formulars
        {
            if (zurueckGeklickt == false)                                                   // Überprüfen, ob "Abmelden" nicht geklickt wurde
            {
                System.Windows.Forms.Application.Exit();                                    // Anwendung beenden, wenn das Formular geschlossen wird (nicht durch "Abmelden")

            }
        }

        private void Menue_Mitarbeiter_Load(object sender, EventArgs e)
        {
            
            if( f2.Get_Current_User_Login() == "Manager_0001.txt")
            {
                Btn_Mit_Suchen.Visible = true;
            }
            else
            {
                Btn_Mit_Suchen.Visible = false;

            }

        }

        private void Kalender_Menu_Mitarbeiter_Load(object sender, EventArgs e)
        {

           
        }

        private void Kalender_Menu_Mitarbeiter_RequestDataForMonth(object sender, DateTime requestedMonth)
        {
            // Die Daten für den angefragten Monat sammeln
            Dictionary<DateTime, Color> monthData = new Dictionary<DateTime, Color>();

            // Dateipfad ist nur lokal im Handler, da die Funktion nun bei jeder Anforderung läuft
            string dateipfad = f2.Get_Current_User_Login();

            // Nur laden, wenn die Datei existiert
            if  ( !(System.IO.File.Exists(dateipfad)))
            {
                Lbl_Infos_time.Text = "Dokument nicht gefunden!!!";// Optional: Fehlermeldung
                return;
            }
            //Lbl_Infos_time.Text = "";// Optional: Meldung wenn Datei gefunden wurde


            string[] zeilen = System.IO.File.ReadAllLines(dateipfad);

                foreach (string zeile in zeilen)
                {
                    string[] teile = zeile.Split(',');
               
                   
                    if (teile.Length >= 3) // Angenommen: [Datum, ID, x, Status-Code]
                    {
                        DateTime datum;

                        // *** WICHTIGE ÄNDERUNG HIER: Filterung nur nach dem angeforderten Monat ***
                        if (DateTime.TryParse(teile[0], out datum) && datum.Year == requestedMonth.Year && datum.Month == requestedMonth.Month)
                        {
                            Color farbe;
                            string statusCode = teile[3]; // Annahme: Status ist im 4. Teil (Index 3)

                            switch (statusCode)
                            {
                                case "U":
                                    farbe = Color.Green;   //Genehmigter Urlaub
                                break;
                                case "u":
                                case "g":
                                farbe = Color.Yellow; //beantragter Urlaub
                                break;
                                case "K":
                                    farbe = Color.IndianRed; //Krankmeldung
                                break;
                                case "G":
                                    farbe = Color.LightSkyBlue; // Gleitzeit
                                break;
                                default:
                                    farbe = Color.Transparent; // Standardfarbe für unbekannte Codes
                                break;
                            }

                            monthData[datum.Date] = farbe;  //Farbe dem Datum zuweisen
                    }
                    }
                }
            
          

            // Die gesammelten Daten an das Kalender-Control zurücksenden
            // Der Sender ist das Kalender-Control
            Kalender kalender = (Kalender)sender;
            kalender.SetMonthColorData(monthData);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Menue_Mitarbeiter_Activated(object sender, EventArgs e)
        {
            

            String s_dateiPfad = f2.Get_Current_User_Login_S();
            if (!string.IsNullOrEmpty(s_dateiPfad) && System.IO.File.Exists(s_dateiPfad))
            {
                f2.read_Values(f2.Get_Current_User_Login_S());
                String krankTage = f2.getKrankTage();
                String gleitZeit = f2.getGleitzeitTage();
                String urlaubTage = f2.getUrlaubTage() + "/" + "30";
                label6.Text = krankTage;
                label9.Text = gleitZeit+"/"+"10";
                label10.Text = gleitZeit;
                label4.Text = urlaubTage;
                progressBarGleitzeit.Value = int.Parse(gleitZeit);
                progressBarUrlaub.Value = int.Parse(f2.getUrlaubTage());
            }
        }

        private void PnlGruen_Gleitzeit_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void Lbl_Leg_Url_gen_Click(object sender, EventArgs e)
        {

        }

        private void Lbl_Leg_Kra_Click(object sender, EventArgs e)
        {

        }

        private void Lbl_Leg_Gleit_Click(object sender, EventArgs e)
        {

        }

        private void Kalender_Menu_Mitarbeiter_PaddingChanged(object sender, EventArgs e)
        {

        }

        private void Kalender_Menu_Mitarbeiter_Load_1(object sender, EventArgs e)
        {

        }
    }
    
}
