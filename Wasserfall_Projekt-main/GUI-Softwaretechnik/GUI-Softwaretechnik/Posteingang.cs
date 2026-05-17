using GUI_Softwaretechnik;
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
    //Posteingang Managaer Benachrichtigung Kranksein
    

    public partial class Posteingang : Form
    {
        String Krankmeldung()
        {
           
            String[] Kranke_Person = f1.Read_File("krank.txt");
            return Kranke_Person[0] + " ist heute leider krank ";
            
        }
        Write_File f1 = new Write_File();
        private Menue_Mitarbeiter f2;
        private Menue_Gruppenleiter f3;
        DateiHilfen dateiHilfen = new DateiHilfen();
        bool zurueckGeklickt = false;

        public Posteingang(Menue_Mitarbeiter form2=null, Menue_Gruppenleiter form3=null)
        {
            InitializeComponent();
            f2 = form2;
            flowLayoutPanel1.AutoScroll = true;
            // label1.Text=Krankmeldung();
        }

        public Posteingang()
        {
        }

        private void BtnZurueck_Posteingang_Menue_Click(object sender, EventArgs e)
        {
            zurueckGeklickt = true;
            f2.Show();
            Close();
        }

        private void Posteingang_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!zurueckGeklickt)
            {
                System.Windows.Forms.Application.Exit();

            }
        }

        private void Pnl_Nachrichten_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public class Nachricht
        {
            public string Textdatei_Mitarbeiter { get; set; }
            public string Kürzel_Für_Betreff { get; set; }

            public string Begindatum { get; set; }

            public string Enddatum { get; set; }

            public string Betreff { get; set; }
            public string Name { get; set; }
            public string Inhalt { get; set; }
        }
        private void LoadNotifications()
        {
            // Die Pfade zur Textdatei
            string filePath = f1.Get_Current_User_Login();
            int länge = filePath.Length;
            filePath = filePath.Remove(länge - 4) + "_N.txt";

            // Die Liste, die wir mit Daten befüllen werden
            List<Nachricht> nachrichtenListe = new List<Nachricht>();

            // Zuerst versuchen, die Daten aus der Datei zu laden
            if (File.Exists(filePath))
            {
                try
                {
                    // Liest alle Zeilen der Datei
                    string[] lines = File.ReadAllLines(filePath);

                    foreach (string line in lines)
                    {
                        // Die Felder sind durch ein Semikolon (;) getrennt
                        string[] parts = line.Split(',');

                        // Prüft, ob wir mindestens 3 Teile (Betreff, Nachricht, Name) haben
                        if (parts.Length >= 4)
                        {
                            nachrichtenListe.Add(new Nachricht
                            {
                                Textdatei_Mitarbeiter = parts[0].Trim(),
                                Kürzel_Für_Betreff = parts[1].Trim(),
                                Begindatum = parts[2].Trim(),
                                Enddatum = parts[3].Trim(),
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Fehler beim Laden der Datei: {ex.Message}", "Dateifehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
           
            //Erstellen der gefragten Nachricht durch zusammenfügen der Daten aus der Textdatei

            foreach (var nachricht in nachrichtenListe)
            {
                int zeichenLöschen = nachricht.Textdatei_Mitarbeiter.Length - 9;

                
                nachricht.Name = nachricht.Textdatei_Mitarbeiter.Remove(zeichenLöschen);

                if (nachricht.Kürzel_Für_Betreff == "K")
                {
                    nachricht.Betreff = "Krankmeldung " + nachricht.Name;
                    
                    if (nachricht.Enddatum == nachricht.Begindatum)
                    {
                        if (nachricht.Begindatum == Convert.ToString(DateTime.Now.Date))
                        {
                            nachricht.Inhalt = $"{nachricht.Name} für heute krankgemeldet.";
                            
                            continue;
                        }
                        else
                        {
                            nachricht.Inhalt = $"{nachricht.Name} ist am {nachricht.Begindatum.Remove(10)} krankgemeldet.";
                            
                            continue;
                        }

                    }
                    else
                    {
                        nachricht.Inhalt = $"{nachricht.Name} ist vom {nachricht.Begindatum.Remove(10)} bis {nachricht.Enddatum.Remove(10)} krankgemeldet.";
                    }
                    
                }

                else if (nachricht.Kürzel_Für_Betreff == "u")
                {
                    nachricht.Betreff = "Urlaubsantrag " + nachricht.Name;
                    if (nachricht.Enddatum == nachricht.Begindatum)
                    {
                        nachricht.Inhalt = $"{nachricht.Name} hat am {nachricht.Begindatum.Remove(10)} Urlaub beantragt.";
                    }
                    else
                    {
                        nachricht.Inhalt = $"{nachricht.Name} hat vom {nachricht.Begindatum.Remove(10)} bis {nachricht.Enddatum.Remove(10)} Urlaub beantragt.";
                    }

                }

                else if (nachricht.Kürzel_Für_Betreff == "g")
                {
                    nachricht.Betreff = "Gleitzeitantrag " + nachricht.Name;
                    if (nachricht.Enddatum == nachricht.Begindatum)
                    {
                        nachricht.Inhalt = $"{nachricht.Name} hat am {nachricht.Begindatum.Remove(10)} Gleitzeit beantragt.";
                    }
                    else
                    {
                        nachricht.Inhalt = $"{nachricht.Name} hat vom {nachricht.Begindatum.Remove(10)} bis {nachricht.Enddatum.Remove(10)} Gleitzeit beantragt.";
                    }
                }


            }

            }

            // Wenn keine Daten aus der Datei geladen wurden (oder die Datei nicht existiert),

           /* if (!nachrichtenListe.Any())
            {
                // === TESTDATEN ===
                nachrichtenListe.Add(new Nachricht
                {
                    Betreff = "Mahnung A1",
                    Inhalt = "Bitte bestätigen Sie die Zahlung.",
                    Name = "Kunde A1"
                });
                nachrichtenListe.Add(new Nachricht
                {
                    Betreff = "Projekt Genehmigung",
                    Inhalt = "Das Projekt 'Neptun' kann gestartet werden.",
                    Name = "Chef B2"
                });
                nachrichtenListe.Add(new Nachricht
                {
                    Betreff = "Info: Server-Update",
                    Inhalt = "Heute Nacht von 01:00 bis 03:00 Uhr findet ein Server-Update statt.",
                    Name = "IT-Admin"
                });
                // =================
            }*/


            // Löscht alle vorhandenen Elemente vor dem Neuladen
            flowLayoutPanel1.Controls.Clear();

            foreach (var nachricht in nachrichtenListe)
            {
                var item = new NachrichtenElement
                {
                    
                    ItemID = nachricht.Textdatei_Mitarbeiter + "," + nachricht.Kürzel_Für_Betreff + "," + nachricht.Begindatum + "," + nachricht.Enddatum,
                    NachrichtenBetreff = nachricht.Betreff,
                    NachrichtenInhalt = nachricht.Inhalt,
                };           

                // Events abonnieren und zum FlowLayoutPanel hinzufügen
                item.Confirmed += NotificationItem_Confirmed;
                item.Rejected += NotificationItem_Rejected;
                item.Deleted += NotificationItem_Deleted;

                flowLayoutPanel1.Controls.Add(item);
            }
        }



        private void NotificationItem_Confirmed(object sender, EventArgs e)
        {
            // 'sender' ist das UserControl, das das Event ausgelöst hat
            var item = sender as NachrichtenElement;
            if (item == null) return;
            string filePath = f1.Get_Current_User_Login();
            int länge = filePath.Length;
            filePath = filePath.Remove(länge - 4)+ "_N.txt";

           // MessageBox.Show($"Nachricht muss nicht bestätigt werden." + filePath);


            // Entferne das Element aus dem FlowLayoutPanel, da die Aktion abgeschlossen ist
            flowLayoutPanel1.Controls.Remove(item);

            string[] parts = item.ItemID.Split(',');

            // Prüft, ob wir mindestens 3 Teile (Betreff, Nachricht, Name) haben



              string Textdatei_Mitarbeiter = parts[0].Trim();
              string Kürzel_Für_Betreff = parts[1].Trim();
              DateTime Begindatum = Convert.ToDateTime(parts[2].Trim());
              DateTime Enddatum = Convert.ToDateTime(parts[3].Trim());

              List<DateTime> Liste = DateiHilfen.FindeArbeitstage(Begindatum, Enddatum);

            if (Kürzel_Für_Betreff == "g")
            {
                DateiHilfen.DeletlastCharandAppendStringToMatchingDates(Textdatei_Mitarbeiter, Liste, "G");
                MessageBox.Show($"Nachricht Gleitzeit wurde Genehmigt.");
                flowLayoutPanel1.Controls.Remove(item);
            }
            else if (Kürzel_Für_Betreff == "u")
            {

                DateiHilfen.DeletlastCharandAppendStringToMatchingDates(Textdatei_Mitarbeiter, Liste, "U");
                MessageBox.Show($"Nachricht Urlaub wurde Genehmigt.");
                flowLayoutPanel1.Controls.Remove(item);
            }
            else
            {
                MessageBox.Show($"Nachricht muss nicht bestätigt werden.");
                return;
            }

            DateiHilfen.RemoveMatchingLine(item.ItemID, filePath);
        }

        private void NotificationItem_Rejected(object sender, EventArgs e)
        {
            var item = sender as NachrichtenElement;
            if (item == null) return;

            string[] parts = item.ItemID.Split(',');
            string filePath = f1.Get_Current_User_Login();
            int länge = filePath.Length;
            filePath = filePath.Remove(länge - 4) + "_N.txt";
            



            string Textdatei_Mitarbeiter = parts[0].Trim();
                   string Kürzel_Für_Betreff = parts[1].Trim();
                   DateTime Begindatum = Convert.ToDateTime(parts[2].Trim());
                   DateTime Enddatum = Convert.ToDateTime(parts[3].Trim());
                   
                    List<DateTime> Liste = DateiHilfen.FindeArbeitstage(Begindatum, Enddatum);
            if (Kürzel_Für_Betreff == "g")
            {
                DateiHilfen.DeletlastCharandAppendStringToMatchingDates(Textdatei_Mitarbeiter, Liste, " ");
                MessageBox.Show($"Nachricht Gleitzeit wurde abgelehnt.");
                flowLayoutPanel1.Controls.Remove(item);
            }
            else if (Kürzel_Für_Betreff == "u")
            {

                DateiHilfen.DeletlastCharandAppendStringToMatchingDates(Textdatei_Mitarbeiter, Liste, " ");
                MessageBox.Show($"Nachricht Urlaub wurde abgelehnt.");
                flowLayoutPanel1.Controls.Remove(item);
            }
            else
            {
                MessageBox.Show($"Nachricht muss nicht bestätigt werden.");
                return;
            }

            DateiHilfen.RemoveMatchingLine(item.ItemID, filePath);  // Entfernt die Zeile aus der Datei damit Nachricht (bei neu Laden) nicht mehr auftaucht


            flowLayoutPanel1.Controls.Remove(item);
        }

        private void NotificationItem_Deleted(object sender, EventArgs e)
        {
            var item = sender as NachrichtenElement;
            if (item == null) return;

            string[] parts = item.ItemID.Split(',');
            string filePath = f1.Get_Current_User_Login();
            int länge = filePath.Length;
            filePath = filePath.Remove(länge - 4) + "_N.txt";




            string Textdatei_Mitarbeiter = parts[0].Trim();
            string Kürzel_Für_Betreff = parts[1].Trim();
            DateTime Begindatum = Convert.ToDateTime(parts[2].Trim());
            DateTime Enddatum = Convert.ToDateTime(parts[3].Trim());

            List<DateTime> Liste = DateiHilfen.FindeArbeitstage(Begindatum, Enddatum);
            if (Kürzel_Für_Betreff == "g" || Kürzel_Für_Betreff == "u")
            {
               
                MessageBox.Show($"Nachricht darf nur bestätigt oder abgeleht werden!!");
                return;
            }
          
            else
            {
                MessageBox.Show($"Nachricht wurde gelöscht.");
                flowLayoutPanel1.Controls.Remove(item);
                
            }

            DateiHilfen.RemoveMatchingLine(item.ItemID, filePath);  // Entfernt die Zeile aus der Datei damit Nachricht (bei neu Laden) nicht mehr auftaucht
        }

        private void Posteingang_Load(object sender, EventArgs e)
        {
            LoadNotifications();
        }
    }
}
