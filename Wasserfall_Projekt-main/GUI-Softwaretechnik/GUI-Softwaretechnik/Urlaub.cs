using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GUI_Softwaretechnik
{
    public partial class Urlaub : Form
    {
        private Write_File Pfad = new Write_File();
        private Menue_Mitarbeiter f2;
        
        bool zurueckGeklickt = false;
        public Urlaub(Menue_Mitarbeiter form2)
        {
            InitializeComponent();
            f2 = form2;
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime UrlaubAnfang = anfang.Value;
           
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime UrlaubEnde = ende.Value;
            Console.Write(UrlaubEnde);
        }

       
        private void Urlaub_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!zurueckGeklickt)
            {
                System.Windows.Forms.Application.Exit();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            zurueckGeklickt = true;
            f2.Show();
            Close();

        }

        private void Urlaub_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
        }

        private void Urlaub_Load_1(object sender, EventArgs e)
        {
            Lbl_Info.Text = "";
        }

        private void BtnBantragen_Click(object sender, EventArgs e)
        {   

            string dateipfad = Pfad.Get_Current_User_Login();
            string Urlaubsart = "0";
            string[] zeile = File.ReadAllLines(dateipfad);
            List <DateTime> urlaubstage = FindeArbeitstage(anfang.Value, ende.Value);
            int MengeTage = urlaubstage.Count;
            Pfad.read_Values(Pfad.Get_Current_User_Login_S());
            String krankTage = Pfad.getKrankTage();
            String gleitZeit = Pfad.getGleitzeitTage();
            String urlaubTage = Pfad.getUrlaubTage();
            anfang.Value = anfang.Value.Date;
            ende.Value = ende.Value.Date;

            if (anfang.Value > ende.Value)
            {
                Lbl_Info.Text = "Fehler: Das Anfangsdatum liegt nach dem Enddatum.";
                return;
            }
            else if (anfang.Value < DateTime.Now)
            {
                Lbl_Info.Text = "Fehler: Urlaub kann nicht für Vergangenheit beantragt werden";
                return;
            }

            char? Fehler = DateienBearbeitung.FindAndReturnFirstNonCommaChar(dateipfad, urlaubstage); // Überprüfen auf Konflikte in der Datei U u G g Schon vorhanden?
            if (Fehler != null)
            {
                if (Fehler == 'u')
                {
                    Lbl_Info.Text = "Fehler: Für einen oder mehrere der ausgewählten Tage wurde bereits Urlaub eingetragen.";
                    return;
                }
                else if (Fehler == 'g')
                {
                    Lbl_Info.Text = "Fehler: Für einen oder mehrere der ausgewählten Tage wurde bereits Gleitzeit eingetragen.";
                    return;
                }
                else if (Fehler == 'U' || Fehler == 'G')
                {
                    Lbl_Info.Text = "Fehler: Für einen oder mehrere der ausgewählten Tage wurde bereits ein genehmigter Eintrag vorgenommen.";
                    return;
                }
                else
                {
                    Lbl_Info.Text = "Fehler: Für einen oder mehrere der ausgewählten Tage wurde bereits ein Eintrag vorgenommen.";
                    return;
                }
            }

            if (RadGleitzeit.Checked)                           // Gleitzeit ausgewählt checken ob genug Tage vorhanden sind
            {
                if (MengeTage > (Convert.ToInt32(gleitZeit) / 8))
                {
                    Lbl_Info.Text = "Nicht genügend Gleitzeit vorhanden!";
                    return;
                }



                int verbleibendeGleitzeit = Convert.ToInt32(gleitZeit) - (MengeTage * 8);
                Pfad.write_in_userId_S(Pfad.Get_Current_User_Login_S(), urlaub: urlaubTage, gleitzeit: verbleibendeGleitzeit.ToString(), krankheit: krankTage);
                Urlaubsart = "g";
            }



            else if (RadUrlaubstage.Checked)                     // Urlaubstage ausgewählt checken ob genug Tage vorhanden sind
            {
                if (MengeTage > (Convert.ToInt32(urlaubTage)))
                {
                    Lbl_Info.Text = "Nicht genügend Urlaubstage vorhanden!";
                    return;
                }
                int verbleibendeUrlaubstage = Convert.ToInt32(urlaubTage) - MengeTage;
                Pfad.write_in_userId_S(Pfad.Get_Current_User_Login_S(), urlaub: verbleibendeUrlaubstage.ToString(), gleitzeit: gleitZeit, krankheit: krankTage);
                Urlaubsart = "u";
            }
            else
            {
                Lbl_Info.Text = "Bitte Urlaubsart auswählen!";
                return;
            }

           
            DateienBearbeitung.AddUniqueDatesToFile(dateipfad, urlaubstage); // Hinzufügen der neuen Urlaubstage zur Datei
            DateienBearbeitung.AppendStringToMatchingDates(dateipfad, urlaubstage, Urlaubsart); // Anhängen des Urlaubsart-Codes an die entsprechenden Zeilen

            string message = Environment.NewLine + dateipfad + "," + Urlaubsart + "," + Convert.ToString(anfang.Value) + "," + Convert.ToString(ende.Value);

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
        
    

                 Lbl_Info.Text = "Urlaub erfolgreich beantragt!";
        }

        public static List<DateTime> FindeArbeitstage(DateTime startDatum, DateTime endDatum)
        {
            // Initialisiere die Liste für die Arbeitstage
            List<DateTime> arbeitstage = new List<DateTime>();

            // Stelle sicher, dass das Startdatum nicht nach dem Enddatum liegt
            if (startDatum > endDatum)
            {
                // Tausche die Daten, falls sie falsch herum eingegeben wurden,
                // um eine leere Liste oder einen Fehler zu vermeiden.
                DateTime temp = startDatum;
                startDatum = endDatum;
                endDatum = temp;
            }

            // Beginne mit dem Startdatum
            DateTime aktuellesDatum = startDatum.Date; // .Date stellt sicher, dass wir nur das Datum ohne Uhrzeit betrachten

            // Durchlaufe alle Tage von Startdatum bis Enddatum (einschließlich)
            while (aktuellesDatum <= endDatum.Date)
            {
                // Prüfe, ob der aktuelle Tag KEIN Samstag (DayOfWeek.Saturday) oder Sonntag (DayOfWeek.Sunday) ist
                if (aktuellesDatum.DayOfWeek != DayOfWeek.Saturday && aktuellesDatum.DayOfWeek != DayOfWeek.Sunday)
                {
                    // Wenn es ein Wochentag ist (Montag-Freitag), füge ihn zur Liste hinzu
                    arbeitstage.Add(aktuellesDatum);
                }

                // Gehe zum nächsten Tag
                aktuellesDatum = aktuellesDatum.AddDays(1);
            }

            return arbeitstage;
        }

        public class DateienBearbeitung
        {
            /// <summary>
            /// Liest eine Textdatei ein, sammelt alle existierenden Daten in der ersten Spalte,
            /// fügt neue, eindeutige Daten hinzu und schreibt die Gesamtliste zurück in die Datei.
            /// Gibt keinen Wert zurück (void).
            /// </summary>
            /// <param name="filePath">Der vollständige Pfad zur Textdatei.</param>
            /// <param name="newDates">Eine Liste neuer Daten, die hinzugefügt werden sollen.</param>
            /// 
            public static char? FindAndReturnFirstNonCommaChar(string filePath, List<DateTime> datesToMatch)
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"Fehler: Datei nicht gefunden unter {filePath}");
                    return null; // Gibt null zurück, wenn die Datei nicht existiert
                }

                try
                {
                    // Vorbereiten der Suchdaten: HashSet für schnelle Suche
                    HashSet<string> searchDates = new HashSet<string>(
                        datesToMatch.Select(d => d.ToString("yyyy-MM-dd"))
                    );

                    string[] existingLines = File.ReadAllLines(filePath);

                    foreach (string line in existingLines)
                    {
                        if (string.IsNullOrWhiteSpace(line))
                        {
                            continue;
                        }

                        // Extrahiere das Datum aus der ersten Spalte
                        string[] parts = line.Split(new char[] { ' ', ',', '\t' }, 2, StringSplitOptions.RemoveEmptyEntries);

                        if (parts.Length > 0)
                        {
                            string dateStringInFile = parts[0].Trim();

                            // Prüfen, ob das Datum übereinstimmt
                            if (searchDates.Contains(dateStringInFile))
                            {
                                // PRÜFUNG DES LETZTEN ZEICHENS

                                if (line.Length > 0)
                                {
                                    char letztesZeichen = line[line.Length - 1];

                                    // 🌟 Wenn das Kriterium erfüllt ist (NICHT Komma), sofort zurückgeben! 🌟
                                    if (letztesZeichen != ',')
                                    {
                                        Console.WriteLine($"✅ Erstes Zeichen gefunden und wird zurückgegeben: {letztesZeichen}");
                                        return letztesZeichen; // Hier bricht die Funktion ab
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ein Fehler ist beim Lesen der Datei aufgetreten: {ex.Message}");
                }

                // Wenn die Schleife komplett durchläuft, ohne ein passendes Zeichen zu finden, gib null zurück
                return null;
            }
            public static void AddUniqueDatesToFile(string filePath, List<DateTime> newDates)
            {
                // Der Anhangstext, der an NEUE Zeilen angefügt wird.
                const string ANHANG_TEXT = ",0,0,";

                // Das HashSet MUSS NUR DIE REINEN DATUMS-STRINGS enthalten, um Duplikate korrekt zu finden.
                HashSet<string> existingDates = new HashSet<string>();
                List<string> allLinesToWrite = new List<string>();

                try
                {
                    // --- 1. Vorhandene Daten und Zeilen einlesen (UNVERÄNDERT) ---
                    if (File.Exists(filePath))
                    {
                        string[] existingLines = File.ReadAllLines(filePath);

                        foreach (string line in existingLines)
                        {
                            if (string.IsNullOrWhiteSpace(line))
                            {
                                allLinesToWrite.Add(line);
                                continue;
                            }

                            string[] parts = line.Split(new char[] { ' ', ',', '\t' }, 2, StringSplitOptions.RemoveEmptyEntries);

                            if (parts.Length > 0)
                            {
                                string dateString = parts[0].Trim();
                                // Fügt NUR das reine Datum zum Prüfen hinzu
                                existingDates.Add(dateString);
                                allLinesToWrite.Add(line);
                            }
                        }
                    }

                    // --- 2. Neue Daten hinzufügen und Duplikate verhindern (KORRIGIERT) ---
                    foreach (DateTime newDate in newDates)
                    {
                        // 🌟 KORREKTUR: Erstelle zuerst NUR den reinen Datums-String für die Prüfung
                        string pureDateString = newDate.ToString("yyyy-MM-dd");

                        // Prüfen, ob das REINE Datum bereits existiert
                        if (!existingDates.Contains(pureDateString))
                        {
                            // Wenn es eindeutig ist:

                            // 1. Füge das REINE Datum zum HashSet hinzu, um Duplikate innerhalb der neuen Liste zu vermeiden
                            existingDates.Add(pureDateString);

                            // 2. Erstelle die komplette neue Zeile mit Anhang und füge sie zur Schreibliste hinzu
                            string newLine = pureDateString + ANHANG_TEXT;
                            allLinesToWrite.Add(newLine);
                        }
                    }

                    // --- 3. Alle Zeilen in die Datei schreiben ---
                    File.WriteAllLines(filePath, allLinesToWrite);

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ein Fehler ist aufgetreten: {ex.Message}");
                }
            }

            public static void AppendStringToMatchingDates(string filePath, List<DateTime> datesToMatch, string textToAppend)
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"Fehler: Datei nicht gefunden unter {filePath}");
                    return;
                }

                try
                {
                    HashSet<string> searchDates = new HashSet<string>(
                        datesToMatch.Select(d => d.ToString("yyyy-MM-dd"))
                    );

                    string[] existingLines = File.ReadAllLines(filePath);
                    List<string> modifiedLines = new List<string>();
                    int changesCount = 0;

                    foreach (string line in existingLines)
                    {
                        if (string.IsNullOrWhiteSpace(line))
                        {
                            modifiedLines.Add(line);
                            continue;
                        }

                        // 1. Datum extrahieren
                        string[] parts = line.Split(new char[] { ' ', ',', '\t' }, 2, StringSplitOptions.RemoveEmptyEntries);

                        if (parts.Length > 0)
                        {
                            string dateStringInFile = parts[0].Trim();

                            // 2. Prüfen, ob das Datum übereinstimmt
                            if (searchDates.Contains(dateStringInFile))
                            {
                                // 🌟 NEUE LOGIK: Prüfen, ob der String angehängt werden soll 🌟

                                // Prüfen, ob der Text (oder ein ähnlicher Text) bereits vorhanden ist.
                                if (line.EndsWith(textToAppend))
                                {
                                    // Bereits vorhanden, Zeile unverändert beibehalten
                                    modifiedLines.Add(line);
                                }
                                // ANNAHME: Die letzte Spalte ist leer, wenn die Zeile mit einem Komma endet
                                else if (line.EndsWith(","))
                                {
                                    // Die Zeile endet mit einem Trennzeichen, also ist die letzte Spalte leer.
                                    string newLine = line + textToAppend;
                                    modifiedLines.Add(newLine);
                                    changesCount++;
                                }
                                else
                                {
                                    // Der Platz für den neuen Text ist bereits belegt oder die Zeile ist vollständig.
                                    // Zeile unverändert beibehalten

                                    modifiedLines.Add(line);
                                }
                            }
                            else
                            {
                                // Datum stimmt nicht überein, Zeile unverändert beibehalten
                                modifiedLines.Add(line);
                            }
                        }
                        else
                        {
                            modifiedLines.Add(line);
                        }
                    }

                    File.WriteAllLines(filePath, modifiedLines);
                    Console.WriteLine($"✅ {changesCount} Zeilen in der Datei wurden erfolgreich aktualisiert.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ein Fehler ist beim Bearbeiten der Datei aufgetreten: {ex.Message}");
                }
            }
        }
    }
    

}
