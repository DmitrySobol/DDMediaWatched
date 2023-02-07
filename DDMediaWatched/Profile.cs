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
    }
}
