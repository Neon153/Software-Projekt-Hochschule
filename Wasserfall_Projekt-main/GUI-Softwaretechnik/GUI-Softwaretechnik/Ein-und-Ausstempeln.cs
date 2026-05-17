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
    public partial class ein_und_ausstempeln : Form
    {
        Menue_Mitarbeiter f2;
        ein_und_ausstempeln f3;
        Write_File f1 = new Write_File();
        bool zurueckGeklickt = false;
        public ein_und_ausstempeln(Menue_Mitarbeiter form2)
        {
            InitializeComponent();
            DateTime t = DateTime.Now;
            show_Date.Text = t.ToString();
            f2 = form2;
        }


        private void back1_Click(object sender, EventArgs e)
        {   
            
            zurueckGeklickt = true;
            f2.Show();
            this.Close();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Work w1 = new Work();
            w1.Work3(anfangszeit.Text, endzeit.Text);
            int start = w1.ConvertInTime(anfangszeit.Text);
            int end = w1.ConvertInTime(endzeit.Text);
            int diff = w1.CalcDiff(start, end);
            String workingtime = w1.ConvertInString(diff);
            workingtime1.Text = workingtime;
            workingtime1.Refresh();
            calc_Gleitzeit(diff);
        }
        private void calc_Gleitzeit(int diff)
        {
            f1.read_Values(f1.Get_Current_User_Login_S());
            String actGleizeit = f1.getGleitzeitTage();
            int actGleitzeit_int=int.Parse(actGleizeit);
            int gleitzeit = 0;
            String gleitzeitString=actGleizeit;
            if(diff > 546)
            {
                int ueberstunden = diff - 546;
                if (ueberstunden < 1)
                {
                    gleitzeit = 0;
                    gleitzeitString = actGleizeit;
                }
                else if (ueberstunden >= 1)
                {
                    gleitzeit = ueberstunden/60;
                    gleitzeit = gleitzeit + actGleitzeit_int;
                    gleitzeitString=gleitzeit.ToString();
                }
                f1.write_in_userId_S_Gleitzeit(f1.Get_Current_User_Login_S(),gleitzeitString);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Korrektur k1 = new Korrektur(this);
            k1.Show();
        }

        private void ein_und_ausstempeln_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!zurueckGeklickt)
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        private void ein_und_ausstempeln_Load(object sender, EventArgs e)
        {

        }
    }
}
