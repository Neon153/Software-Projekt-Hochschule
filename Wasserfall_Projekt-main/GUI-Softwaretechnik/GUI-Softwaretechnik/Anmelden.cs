using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GUI_Softwaretechnik
{
    internal class Anmelden
    {
        private Benutzer_Verwaltung b;
        private String[] username;
        private Write_File f=new Write_File();
        public Anmelden()
        {
            //b = benutzer;
        }
        /*public bool checkLogin(String username, String passwort)
        {
            return username == b.GetUserName() && passwort == b.GetPassword();
        }*/
        public bool checkLogin(String name, String pass)//Test
        {
            String[] values = f.Read_File("usernames.txt");

            foreach (String value in values)
            {

                String[] parts = value.Split(',');
                String username=parts[0];
                String passwort = parts[1];
                Console.WriteLine(parts[0] + " " + parts[1]);
                if (username == name)
                {
                    if (passwort == pass)
                    {
                        return true;
                    }
                    else if (username != name || passwort != pass)
                    {
                        return false;
                    }
                }
                
            }
            return false;
        }
    }
}
