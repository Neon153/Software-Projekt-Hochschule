using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms_Zeitmanagement
{
    public partial class Kalender : UserControl
    {
        // --- Interne Variablen und Konstanten ---

        // Tooltip und Klick-Logik
        private ToolTip dateToolTip;
        private DateTime? lastHoveredDate = null;
        private bool isColorToggleEnabled = true;

        // Daten
        private Dictionary<DateTime, Color> specialDayColors = new Dictionary<DateTime, Color>();
        private DateTime displayMonth = DateTime.Today;

        // Layout-Konstanten
        private const int DAYS_IN_WEEK = 7;
        private const int TOTAL_ROWS = 6; // 6 Zeilen für volle Monatsdarstellung
        private const int HEADER_HEIGHT = 30;
        private const int DAY_NAME_HEIGHT = 25; // Höhe für "Mo, Di, Mi..."

        // Dynamische Layout-Variablen
        private int cellWidth, cellHeight;
        private Rectangle titleRect;
        private Rectangle prevMonthRect;
        private Rectangle nextMonthRect;

        // --- Event für Datenanbindung ---

        /// <summary>
        /// Wird ausgelöst, wenn der Kalender Daten für einen neuen Monat benötigt.
        /// </summary>
        public event EventHandler<DateTime> RequestDataForMonth;

        /// <summary>
        /// Wird ausgelöst, wenn der Benutzer auf ein gültiges Datum klickt 
        /// (unabhängig von der Farbumschaltung). Es sendet das angeklickte 
        /// DateTime-Objekt an die Form.
        /// </summary>
        public event EventHandler<DateTime> DateClicked; // <<< NEU: DateClicked Event

        // --- Öffentliche Eigenschaften ---

        /// <summary>
        /// Aktiviert oder deaktiviert die Farbumschaltung beim Klicken auf ein Datum.
        /// </summary>
        public bool IsColorToggleEnabled
        {
            get { return isColorToggleEnabled; }
            set { isColorToggleEnabled = value; }
        }

        // --- Konstruktor ---

        public Kalender()
        {
            InitializeComponent();
            this.DoubleBuffered = true; // Reduziert Flackern

            // ToolTip für Maus-Hover initialisieren
            dateToolTip = new ToolTip();
            dateToolTip.ShowAlways = true;
        }

        // --- Öffentliche Methoden ---

        /// <summary>
        /// Lädt Farbinformationen für einen Monat in den Kalender.
        /// (Wird von der Form aufgerufen, nachdem 'RequestDataForMonth' ausgelöst wurde)
        /// </summary>
        public void SetMonthColorData(Dictionary<DateTime, Color> monthData)
        {
            if (monthData == null)
            {
                return;
            }

            // Neue Daten mit vorhandenen zusammenführen
            foreach (var entry in monthData)
            {
                this.SetDayColor(entry.Key, entry.Value, false); // Nicht einzeln neu zeichnen
            }

            // Einmal am Ende neu zeichnen
            this.Invalidate();
        }

        /// <summary>
        /// Setzt die Farbe für ein einzelnes Datum.
        /// </summary>
        public void SetDayColor(DateTime date, Color color, bool redraw = true)
        {
            specialDayColors[date.Date] = color;
            if (redraw)
            {
                this.Invalidate(); // Fordert Neuzeichnung an
            }
        }

        /// <summary>
        /// Ruft die Farbe für ein einzelnes Datum ab.
        /// </summary>
        public Color GetDayColor(DateTime date)
        {
            if (specialDayColors.TryGetValue(date.Date, out Color color))
            {
                return color;
            }
            return Color.Transparent; // Standard
        }

        /// <summary>
        /// Wechselt zum nächsten Monat und löst das Datenanforderungs-Event aus.
        /// </summary>
        public void GoToNextMonth()
        {
            displayMonth = displayMonth.AddMonths(1);
            RaiseRequestDataForMonth();
            this.Invalidate();
        }

        /// <summary>
        /// Wechselt zum vorherigen Monat und löst das Datenanforderungs-Event aus.
        /// </summary>
        public void GoToPreviousMonth()
        {
            displayMonth = displayMonth.AddMonths(-1);
            RaiseRequestDataForMonth();
            this.Invalidate();
        }

        // --- Interne Hilfsmethoden ---

        /// <summary>
        /// Löst das Event sicher aus, um neue Monatsdaten anzufordern.
        /// </summary>
        private void RaiseRequestDataForMonth()
        {
            // Löscht alte Farben, die nicht aus der DB kommen (manuelle Klicks)
            // Optional: Wenn manuelle Klicks erhalten bleiben sollen, diese Zeile auskommentieren
            specialDayColors.Clear();

            RequestDataForMonth?.Invoke(this, displayMonth);
        }

        /// <summary>
        /// Berechnet, welches Datum sich an einer bestimmten Pixel-Position befindet.
        /// </summary>
        private DateTime? GetDateAtLocation(Point location)
        {
            // Klick war in der Kopfzeile ODER in der Wochentagsleiste
            if (location.Y < HEADER_HEIGHT + DAY_NAME_HEIGHT)
            {
                return null;
            }

            // Zellen-Dimensionen berechnen
            int cellWidth = this.Width / DAYS_IN_WEEK;
            int cellHeight = (this.Height - HEADER_HEIGHT - DAY_NAME_HEIGHT) / TOTAL_ROWS;

            if (cellHeight <= 0 || cellWidth <= 0) return null;

            // Relative Position im Datumsgitter
            int relativeY = location.Y - HEADER_HEIGHT - DAY_NAME_HEIGHT;
            int week = relativeY / cellHeight;
            int day = location.X / cellWidth;

            if (week >= TOTAL_ROWS || day >= DAYS_IN_WEEK)
            {
                return null;
            }

            // Logik für "Montag zuerst"
            DateTime firstDayOfMonth = new DateTime(displayMonth.Year, displayMonth.Month, 1);
            // (int)DayOfWeek: So=0, Mo=1, ..., Sa=6
            // Wir wollen: So -> 6 Tage zurück, Mo -> 0, Di -> 1, ..., Sa -> 5
            int daysToSubtract = (int)firstDayOfMonth.DayOfWeek == (int)DayOfWeek.Sunday ? 6 : (int)firstDayOfMonth.DayOfWeek - 1;
            DateTime firstVisibleDay = firstDayOfMonth.AddDays(-daysToSubtract);

            DateTime clickedDate = firstVisibleDay.AddDays((week * DAYS_IN_WEEK) + day);

            return clickedDate;
        }

        // --- Event-Handler für das Control ---

        /// <summary>
        /// Beim ersten Laden des Controls die Daten für den aktuellen Monat anfordern.
        /// </summary>
        private void Kalender_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode) // Wichtig: Nicht im Designer ausführen
            {
                RaiseRequestDataForMonth();
            }
        }

        /// <summary>
        /// Haupt-Zeichenmethode. Wird bei Invalidate() aufgerufen.
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // --- 1. KOPFZEILE (Monatsname und Pfeile) ---
            titleRect = new Rectangle(0, 0, this.Width, HEADER_HEIGHT);
            prevMonthRect = new Rectangle(0, 0, HEADER_HEIGHT, HEADER_HEIGHT);
            nextMonthRect = new Rectangle(this.Width - HEADER_HEIGHT, 0, HEADER_HEIGHT, HEADER_HEIGHT);

            g.FillRectangle(Brushes.DarkGray, titleRect);
            StringFormat sfTitle = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            g.DrawString(displayMonth.ToString("MMMM yyyy"), this.Font, Brushes.White, titleRect, sfTitle);
            g.DrawString("<", this.Font, Brushes.White, prevMonthRect, sfTitle);
            g.DrawString(">", this.Font, Brushes.White, nextMonthRect, sfTitle);

            // --- 2. WOCHENTAGS-NAMEN (Mo, Di, Mi, ...) ---
            string[] dayNames = { "Mo", "Di", "Mi", "Do", "Fr", "Sa", "So" };
            cellWidth = this.Width / DAYS_IN_WEEK;
            cellHeight = (this.Height - HEADER_HEIGHT - DAY_NAME_HEIGHT) / TOTAL_ROWS;

            if (cellHeight <= 0) return; // Verhindert Absturz bei zu kleiner Höhe

            StringFormat sfDayName = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

            for (int i = 0; i < DAYS_IN_WEEK; i++)
            {
                Rectangle dayNameRect = new Rectangle(i * cellWidth, HEADER_HEIGHT, cellWidth, DAY_NAME_HEIGHT);
                g.FillRectangle(Brushes.LightGray, dayNameRect);
                g.DrawString(dayNames[i], this.Font, Brushes.Black, dayNameRect, sfDayName);
            }

            // --- 3. DATEN-GITTER (Montag zuerst) ---
            DateTime firstDayOfMonth = new DateTime(displayMonth.Year, displayMonth.Month, 1);
            int daysToSubtract = (int)firstDayOfMonth.DayOfWeek == (int)DayOfWeek.Sunday ? 6 : (int)firstDayOfMonth.DayOfWeek - 1;
            DateTime firstVisibleDay = firstDayOfMonth.AddDays(-daysToSubtract);
            DateTime currentDate = firstVisibleDay;

            StringFormat sfDate = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

            for (int week = 0; week < TOTAL_ROWS; week++)
            {
                for (int day = 0; day < DAYS_IN_WEEK; day++)
                {
                    Rectangle cellRect = new Rectangle(
                        day * cellWidth,
                        HEADER_HEIGHT + DAY_NAME_HEIGHT + week * cellHeight, // Offset
                        cellWidth,
                        cellHeight
                    );

                    // Hintergrundfarbe (aus Datenbank oder Klick)
                    Color bgColor = GetDayColor(currentDate);
                    if (bgColor != Color.Transparent)
                    {
                        using (Brush brush = new SolidBrush(bgColor))
                        {
                            g.FillRectangle(brush, cellRect);
                        }
                    }

                    // Umrandung
                    g.DrawRectangle(Pens.Gray, cellRect.X, cellRect.Y, cellRect.Width - 1, cellRect.Height - 1);

                    // Tagesnummer (Grau für Tage außerhalb des Monats)
                    Brush textBrush = (currentDate.Month == displayMonth.Month) ? Brushes.Black : Brushes.Gray;
                    g.DrawString(currentDate.Day.ToString(), this.Font, textBrush, cellRect, sfDate);

                    currentDate = currentDate.AddDays(1);
                }
            }
        }

        /// <summary>
        /// Verarbeitet Klicks für Navigation und Farbumschaltung.
        /// </summary>
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            // 1. Navigation prüfen
            if (prevMonthRect.Contains(e.Location))
            {
                GoToPreviousMonth();
                return;
            }
            else if (nextMonthRect.Contains(e.Location))
            {
                GoToNextMonth();
                return;
            }

            DateTime? clickedDate = GetDateAtLocation(e.Location);

            if (clickedDate.HasValue)
            {
                DateTime date = clickedDate.Value.Date;

                // --- NEUE FUNKTIONALITÄT: DateClicked Event auslösen ---
                DateClicked?.Invoke(this, date);
                // --------------------------------------------------------

                // 2. Farbumschaltung nur, wenn aktiviert
                if (!IsColorToggleEnabled)
                {
                    return;
                }

                // Logik zur variablen Farbumschaltung (Zyklus)
                Color currentColor = GetDayColor(date);
                Color nextColor = Color.Transparent; // Standard

                if (currentColor == Color.Transparent) nextColor = Color.Red;
                else if (currentColor == Color.Red) nextColor = Color.Blue;
                else if (currentColor == Color.Blue) nextColor = Color.Green;
                // Wenn Green, zurück zu Transparent

                SetDayColor(date, nextColor, true); // Mit Neuzeichnen
            }
        }

        /// <summary>
        /// Zeigt den Tooltip an, wenn die Maus über einem Datum ist.
        /// </summary>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            DateTime? hoveredDate = GetDateAtLocation(e.Location);

            if (hoveredDate.HasValue)
            {
                if (hoveredDate.Value != lastHoveredDate)
                {
                    // ToolTip-Text setzen (z.B. "18.10.2025")
                    dateToolTip.SetToolTip(this, hoveredDate.Value.ToShortDateString());
                    lastHoveredDate = hoveredDate.Value;
                }
            }
            else
            {
                // Maus ist außerhalb (Kopfzeile, Wochentage), Tooltip leeren
                if (lastHoveredDate != null)
                {
                    dateToolTip.SetToolTip(this, "");
                    lastHoveredDate = null;
                }
            }
        }

        /// <summary>
        /// Stellt sicher, dass das Control neu gezeichnet wird, wenn die Größe geändert wird.
        /// </summary>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate(); // Neuzeichnen bei Größenänderung
        }
    }
}


/*1. Visuelle Darstellung & Layout

 * Diese Funktionen bestimmen, was der Benutzer sieht:

 * 

 * Monats-Kopfzeile: Zeigt den aktuellen Monat und das Jahr an (z.B. "Oktober 2025").

 * Wochentags-Leiste: Zeigt eine separate Leiste unter der Kopfzeile mit den Abkürzungen 

 * der Wochentage (Mo, Di, Mi...).

 * 

 * Wochenstart am Montag: Der Kalender ist logisch und visuell so aufgebaut,

 * dass die Woche links mit dem Montag beginnt und rechts mit dem Sonntag endet.

 * 

 * 6-Wochen-Raster: Zeigt immer 6 Zeilen (insgesamt 42 Tage) an, um sicherzustellen,

 * dass alle Tage eines Monats Platz finden, egal wie sie fallen.

 * 

 * Tage anderer Monate (Grau): Tage, die in das Raster fallen, aber zum vorherigen

 * oder nächsten Monat gehören, werden zur Orientierung mit grauer Schrift dargestellt.

 * 

 * Dynamische Hintergrundfarben: Kann jedem Tag eine individuelle Hintergrundfarbe zuweisen 

 * (basierend auf Klicks oder geladenen Daten).

 * 

 * 

 * 2. Benutzer-Interaktion (Maus)

 * Diese Funktionen reagieren auf Eingaben des Benutzers

 * 

 * :Monats-Navigation: Der Benutzer kann auf die Pfeile (< und >) in der Kopfzeile klicken,

 * um monatsweise vor- oder zurückzublättern.

 * 

 * Datum-Tooltip (Hover): Hovert (fährt) der Benutzer mit der Maus über ein Datum, 

 * erscheint ein kleines Textfeld (Tooltip), das das genaue Datum im Kurzformat (z.B. 21.10.2025) anzeigt.

 * 

 * Variable Farbumschaltung (Klick): Wenn aktiviert, kann der Benutzer auf ein Datum klicken,

 * um dessen Farbe in einem festgelegten Zyklus zu ändern (aktuell: Transparent -> Rot -> Blau -> Grün -> Transparent).

 * 

 * Deaktivierbare Klick-Färbung: Diese Klick-Funktion zum Färben kann von außen gesteuert werden.

 * 

 * 

 * 3. Schnittstelle & Datenanbindung (Für den Programmierer)

 * Diese Funktionen (Eigenschaften, Methoden und Events) lassen das 

 * Control mit dem Rest Ihres Programms (z.B. der Form1) kommunizieren:

 * 

 * IsColorToggleEnabled (Eigenschaft): Ein öffentlicher bool-Wert (true/false).

 * Wenn Sie diesen auf false setzen, ist die variable Farbumschaltung (Punkt 2) deaktiviert.

 * 

 * RequestDataForMonth (Ereignis): Das wichtigste Ereignis für die Datenanbindung.

 * Der Kalender löst dies aus, wenn er geladen wird und jedes Mal, wenn der Benutzer den Monat wechselt.

 * Es "bittet" die Haupt-Form, ihm die Farbdaten für den neu angezeigten Monat zu senden.

 * 

 * DateClicked (Ereignis): Wird immer ausgelöst, wenn der Benutzer auf ein gültiges Datum 

 * klickt (unabhängig von der Farbumschaltung). Es sendet das angeklickte 

 * DateTime-Objekt an die Form, damit diese das Datum "im Hintergrund speichern" oder darauf reagieren kann.

 * 

 * SetMonthColorData(Dictionary<DateTime, Color> data) (Methode): Die "Antwort" auf das 

 * RequestDataForMonth-Ereignis. Die Form ruft diese Methode auf und übergibt dem Kalender 

 * ein Dictionary (eine Liste) mit allen Daten und Farben, die für den Monat aus der Datenbank (oder Ihrem Array)

 * geladen wurden.

 * 

 * SetDayColor(DateTime date, Color color) (Methode): Eine Hilfsmethode, um programmatisch 

 * die Farbe eines einzelnen Tages zu setzen.

 * 

 * 

 * 4. Automatisches VerhaltenDynamische Größenanpassung (OnResize): Wenn Sie das Kalender-Steuerelement im 

 * Formulardesigner (oder zur Laufzeit) größer oder kleiner ziehen, wird es automatisch neu gezeichnet (Invalidate()) 

 * und die Zellengrößen werden neu berechnet, um den Platz auszufüllen.*/