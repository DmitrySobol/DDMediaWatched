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
            pathLetter = "";
        public static Form1 form1;
        public static string[]
            args;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
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
    }
}
