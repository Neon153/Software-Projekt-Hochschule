using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GUI_Softwaretechnik.Urlaub;
namespace GUI_Softwaretechnik
{
    public partial class Krankmelden : Form
    {
        private Krankheit k1 = new Krankheit();
        private Menue_Mitarbeiter f2;
        private Write_File f1 = new Write_File();
        bool zurueckGeklickt = false;
        private Write_File Pfad = new Write_File();
        

        public Krankmelden(Menue_Mitarbeiter form2)
        {
            InitializeComponent();
            f2 = form2;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime krankheitAnfang = anfang.Value;
            k1.SetAnfang(krankheitAnfang);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime krankheitEnde = ende.Value;
            k1.SetEnde(krankheitEnde);
        }

        private void Bkrankheiteinreichen_Click(object sender, EventArgs e)
        {
            string dateipfad = Pfad.Get_Current_User_Login();
            string Krankzeichen = "K";
            string[] zeile = File.ReadAllLines(dateipfad);
            List<DateTime> Kranktage_list = DateiHilfen.FindeArbeitstage(anfang.Value, ende.Value);
            int MengeTage = Kranktage_list.Count;
            Pfad.read_Values(Pfad.Get_Current_User_Login_S());
            String krankTage = Pfad.getKrankTage();
            String gleitZeit = Pfad.getGleitzeitTage();
            String urlaubTage = Pfad.getUrlaubTage();
            anfang.Value = anfang.Value.Date;
            ende.Value = ende.Value.Date;

            if (anfang.Value > ende.Value)
            {
                KrankheitsTage.Text = "Fehler: Das Anfangsdatum liegt nach dem Enddatum.";
                return;
            }
            else if (anfang.Value.Date < DateTime.Now.Date)
            {
                KrankheitsTage.Text = "Fehler: Kranktag kann nicht für Vergangenheit beantragt werden";
                return;
            }

            char? Fehler = DateiHilfen.FindAndReturnFirstNonCommaChar(dateipfad, Kranktage_list); // Überprüfen auf Konflikte in der Datei U u G g Schon vorhanden?
            if(Fehler == 'K')
            {
                                KrankheitsTage.Text = "Fehler: Mindestens ein Krankheitstag wurde bereits eingereicht.";
                return;
            }
            
            DateiHilfen.AddUniqueDatesToFile(dateipfad, Kranktage_list); // Hinzufügen der neuen Urlaubstage zur Datei
            DateiHilfen.AppendStringToMatchingDates(dateipfad, Kranktage_list, Krankzeichen); // Markieren der Urlaubstage in der Datei
            // Aktualisieren der Kranktage im User File
            MengeTage += Convert.ToInt32(krankTage);
            Pfad.write_in_userId_S(Pfad.Get_Current_User_Login_S(), urlaub: urlaubTage, gleitzeit: gleitZeit, krankheit: Convert.ToString(MengeTage));
            KrankheitsTage.Text = "Erfolgreich " + MengeTage + " Krankheitstage (Wochenenden abgezogen) eingereicht.";

            //Schreiben der Krankmeldung in die Manager Datei

            string message = Environment.NewLine + dateipfad + "," + Krankzeichen + "," + Convert.ToString(anfang.Value) + "," + Convert.ToString(ende.Value);

            string dateiPfad = "Manager_0001_N.txt";  //Pfad für Posteingang Mananger

            if (File.Exists(dateiPfad))
            {
                try
                {
                    // Wenn die Datei existiert: Text anhängen (Append)
                    // File.AppendAllText fügt den Text am Ende der Datei hinzu.
                    File.AppendAllText(dateiPfad, message);
                    Console.WriteLine($"Neue Zeile erfolgreich an die Datei angehängt: {dateiPfad}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fehler beim Anhängen an die Datei: {ex.Message}");
                }
            }
            else
            {
                // Wenn die Datei NICHT existiert: Datei neu erstellen und den Text reinschreiben.
                // Beachten Sie, dass Sie hier KEIN Environment.NewLine am Anfang benötigen,



                try
                {
                    File.WriteAllText(dateiPfad, message);
                    Console.WriteLine($"Datei existierte nicht und wurde neu erstellt: {dateiPfad}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fehler beim Erstellen der Datei: {ex.Message}");
                }
            }
        } 
        private void back_to_menue_Click(object sender, EventArgs e)
        {
            zurueckGeklickt = true;
            f2.Show();
            Close();
            
        }

        private void Krankmelden_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!zurueckGeklickt)
            {
                System.Windows.Forms.Application.Exit();

            }
        }

        private void Krankmelden_Load(object sender, EventArgs e)
        {

        }

        private void Krankmelden_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
        }

        private void Krankmelden_Load_1(object sender, EventArgs e)
        {

        }
    }
}
