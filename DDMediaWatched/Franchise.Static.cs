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
        private static readonly List<Franchise> franchises = new List<Franchise>();

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

        public static void AddFranchise(Franchise franchise)
        {
            Franchise.franchises.Add(franchise);
        }

        public static bool RemoveFranchise(string name)
        {
            for (int i = 0; i < Franchise.franchises.Count; i++)
                if (Franchise.franchises[i].GetName() == name)
                {
                    Franchise.franchises.RemoveAt(i);
                    return true;
                }
            return false;
        }

        public static Franchise GetFranchise(string name)
        {
            foreach (Franchise franchise in Franchise.franchises)
                if (franchise.GetName() == name)
                    return franchise;
            return null;
        }

        public static List<Franchise> GetFranchisesType()
        {
            List<Franchise> franchisesType = new List<Franchise>();
            foreach (Franchise el in Franchise.franchises)
                if (IsTypeOn(el))
                    franchisesType.Add(el);
            return franchisesType;
        }

        private static bool IsTypeOn(Franchise franchise)
        {
            bool b = true;
            if (!Program.form1.TypeOnType.Contains(franchise.GetFranchiseType()))
                b = false;
            if (!Program.form1.TypeOnDown.Contains(franchise.GetDownloadedType()))
                b = false;
            if (!Program.form1.TypeOnPersentage.Contains(franchise.GetPersentageType()))
                b = false;
            if (!Program.form1.TypeOnURL.Contains(franchise.IsURLExists()))
                b = false;
            return b;
        }

        public static void FindAllSize()
        {
            foreach (Franchise franchise in Franchise.franchises)
                franchise.FindSize();
        }

        public static long GetAllSize()
        {
            long size = 0;
            foreach (Franchise f in Franchise.franchises)
                size += f.GetSize();
            return size;
        }

        public static int GetAllWatchedLength()
        {
            int watchedLength = 0;
            foreach (Franchise f in Franchise.franchises)
                watchedLength += f.GetWatchedLength();
            return watchedLength;
        }

        public static int GetAllUniqueWatchedLength()
        {
            int watchedUniqueLength = 0;
            foreach (Franchise f in Franchise.franchises)
                watchedUniqueLength += f.GetUniqueWatchedLength();
            return watchedUniqueLength;
        }
    }
}
