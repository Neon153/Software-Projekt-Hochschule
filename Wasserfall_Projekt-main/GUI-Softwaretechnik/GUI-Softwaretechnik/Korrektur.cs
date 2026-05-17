using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_Softwaretechnik
{
    public partial class Korrektur : Form
    {
        ein_und_ausstempeln f3;
        Write_File f1 = new Write_File();
        Work w1 = new Work();
        bool zurueckGeklickt = false;
        private object show_Date;
        private object f2;
        private object form2;

        public Korrektur(ein_und_ausstempeln form3)
        {
            InitializeComponent();
            f3 = form3;

            DateTime t = DateTime.Now;
            f2 = form2;
            this.f2 = f2;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void back_to_ein_und_ausstemplen_Click(object sender, EventArgs e)
        {   
            zurueckGeklickt = true;
            f3.Show();
            this.Close();
            
        }

        private void correctur_calender_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void Korrektur_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!zurueckGeklickt)
            {
                System.Windows.Forms.Application.Exit();

            }
        }

        private void Korrektur_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            correctNewGleitzeit();
            w1.Work2(anfangszeit.Text, endzeit.Text);
            int start = w1.ConvertInTime(anfangszeit.Text);
            int end = w1.ConvertInTime(endzeit.Text);
            int diff = w1.CalcDiff(start, end);
            String workingtime = w1.ConvertInString(diff);
            workingtime1.Text = workingtime;
            workingtime1.Refresh();
            corrrectNewDates(anfangszeit.Text, endzeit.Text, "", "", "");
        }
        private void correctNewGleitzeit()
        {
            String datum = Get_date().ToString("dd.MM.yyyy");
            f1.read_Values(f1.Get_Current_User_Login());
            String ein = f1.getEinStempelZeit(datum);
            String aus = f1.getAusStempelZeit(datum);
            int start = w1.ConvertInTime(ein);
            int end = w1.ConvertInTime(aus);
            int diff = w1.CalcDiff(start, end);
            //String workingtime = w1.ConvertInString(diff);
            String alteGleitzeit=calc_Gleitzeit_return(diff);
            Console.WriteLine("Alte Gleitzeit" + alteGleitzeit);
            int start_neu = w1.ConvertInTime(anfangszeit.Text);
            int end_neu = w1.ConvertInTime(endzeit.Text);
            int diff_neu = w1.CalcDiff(start_neu, end_neu);
            calc_Gleitzeit(diff_neu, alteGleitzeit);
        }
        private DateTime Get_date()
        {
            return korrektTime.Value.Date;
        }
        private String calc_Gleitzeit_return(int diff)
        {
            f1.read_Values(f1.Get_Current_User_Login_S());
            String actGleizeit = f1.getGleitzeitTage();
            int actGleitzeit_int = int.Parse(actGleizeit);
            int gleitzeit = 0;
            String gleitzeitString = "null";
            if (diff > 546)
            {
                int ueberstunden = diff - 546;
                if (ueberstunden < 1)
                {
                    gleitzeit = 0;
                }
                else if (ueberstunden >= 1)
                {
                    gleitzeit = ueberstunden / 60;
                    //gleitzeit = gleitzeit + actGleitzeit_int;
                    gleitzeitString = gleitzeit.ToString();
                    Console.WriteLine("GleitzeitString" + gleitzeitString);
                }
                return gleitzeitString;
            }
            return "0";
        }
        private void calc_Gleitzeit(int diff,String alteGleitZeit)
        {
            f1.read_Values(f1.Get_Current_User_Login_S());
            String actGleizeit = f1.getGleitzeitTage();
            int actGleitzeit_int = int.Parse(actGleizeit);
            actGleitzeit_int = actGleitzeit_int - int.Parse(alteGleitZeit);
            int gleitzeit = 0;
            String gleitzeitString = actGleizeit;
            if (diff > 546)
            {
                int ueberstunden = diff - 546;
                if (ueberstunden < 1)
                {
                    gleitzeit = 0;
                    gleitzeitString = actGleizeit;
                }
                else if (ueberstunden >= 1)
                {
                    gleitzeit = ueberstunden / 60;
                    gleitzeit = gleitzeit + actGleitzeit_int;
                    gleitzeitString = gleitzeit.ToString();
                }
            }
            f1.write_in_userId_S_Gleitzeit(f1.Get_Current_User_Login_S(), gleitzeitString);
        }
        private void corrrectNewDates(String einstempel_zeit, String ausstempel_zeit, String k, String u, String g)
        {
            
            DateTime date = Get_date();

            String datumSuchstring = date.ToString("dd.MM.yyyy");
            String neueZeile = datumSuchstring + "," + einstempel_zeit + "," + ausstempel_zeit + "," + k + "," + u + "," + g;
            String[] lines = f1.Read_File(f1.Get_Current_User_Login());
            List<string> neueLinesListe = new List<string>();

            bool neueZeileWurdeHinzugefuegt = false;

            foreach (string aktuelleZeile in lines)
            {
                if (aktuelleZeile.StartsWith(datumSuchstring + ","))
                {
                    if (!neueZeileWurdeHinzugefuegt)
                    {
                        neueLinesListe.Add(neueZeile);
                        neueZeileWurdeHinzugefuegt = true;
                    }
                }
                else
                {
                    neueLinesListe.Add(aktuelleZeile);
                }
            }
            f1.Write_In_File_AsString(f1.Get_Current_User_Login(), neueLinesListe.ToArray());
        }
    }
}












 