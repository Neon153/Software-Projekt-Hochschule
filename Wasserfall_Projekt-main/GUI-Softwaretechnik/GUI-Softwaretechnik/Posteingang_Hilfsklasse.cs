using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_Softwaretechnik
{
    internal class Posteingang_Hilfsklasse
    {
        /*public class Nachricht
        {
            public string Name { get; set; }
            public string Betreff { get; set; }
            public string Inhalt { get; set; }
        }
        private void LoadNotifications()
        {
            // Die Pfade zur Textdatei
            string filePath = "nachrichten.txt";

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
                        string[] parts = line.Split(';');

                        // Prüft, ob wir mindestens 3 Teile (Betreff, Nachricht, Name) haben
                        if (parts.Length >= 3)
                        {
                            nachrichtenListe.Add(new Nachricht
                            {
                                Betreff = parts[0].Trim(),
                                Inhalt = parts[1].Trim(),
                                Name = parts[2].Trim()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Fehler beim Laden der Datei: {ex.Message}", "Dateifehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Wenn keine Daten aus der Datei geladen wurden (oder die Datei nicht existiert),

            if (!nachrichtenListe.Any())
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
            }


            // Löscht alle vorhandenen Elemente vor dem Neuladen
            flowLayoutPanel1.Controls.Clear();

            foreach (var nachricht in nachrichtenListe)
            {
                var item = new NachrichtenElement
                {
                    // Wichtig: Jetzt wird der Name als eindeutige Kennung genutzt
                    ItemID = nachricht.Name,
                    NachrichtenBetreff = nachricht.Betreff,
                    NachrichtenInhalt = nachricht.Inhalt
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

            // Führe die Bestätigungs-Logik aus
            // Beispiel: Datenbank-Update mit item.ItemID
            MessageBox.Show($"Nachricht {item.ItemID} wurde BESTÄTIGT.");

            // Entferne das Element aus dem FlowLayoutPanel, da die Aktion abgeschlossen ist
            flowLayoutPanel1.Controls.Remove(item);

            // Optional: Füge Logik hinzu, um das Element aus der zugrundeliegenden Datenquelle zu entfernen
        }

        private void NotificationItem_Rejected(object sender, EventArgs e)
        {
            var item = sender as NachrichtenElement;
            if (item == null) return;

            MessageBox.Show($"Nachricht {item.ItemID} wurde ABGELEHNT.");
            flowLayoutPanel1.Controls.Remove(item);
        }

        private void NotificationItem_Deleted(object sender, EventArgs e)
        {
            var item = sender as NachrichtenElement;
            if (item == null) return;

            MessageBox.Show($"Nachricht {item.ItemID} wurde GELÖSCHT.");
            flowLayoutPanel1.Controls.Remove(item);
        }*/
    }
}
