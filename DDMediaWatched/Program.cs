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
        public static byte[]
            buf = new byte[8] { 0, 0, 0, 0, 0, 0, 0, 0 },
            BigBuf = new byte[1024];
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

        public static int FileReadInt32(FileStream f)
        {
            f.Read(buf, 0, 4);
            return BitConverter.ToInt32(buf, 0);
        }

        public static void FileWriteInt32(FileStream f, int a)
        {
            f.Write(BitConverter.GetBytes(a), 0, 4);
        }

        public static long FileReadInt64(FileStream f)
        {
            f.Read(buf, 0, 8);
            return BitConverter.ToInt64(buf, 0);
        }

        public static void FileWriteInt64(FileStream f, long a)
        {
            f.Write(BitConverter.GetBytes(a), 0, 8);
        }

        public static string FileReadString(FileStream f)
        {
            f.Read(buf, 0, 4);
            int p = BitConverter.ToInt32(buf, 0);
            f.Read(BigBuf, 0, p);
            return Encoding.UTF8.GetString(BigBuf, 0, p);
        }

        public static void FileWriteString(FileStream f, string a)
        {
            BigBuf = Encoding.UTF8.GetBytes(a);
            f.Write(BitConverter.GetBytes(BigBuf.Length), 0, 4);
            f.Write(BigBuf, 0, BigBuf.Length);
        }

        public static byte FileReadByte(FileStream f)
        {
            f.Read(buf, 0, 1);
            return buf[0];
        }

        public static void FileWriteByte(FileStream f, byte a)
        {
            buf[0] = a;
            f.Write(buf, 0, 1);
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
                    size = 0;
                    FileInfo f = new FileInfo(path);
                    size = f.Length;
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
            if (File.Exists(path) || Directory.Exists(path))
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
