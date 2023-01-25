using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text;

namespace DDMediaWatched
{
    static class Program
    {
        public static Form1 form1;
        public static string[]
            args;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            {
                Program.args = args;
                form1 = new Form1();
                Application.Run(form1);
            }
        }
    }
}
