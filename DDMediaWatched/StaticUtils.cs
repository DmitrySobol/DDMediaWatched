using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Management;

namespace DDMediaWatched
{
    public static class StaticUtils
    {
        private static string
            MediaDrivePath = "null",
            MediaDriveSerialInfo = "null",
            ShikiPath = "null",
            CountryLine = "";

        private static readonly Dictionary<string, string>
            SerialInfos = new Dictionary<string, string>();

        private static readonly Dictionary<string, string>
            Countries = new Dictionary<string, string>();

        private static readonly List<string>
            ForWhomNames = new List<string>();

        public static void LoadConfigs()
        {
            FileStream fs = new FileStream("config.cfg", FileMode.Open, FileAccess.Read);
            StreamReader t = new StreamReader(fs, Encoding.UTF8);
            Franchise.SetMediaPath(t.ReadLine());
            MediaDriveSerialInfo = t.ReadLine();
            ForWhomNames.Clear();
            string[] p = t.ReadLine().Split(';');
            for (int i = 1; i < int.Parse(p[0]) + 1; i++)
            {
                ForWhomNames.Add(p[i]);
            }
            Profile.User = t.ReadLine();
            ShikiPath = t.ReadLine();
            CountryLine = t.ReadLine();
            foreach (string s in CountryLine.Split(';'))
            {
                if (s.Length > 3)
                    Countries.Add(s.Substring(0, 2), s.Substring(3));
            }
            t.Dispose();
            t.Close();
            fs.Dispose();
            fs.Close();
        }

        public static void SaveConfigs()
        {
            FileStream fs = new FileStream("config.cfg", FileMode.Create, FileAccess.Write);
            StreamWriter t = new StreamWriter(fs, Encoding.UTF8);
            t.WriteLine(Franchise.GetMediaPath());
            t.WriteLine(MediaDriveSerialInfo);
            string p = ForWhomNames.Count.ToString();
            foreach (string s in ForWhomNames)
                p += ";" + s;
            t.WriteLine(p);
            t.WriteLine(Profile.User);
            t.WriteLine(ShikiPath);
            t.WriteLine(CountryLine);
            t.Dispose();
            t.Close();
            fs.Dispose();
            fs.Close();
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

        public static short HMStoSecs(string s)
        {
            int ret = 0, koef = 1;
            string[] hms = s.Split(':');
            if (hms.Length != 3)
                return -1;
            for (int i = 2; i >= 0; i--)
            {
                if (!int.TryParse(hms[i], out int p))
                    return -1;
                ret += p * koef;
                koef *= 60;
            }
            if (ret > 32767)
                return -1;
            return (short)ret;
        }

        public static string SecsToHMS(int s)
        {
            string ret = String.Format("{0}:{1:00}:{2:00}", s / 3600, s / 60 % 60, s % 60);
            return ret;
        }

        public static Color GetColor(string colorBy, Franchise franchise)
        {
            Color ret = Color.FromArgb(255, 255, 255);
            switch (colorBy)
            {
                case "Persentage (3)":
                    {
                        switch (franchise.GetPersentageType())
                        {
                            case Franchise.FranchisePersentage.Zero:
                                ret = Color.FromArgb(255, 191, 191);
                                break;
                            case Franchise.FranchisePersentage.Started:
                                ret = Color.FromArgb(255, 255, 191);
                                break;
                            case Franchise.FranchisePersentage.Full:
                                ret = Color.FromArgb(191, 255, 191);
                                break;
                        }
                    }
                    break;
                case "Persentage (Gradient)":
                    {
                        if (franchise.GetPersentage() > 50)
                        {
                            double pColor = 191 + (100 - franchise.GetPersentage()) / 50 * 64;
                            ret = Color.FromArgb((int)Math.Round(pColor), 255, 191);
                        }
                        else
                        {
                            double pColor = 191 + franchise.GetPersentage() / 50 * 64;
                            ret = Color.FromArgb(255, (int)Math.Round(pColor), 191);
                        }
                    }
                    break;
            }
            return ret;
        }

        public static void FindMediaDrivePath()
        {
            MediaDrivePath = "null";
            LoadSerialInfo();
            if (SerialInfos.ContainsKey(MediaDriveSerialInfo))
                MediaDrivePath = SerialInfos[MediaDriveSerialInfo]  + @"\";
        }

        public static void SetMediaDriveLetter(string DriveLetter)
        {
            LoadSerialInfo();
            MediaDriveSerialInfo = SerialInfos.ToDictionary(x => x.Value, x => x.Key)[DriveLetter];
            MediaDrivePath = DriveLetter + @"\";
            SaveConfigs();
        }

        public static bool IsMediaDriveExists()
        {
            if (MediaDrivePath == "null")
                return false;
            else
                return true;
        }

        public static string GetMediaDrivePath()
        {
            return MediaDrivePath;
        }

        public static string GetShikiPath()
        {
            return ShikiPath;
        }

        public static string GetCountryByCode(string code)
        {
            if (Countries.ContainsKey(code))
                return Countries[code];
            else
                return "NULL";
        }

        public static int GetCountryIndexByCode(string code)
        {
            if (Countries.ContainsKey(code))
            {
                int i = 0;
                foreach (KeyValuePair<string, string> p in Countries)
                {
                    if (p.Key == code)
                        return i;
                    else
                        i++;
                }
            }
            return Countries.Count;
        }

        public static string[] GetCountriesArray()
        {
            string[] a = Countries.Values.ToArray();
            string[] result = new string[a.Length + 1];
            for (int i = 0; i < a.Length; i++)
                result[i] = a[i];
            result[result.Length - 1] = "NULL";
            return result;
        }

        private static void LoadSerialInfo()
        {
            SerialInfos.Clear();
            ManagementObjectSearcher partitions = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_LogicalDisk");
            foreach (ManagementBaseObject partition in partitions.Get())
            {
                string s = String.Format("[{0}][{1}][{2}][{3}]", partition["FileSystem"], partition["Size"], partition["VolumeName"], partition["VolumeSerialNumber"]);
                SerialInfos.Add(s, partition["DeviceID"].ToString());
            }
        }

        public static string[] GetForWhomNames()
        {
            return ForWhomNames.ToArray();
        }

        public static string GetForWhomName(int index)
        {
            if (index >= 0 && index < ForWhomNames.Count)
                return ForWhomNames[index];
            else
                return "ERROR";
        }
    }
}
