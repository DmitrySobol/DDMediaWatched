using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DDMediaWatched
{
    public static class Profile
    {
        public static string User { get; set; }

        private static string Path { get; set; } = "null";

        public readonly static List<DateTimeWatchCount> DTWatchCount = new List<DateTimeWatchCount>();

        public static void SetPath(string path)
        {
            Profile.Path = System.IO.Path.GetDirectoryName(path) + @"\";
            Profile.User = System.IO.Path.GetFileNameWithoutExtension(Profile.Path);
        }

        public static void LoadCow()
        {
            Franchise.ResetCow();
            if (Profile.Path == "null")
                Profile.Path = Franchise.GetMediaPath();
            FileStream f = new FileStream(Profile.Path + User + ".bin", FileMode.Open, FileAccess.Read);
            int p = BinaryFile.ReadInt32(f);
            for (int j = 0; j < p; j++)
                Franchise.RecordToSeries(new Record(f));
            f.Dispose();
            f.Close();
        }

        public static void SaveCow()
        {
            List<Record> records = new List<Record>();
            Franchise.AddCowRecords(records);

            if (Profile.Path == "null")
                Profile.Path = Franchise.GetMediaPath();
            FileStream f = new FileStream(Profile.Path + User + ".bin", FileMode.Create, FileAccess.Write);
            BinaryFile.WriteInt32(f, records.Count);
            foreach (Record el in records)
                el.SaveToBin(f);
            f.Dispose();
            f.Close();
        }

        public static void LoadTime()
        {
            DTWatchCount.Clear();
            if (Profile.Path == "null")
                Profile.Path = Franchise.GetMediaPath();
            FileStream f = new FileStream(Profile.Path + User + ".date.bin", FileMode.Open, FileAccess.Read);
            int p = BinaryFile.ReadInt32(f);
            for (int j = 0; j < p; j++)
                DTWatchCount.Add(new DateTimeWatchCount(f));
            f.Dispose();
            f.Close();
        }

        public static void SaveTime()
        {
            if (Profile.Path == "null")
                Profile.Path = Franchise.GetMediaPath();
            FileStream f = new FileStream(Profile.Path + User + ".date.bin", FileMode.Create, FileAccess.Write);
            BinaryFile.WriteInt32(f, DTWatchCount.Count);
            foreach (DateTimeWatchCount el in DTWatchCount)
                el.SaveToBin(f);
            f.Dispose();
            f.Close();
        }

        public static int GetTodayWatched()
        {
            if (DTWatchCount.Count == 0)
                return 0;
            DateTime dtNow = DateTime.Now;
            DateTimeWatchCount dtwc = DTWatchCount[DTWatchCount.Count - 1];
            DateTime dt = dtwc.GetDateTime();
            if (dtNow.Date == dt.Date)
                return dtwc.WatchCount;
            return 0;
        }

        public static void SetTodayWatched(short cow)
        {
            DateTime dtNow = DateTime.Now;
            if (DTWatchCount.Count == 0)
            {
                DTWatchCount.Add(new DateTimeWatchCount(dtNow.Year, dtNow.Month, dtNow.Day, cow));
                return;
            }
            DateTimeWatchCount dtwc = DTWatchCount[DTWatchCount.Count - 1];
            DateTime dt = dtwc.GetDateTime();
            if (dtNow.Date == dt.Date)
                dtwc.WatchCount = cow;
            else
                DTWatchCount.Add(new DateTimeWatchCount(dtNow.Year, dtNow.Month, dtNow.Day, cow));
        }

        public static void AddTodayWatched(short cow)
        {
            DateTime dtNow = DateTime.Now;
            if (DTWatchCount.Count == 0)
            {
                DTWatchCount.Add(new DateTimeWatchCount(dtNow.Year, dtNow.Month, dtNow.Day, cow));
                return;
            }
            DateTimeWatchCount dtwc = DTWatchCount[DTWatchCount.Count - 1];
            DateTime dt = dtwc.GetDateTime();
            if (dtNow.Date == dt.Date)
                dtwc.WatchCount += cow;
            else
                DTWatchCount.Add(new DateTimeWatchCount(dtNow.Year, dtNow.Month, dtNow.Day, cow));
        }
    }
}
