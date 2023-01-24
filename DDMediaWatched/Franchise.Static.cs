using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DDMediaWatched
{
    public partial class Franchise
    {
        public static List<Franchise> franchises = new List<Franchise>();

        private static string mediaPath = "";

        public static void LoadMedia()
        {
            FileStream f = new FileStream(mediaPath + "Media.bin", FileMode.Open, FileAccess.Read);
            int p = BinaryFile.FileReadInt32(f);
            for (int j = 0; j < p; j++)
            {
                Franchise.franchises.Add(new Franchise(f));
            }
            f.Dispose();
            f.Close();
        }

        public static void SaveMedia()
        {
            FileStream f = new FileStream(mediaPath + "Media.bin", FileMode.Create, FileAccess.Write);
            f.Write(BitConverter.GetBytes(franchises.Count), 0, 4);
            foreach (Franchise el in Franchise.franchises)
            {
                el.SaveToBin(f);
            }
            f.Dispose();
            f.Close();
        }

        public static void SetMediaPath(string path)
        {
            Franchise.mediaPath = path;
        }

        public static string GetMediaPath()
        {
            return Franchise.mediaPath;
        }
    }
}
