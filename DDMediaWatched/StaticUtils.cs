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
            mediaDrivePath = "null",
            mediaDriveSerialInfo = "null";
        public static void LoadConfigs()
        {
            FileStream fs = new FileStream("config.cfg", FileMode.Open, FileAccess.Read);
            StreamReader t = new StreamReader(fs, Encoding.UTF8);
            Franchise.SetMediaPath(t.ReadLine());
            mediaDriveSerialInfo = t.ReadLine();
            t.Dispose();
            t.Close();
            fs.Dispose();
            fs.Close();
        }

        private static void SaveConfigs()
        {
            FileStream fs = new FileStream("config.cfg", FileMode.Create, FileAccess.Write);
            StreamWriter t = new StreamWriter(fs, Encoding.UTF8);
            t.WriteLine(Franchise.GetMediaPath());
            t.WriteLine(mediaDriveSerialInfo);
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

        public static int HMStoSecs(string s)
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
            return ret;
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
            mediaDrivePath = "null";
            string[] drivers = Environment.GetLogicalDrives();
            for (int i = 0; i < drivers.Length; i++)
            {
                if (GetSerialInfoFromDriveLetter(drivers[i].Substring(0, 2)) == mediaDriveSerialInfo)
                {
                    mediaDrivePath = drivers[i];
                    break;
                }
            }
        }

        public static void SetMediaDrivePath(string path)
        {
            mediaDriveSerialInfo = GetSerialInfoFromDriveLetter(path);
            SaveConfigs();
            FindMediaDrivePath();
        }

        public static bool IsMediaDriveExists()
        {
            if (mediaDrivePath == "null")
                return false;
            else
                return true;
        }

        public static string GetMediaDrivePath()
        {
            return mediaDrivePath;
        }

        private static string GetSerialInfoFromDriveLetter(string driveLetter)
        {
            if (driveLetter.Length != 2)
                return "";
            try
            {
                var partitions = new ManagementObjectSearcher(
                    "ASSOCIATORS OF {Win32_LogicalDisk.DeviceID='" +
                    driveLetter +
                    "'} WHERE ResultClass=Win32_DiskPartition");
                foreach (var partition in partitions.Get())
                {
                    var drives = new ManagementObjectSearcher(
                        "ASSOCIATORS OF {Win32_DiskPartition.DeviceID='" +
                        partition["DeviceID"] +
                        "'} WHERE ResultClass=Win32_DiskDrive");
                    foreach (var drive in drives.Get())
                        return String.Format("[{0}][{1}][{2}]", drive["Model"], drive["SerialNumber"], partition["Index"]);
                }
            }
            catch { }
            return "<unknown>";
        }
    }
}
