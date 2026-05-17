using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace GUI_Softwaretechnik
{
    //Die Datein werden unter /bin/Debug angelegt
    internal class Write_File
    {
        private String[] username_password;
        private String[] values;
        private List<String[]> component=new List<string[]>();
        private String[] currentUsernameFiles;
        private static int counter = 0;
        public bool Create_Folder(String name)
        {
            if (Directory.Exists(name))
            {
                return true;
            }
            else if (!File.Exists(name))
            {
                Directory.CreateDirectory(name);
                return false;
            }
            return false;
        }
        public bool Delete_Folder(String name)
        {
            if (Directory.Exists(name))
            {
                Directory.Delete(name);
                return true;
            }
            else if (!File.Exists(name))
            {
                return false;
            }
            return false;
        }
        public void Write_In_File(String name, String inhalt)//Eventuell noch prüfen ob datei exestiert
        {
            File.AppendAllText(name, inhalt);
        }
        public void Write_In_File_AsString(String name, String[] inhalt)
        {
            File.WriteAllLines(name, inhalt);
        }
        
        public void Delete_File(String name)//Eventuell noch prüfen ob datei exestiert
        {
            File.Delete(name);
        }
        public String[] Read_File(String name)//Eventuell noch prüfen ob datei exestiert
        {
            return File.ReadAllLines(name);
        }
        ///////////////////////////////////////////////////////////////////////
        
        //Sorry wenn es nicht ganz objekt orientiert Programmiert ist, irgendwie fehlt mir gerade die Geduld
        //dafür das sauber zu programmieren HAHA sucks to suck -M

        public void create_userId_D(String name, String id)
        {
            String user = name + "_" + id + ".txt";
            File.AppendAllText(user, "");
            File.AppendAllText("idFile.txt", id+"\n");
        }
        public void create_userId_S(String name, String id)
        {
            //String userS = name + "_" + id + "U: " + "30" + "G: " + "10" + "K: " + "20";
            String userS = name + "_" + id + "_" + "S" + ".txt";
            write_in_userId_S(userS);
            File.AppendAllText(userS, "");
        }
        public void delete_userId_D()
        {
            String[] u = Directory.GetFiles(".","*.txt");
            for (int i = 0; i < u.Length; i++) {
                Delete_File(u[i]);
            }
        }
        public void write_in_userId_D(String name, String date, String einstempel_zeit, String ausstempfel_zeit, String k = "", String u = "", String g = "")
        {
            String str = date + "," + einstempel_zeit + "," + ausstempfel_zeit + "," + k + "," + u + "," + g + "\n";
            File.AppendAllText(name, str);
        }
        public void write_in_userId_S(String name, String urlaub="30", String gleitzeit="0", String krankheit="0")
        {
            String str = urlaub + "," + gleitzeit + "," + krankheit + "\n";
            File.WriteAllText(name, str);
        }
        public void write_in_userId_S_urlaub(String name, String urlaub)
        {
            read_Values(name);
            String gleitzeit = getGleitzeitTage();
            String krankheit = getKrankTage();
            write_in_userId_S(name, urlaub, gleitzeit, krankheit);
        }
        public void write_in_userId_S_Gleitzeit(String name, String gleitzeit)
        {
            read_Values(name);
            String urlaub = getUrlaubTage();
            String krankheit = getKrankTage();
            write_in_userId_S(name, urlaub, gleitzeit, krankheit);
        }
        public void write_in_userId_S_krankTage(String name, String krank)
        {
            read_Values(name);
            String gleitzeit = getGleitzeitTage();
            String urlaub = getUrlaubTage();
            write_in_userId_S(name, urlaub, gleitzeit, krank);
        }
        public void read_Values(String name)
        {
            component.Clear();
            values=Read_File(name);
            foreach(String value in values)
            {
                String[] commaSeperated = value.Split(',');
                component.Add(commaSeperated);
            }
        }
        
        //Hab überlegt ob das auch kürzer geht, komme gerade auf keinen Ansatz
        public String getDatum(String date)
        {
            foreach (String[] line in component)
            {
                if (line[0].Equals(date))
                {
                    return line[0];
                }
            }
            return "not found";
        }
        public String getEinStempelZeit(String date)
        {
            foreach(String[] line in component)
            {
                if (line[0].Equals(date))
                {
                    return line[1];
                }
            }
            return "not found";
        }
        public String getAusStempelZeit(String date)
        {
            foreach (String[] line in component)
            {
                if (line[0].Equals(date))
                {
                    return line[2];
                }
            }
            return "not found";
        }
        public String getKrank(String date)
        {
            foreach (String[] line in component)
            {
                if (line[0].Equals(date))
                {
                    return line[3];
                }
            }
            return "not found";
        }
        public String getUrlaub(String date)
        {
            foreach (String[] line in component)
            {
                if (line[0].Equals(date))
                {
                    return line[4];
                }
            }
            return "not found";
        }
        public String getGleitZeit(String date)
        {
            foreach (String[] line in component)
            {
                if (line[0].Equals(date))
                {
                    return line[5];
                }
            }
            return "not found";
        }
        
        public String getUrlaubTage()
        {
            foreach(String[] line in component)
            {
                return line[0];
            }
            return "not found";
        }

        public String getGleitzeitTage()
        {
            foreach (String[] line in component)
            {
                return line[1];
            }
            return "not found";
        }
        public String getKrankTage()
        {
            foreach (String[] line in component)
            {
                return line[2];
            }
            return "not found";
        }
        /*public int getId()
        {
            String[] names=Directory.GetFiles(".");
            foreach(String n in names)
            {
                
            }
        }*/
        public void generateAll_userID_D(String name)
        {
            String[] names = Read_File(name);
            int idgen = 0;
            String id;
            foreach(String n in names)
            {
                String[] usernames=n.Split(',');
                id = idgen.ToString("D4");
                create_userId_D(usernames[0], id);
                idgen++;
            }
        }
        public void generateAll_userID_S(String name)
        {
            String[] names = Read_File(name);
            int idgen = 0;
            String id;
            foreach (String n in names)
            {
                String[] usernames = n.Split(',');
                id = idgen.ToString("D4");
                create_userId_S(usernames[0], id);
                idgen++;
            }
        }

        //////////////////////////////////////////////////////////////////////
        public void Save_Current_User_Login(String username)
        {
            Delete_File("loginFile.txt");
            File.AppendAllText("loginFile.txt", username + "\n");
        }
        public String Get_Current_User_Login()
        {
            //Console.WriteLine(File.ReadAllText("loginFile.txt"));
            string nameAusLoginFile = File.ReadLines("loginFile.txt").FirstOrDefault()?.Trim();

            if (string.IsNullOrEmpty(nameAusLoginFile)) return null;

            // Baut "David_" zusammen, damit wir exakt suchen können
            string suchMuster = nameAusLoginFile + "_";

            // Sucht nach einer Datei, die mit "David_" beginnt (z.B. "David_0000.txt")
            string gefundenerPfad = Directory.GetFiles(".")
                                             .FirstOrDefault(pfad => Path.GetFileName(pfad)
                                             .StartsWith(suchMuster, StringComparison.OrdinalIgnoreCase));

            return gefundenerPfad != null ? Path.GetFileName(gefundenerPfad) : null;
        }

        public String Get_Current_User_Login_S()
        {
            string name = File.ReadLines("loginfile.txt").FirstOrDefault()?.Trim();
            if (string.IsNullOrEmpty(name)) return null;

            string suchPrefix = name + "_";

            string gefundenerPfad = Directory.GetFiles(".")
                .FirstOrDefault(pfad =>
                    Path.GetFileName(pfad).StartsWith(suchPrefix, StringComparison.OrdinalIgnoreCase) &&
                    Path.GetFileName(pfad).EndsWith("_S.txt", StringComparison.OrdinalIgnoreCase));

            return gefundenerPfad != null ? Path.GetFileName(gefundenerPfad) : null;
        }
    }
}
