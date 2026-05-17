using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_Softwaretechnik
{
    internal class Work
    {
        private String start;
        private String end;
        private Write_File f1 = new Write_File();
        public Work() {
            //start=starttime;
            //end=endtime;
            //f1.write_in_userId_D(f1.Get_Current_User_Login(),DateTime.Today.ToString("d"),start,end);
        }
        public void Work2(String starttime, String endtime)//für korrektur
        {
            start=starttime;
            end=endtime;
        }
        public void Work3(String starttime, String endtime)//für normales ein und ausstempeln
        {
            start = starttime;
            end = endtime;
            f1.write_in_userId_D(f1.Get_Current_User_Login(), DateTime.Today.ToString("d"), start, end);
        }

        public int ConvertInTime(String time){
            String hour=time.Substring(0,2);
            String minute=time.Substring(3);
            int hoursinminutes=int.Parse(hour);
            int minutes=int.Parse(minute);
            hoursinminutes = hoursinminutes * 60;
            int gesamtminuten = hoursinminutes + minutes;
            return gesamtminuten;
        }

        public int CalcDiff(int startAt, int endAt)
        {
            return endAt-startAt;
        }

        public String ConvertInString(int time)
        {
            int stunden = time / 60;
            int minuten = time % 60;
            String hourinstring = stunden.ToString();
            String minuteinstring = minuten.ToString();
            return hourinstring+"h"+":"+minuteinstring+"min";
        }
        //Moin Leute, wenn ihr das lesen könnt dann hab ich es hinbekommen mit Github
        //Anleitung wie es funktioniert hat.
        //1. änderung im code machen
        //2.bei Git-Änderungen eine Nachricht in das große Feld eintragen. Dann alle Committen auswählen.
        //Zu guter letzt pushen
        //https://learn.microsoft.com/de-de/visualstudio/version-control/git-push-remote?view=vs-2022
        //Test von Adrian der diese Zeile hinzufügt :D
        //Test von Melek :)

        public String CorrectTime(String time)
        {
            return "";
        }
    }
}
