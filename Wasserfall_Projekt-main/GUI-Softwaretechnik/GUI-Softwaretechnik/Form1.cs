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
    public partial class Login : Form
    {
        private static int wrongpasswordcounter = 0;
        private static int versuche = 5;
        private Write_File f1 = new Write_File();
        public Login()
        {
            InitializeComponent();
            label1.Visible = false;
            f1.Delete_File("usernames.txt");
            f1.delete_userId_D();
            //f1.Delete_File("david_0000.txt");
            Console.WriteLine(f1.Create_Folder("20_10_2025"));
            f1.Write_In_File("usernames.txt", "1,1\n");
            f1.Write_In_File("usernames.txt", "Manager,1\n");
            f1.Write_In_File("usernames.txt", "Magnus,1\n");
            f1.Write_In_File("usernames.txt", "Peter,1\n");
            f1.Write_In_File("usernames.txt", "Susi,1\n");
            f1.generateAll_userID_D("usernames.txt");
            f1.generateAll_userID_S("usernames.txt");
            
            //f1.create_userId_D("david", "0000");
            /*f1.write_in_userId_D("David_0000.txt", "01.01.2025", "09:00", "15:00");
            f1.write_in_userId_D("David_0000.txt", "01.02.2025", "13:00", "15:00");
            f1.write_in_userId_S("David_0000_S.txt", "27", "5", "19");
            f1.read_Values("David_0000.txt");
            Console.WriteLine(f1.getEinStempelZeit("01.01.2025"));
            f1.read_Values("David_0000_S.txt");
            Console.WriteLine(f1.getKrankTage());*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username = textBox1.Text;
            String password = textBox2.Text;
            Anmelden a = new Anmelden();
            versuche = 5;

            // Versuch Manager Login
           /* if (username == "Manager")
            {
                f1.Save_Current_User_Login(username);
                Console.Write(f1.Get_Current_User_Login());
                Menue_Gruppenleiter form2 = new Menue_Gruppenleiter(this);
                form2.Show();
                this.Hide();
                wrongpasswordcounter = 0;
                versuche = 5;

            }*/


             if (a.checkLogin(username, password))
            {
                f1.Save_Current_User_Login(username);
                Console.Write(f1.Get_Current_User_Login());
                Menue_Mitarbeiter form2 = new Menue_Mitarbeiter(this);
                form2.Show();
                this.Hide();
                wrongpasswordcounter = 0;
                versuche = 5;
            }

            else
            {
                wrongpasswordcounter++;
                versuche = versuche - wrongpasswordcounter;
                label1.Text = "Falsches Passwort!" + "Versuche Verbleibend: " + versuche.ToString();
                label1.Refresh();
                label1.Visible = true;
                if (versuche <= 0)
                {
                    label1.Text = "Nachricht über Fehlversuche wird an Chef geschickt!";
                    label1.Refresh();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
