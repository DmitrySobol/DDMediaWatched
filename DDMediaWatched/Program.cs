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
        public static string
            pathLetter = "null";
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

        public static void DirectorySize(string path, ref long size)
        {
            string[] s;
            try
            {
                s = Directory.GetFiles(path);
                for (int i = 0; i < s.Length; i++)
                {
                    size += new FileInfo(s[i]).Length;
                }
            }
            catch { }
            try
            {
                s = Directory.GetDirectories(path);
                for (int i = 0; i < s.Length; i++)
                {
                    DirectorySize(s[i], ref size);
                }
            }
            catch { }
        }

        public static long GetPathSize(string path, bool IsFile)
        {
            long size = -1;
            if (IsFile)
                if (File.Exists(path))
                {
                    size = new FileInfo(path).Length;
                }
            if (!IsFile)
                if (Directory.Exists(path))
                {
                    size = 0;
                    DirectorySize(path, ref size);
                }
            return size;
        }

        public static int IsFileOrDirr(string path)
        {
            int ret = -1;
            if (Directory.Exists(path))
            {
                ret = 0;
            }
            if (File.Exists(path))
            {
                ret = 1;
            }
            return ret;
        }

        public static string GetVideoLength(string path)
        {
            string value = "NULL";
            if (File.Exists(path))
            {
                string dir = Path.GetDirectoryName(path);
                string file = Path.GetFileName(path);
                Type shellAppType = Type.GetTypeFromProgID("Shell.Application");
                dynamic shell = Activator.CreateInstance(shellAppType);
                dynamic folder = shell.NameSpace(dir);
                dynamic folderItem = folder.ParseName(file);
                value = folder.GetDetailsOf(folderItem, 27).ToString();
            }
            return value;
        }

        public static int HMStoSecs(string s)
        {
            int ret = 0, p = 0;
            string[] hms = s.Split(':');
            if (hms.Length != 3)
                return -1;
            if (!int.TryParse(hms[0], out p))
                return -1;
            ret += p * 3600;
            if (!int.TryParse(hms[1], out p))
                return -1;
            ret += p * 60;
            if (!int.TryParse(hms[2], out p))
                return -1;
            ret += p;
            return ret;
        }
    }
}
