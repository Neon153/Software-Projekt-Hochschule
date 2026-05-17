using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_Softwaretechnik
{
    internal class Benutzer_Verwaltung
    {
        private String name;
        private String password;
        public Benutzer_Verwaltung(String username, String upassword)
        {
            name = username;
            password = upassword;//test
        }

        public String GetUserName()
        {
            return name;
        }
        public String GetPassword()
        {
            return password;
        }
    }
}
