using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GUI_Softwaretechnik
{
    internal class DateiHilfen
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

        public static void DeletlastCharandAppendStringToMatchingDates(string filePath, List<DateTime> datesToMatch, string textToAppend)
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
                            //wenn die Zeile mit g oder u endet
                            else if (line.EndsWith("g") || line.EndsWith("u"))
                            {
                                // Die Zeile endet mit einem Trennzeichen, also ist die letzte Spalte leer.
                                string newLine = line.Remove(15) + textToAppend;
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

        public static void RemoveMatchingLine(string lineToRemove, string filePath)
        {
            // 1. Prüfen, ob die Datei existiert
            if (!File.Exists(filePath))
            {
                // Optional: Hier könntest du eine Exception werfen oder eine Meldung ausgeben.
                // Für dieses Beispiel beenden wir die Funktion einfach.
                System.Console.WriteLine($"Fehler: Die Datei {filePath} wurde nicht gefunden.");
                return;
            }

            try
            {
                // 2. Alle Zeilen aus der Datei lesen
                // File.ReadAllLines liest die gesamte Datei in ein String-Array.
                string[] allLines = File.ReadAllLines(filePath);

                // 3. Filtern: Nur die Zeilen behalten, die NICHT mit dem übergebenen String übereinstimmen.
                // Die StringComparison.Ordinal sorgt für einen exakten, fall-sensitiven Vergleich.
                IEnumerable<string> updatedLines = allLines.Where(line =>
                    !line.Equals(lineToRemove, StringComparison.Ordinal));

                // 4. Prüfen, ob sich die Anzahl der Zeilen geändert hat
                if (updatedLines.Count() < allLines.Length)
                {
                    // 5. Die gefilterten Zeilen zurück in die Datei schreiben
                    // File.WriteAllLines überschreibt die gesamte Datei.
                    File.WriteAllLines(filePath, updatedLines);
                    System.Console.WriteLine($"Die passende Zeile wurde aus {filePath} entfernt.");
                }
                else
                {
                    System.Console.WriteLine($"Keine übereinstimmende Zeile gefunden, Datei unverändert.");
                }
            }
            catch (IOException ex)
            {
                System.Console.WriteLine($"Ein Fehler ist beim Dateizugriff aufgetreten: {ex.Message}");
            }
        }
    }
}
