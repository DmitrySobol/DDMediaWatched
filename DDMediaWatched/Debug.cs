using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DDMediaWatched
{
    public static class Debug
    {
        private static DateTime
            dt;

        public static void SetDateTime()
        {
            dt = DateTime.Now;
        }

        public static void WriteTimeSpan()
        {
            DateTime dt2 = DateTime.Now;
            File.AppendAllText(@"D:\1.txt", String.Format("{0,0:f2} ms\r\n", (dt2 - dt).TotalMilliseconds));
            SetDateTime();
        }

        public static void WriteTimeSpan(string s)
        {
            DateTime dt2 = DateTime.Now;
            File.AppendAllText(@"D:\1.txt", String.Format("{0} - {1,0:f2} ms\r\n", s, (dt2 - dt).TotalMilliseconds));
            SetDateTime();
        }
    }
}
