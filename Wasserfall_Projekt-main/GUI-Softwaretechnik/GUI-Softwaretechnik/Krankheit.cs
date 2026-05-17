using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_Softwaretechnik
{
    internal class Krankheit
    {
        DateTime date1;
        DateTime date2;

        public void SetAnfang(DateTime d)
        {
            date1 = d;
        }
        public void SetEnde(DateTime d2)
        {
            date2 = d2;
        }

        public TimeSpan diff()
        {
            return date2.Subtract(date1);
        }
        public String convertToString(TimeSpan t1)
        {
            return t1.ToString();
        }

    }
}
