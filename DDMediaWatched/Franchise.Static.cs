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
        public enum FranchiseType { Anime, Cartoon, Film, Dorama, No };
        public enum FranchiseDown { Downloaded, NoDownloaded };
        public enum FranchisePersentage { Zero, Started, Full };

        private static readonly List<Franchise> franchises = new List<Franchise>();
        private static readonly List<Franchise> filteredFranchises = new List<Franchise>();

        private static string
            MediaPath = "",
            SortBy = "",
            ColorBy = "",
            SearchMask = "";

        private static bool
            ReverseSort = false;

        private static readonly List<Franchise.FranchiseType>
            FiltersType = new List<Franchise.FranchiseType>();

        private static readonly List<Franchise.FranchiseDown>
            FiltersDownload = new List<Franchise.FranchiseDown>();

        private static readonly List<Franchise.FranchisePersentage>
            FiltersPersentage = new List<Franchise.FranchisePersentage>();

        private static readonly List<bool>
            FiltersURL = new List<bool>(),
            FiltersNames = new List<bool>();

        public static void LoadMedia()
        {
            FileStream f = new FileStream(MediaPath + "Media.bin", FileMode.Open, FileAccess.Read);
            int p = BinaryFile.ReadInt32(f);
            for (int j = 0; j < p; j++)
            {
                Franchise.franchises.Add(new Franchise(f));
            }
            f.Dispose();
            f.Close();
        }

        public static void SaveMedia()
        {
            FileStream f = new FileStream(MediaPath + "Media.bin", FileMode.Create, FileAccess.Write);
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
            Franchise.MediaPath = path;
        }

        public static string GetMediaPath()
        {
            return Franchise.MediaPath;
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

        private static void UpdateFilteredFranchises()
        {
            Franchise.filteredFranchises.Clear();
            foreach (Franchise el in Franchise.franchises)
                if (IsFilterOn(el))
                    Franchise.filteredFranchises.Add(el);
        }

        public static List<Franchise> GetFilteredFranchises(bool update)
        {
            if (update)
                UpdateFilteredFranchises();
            return Franchise.filteredFranchises;
        }

        private static bool IsFilterOn(Franchise franchise)
        {
            bool b = true;
            if (!FiltersType.Contains(franchise.GetFranchiseType()))
                b = false;
            if (!FiltersDownload.Contains(franchise.GetDownloadedType()))
                b = false;
            if (!FiltersPersentage.Contains(franchise.GetPersentageType()))
                b = false;
            if (!FiltersURL.Contains(franchise.IsURLExists()))
                b = false;
            if (!FiltersNames.Contains(franchise.HasSecondaryName()))
                b = false;
            if (!franchise.GetAllNames().ToLower().Contains(SearchMask))
                b = false;
            return b;
        }

        public static void SetSortBy(string sortBy, bool isReverse)
        {
            Franchise.SortBy = sortBy;
            Franchise.ReverseSort = isReverse;
        }

        public static string GetSortBy()
        {
            return Franchise.SortBy;
        }

        public static void SetSearchMask(string SearchMask)
        {
            Franchise.SearchMask = SearchMask.ToLower();
        }

        public static string GetSearchMask()
        {
            return Franchise.SearchMask;
        }

        public static bool IsReverseSort()
        {
            return ReverseSort;
        }

        public static void SetColorBy(string colorBy)
        {
            Franchise.ColorBy = colorBy;
        }
        //Filters
        public static void ClearFilters()
        {
            FiltersType.Clear();
            FiltersDownload.Clear();
            FiltersPersentage.Clear();
            FiltersURL.Clear();
            FiltersNames.Clear();
        }

        public static void AddFiltersType(Franchise.FranchiseType p)
        {
            FiltersType.Add(p);
        }

        public static void AddFiltersDown(Franchise.FranchiseDown p)
        {
            FiltersDownload.Add(p);
        }

        public static void AddFiltersPersentage(Franchise.FranchisePersentage p)
        {
            FiltersPersentage.Add(p);
        }

        public static void AddFiltersURL(bool b)
        {
            FiltersURL.Add(b);
        }

        public static void AddFiltersNames(bool b)
        {
            FiltersNames.Add(b);
        }

        public static void FindAllSize()
        {
            foreach (Franchise franchise in Franchise.franchises)
                franchise.FindSize();
        }

        public static int GetFranchiseCountWithName(string name)
        {
            int franchiseCount = 0;
            foreach (Franchise franchise in franchises)
                if (franchise.GetName() == name)
                    franchiseCount++;
            return franchiseCount;
        }
        //Draw Statistic
        public static int GetAllCount(bool IsFiltered)
        {
            int count;
            if (IsFiltered)
                count = CountAllCount(Franchise.filteredFranchises);
            else
                count = CountAllCount(Franchise.franchises);
            return count;
        }

        private static int CountAllCount(List<Franchise> franchises)
        {
            int count = franchises.Count;
            return count;
        }

        public static long GetAllSize(bool IsFiltered)
        {
            long size;
            if (IsFiltered)
                size = CountAllSize(Franchise.filteredFranchises);
            else
                size = CountAllSize(Franchise.franchises);
            return size;
        }

        private static long CountAllSize(List<Franchise> franchises)
        {
            long size = 0;
            foreach (Franchise f in franchises)
                size += f.GetSize();
            return size;
        }

        public static int GetAllWatchedLength(bool IsFiltered)
        {
            int Length;
            if (IsFiltered)
                Length = CountAllWatchedLength(Franchise.filteredFranchises);
            else
                Length = CountAllWatchedLength(Franchise.franchises);
            return Length;
        }

        private static int CountAllWatchedLength(List<Franchise> franchises)
        {
            int Length = 0;
            foreach (Franchise f in franchises)
                Length += f.GetWatchedLength();
            return Length;
        }

        public static int GetAllUniqueWatchedLength(bool IsFiltered)
        {
            int Length;
            if (IsFiltered)
                Length = CountAllUniqueWatchedLength(Franchise.filteredFranchises);
            else
                Length = CountAllUniqueWatchedLength(Franchise.franchises);
            return Length;
        }

        private static int CountAllUniqueWatchedLength(List<Franchise> franchises)
        {
            int Length = 0;
            foreach (Franchise f in franchises)
                Length += f.GetUniqueWatchedLength();
            return Length;
        }

        public static int GetAllNoTouchedLength(bool IsFiltered)
        {
            int Length;
            if (IsFiltered)
                Length = CountAllNoTouchedLength(Franchise.filteredFranchises);
            else
                Length = CountAllNoTouchedLength(Franchise.franchises);
            return Length;
        }

        private static int CountAllNoTouchedLength(List<Franchise> franchises)
        {
            int Length = 0;
            foreach (Franchise f in franchises)
                Length += f.GetNoTouchedLength();
            return Length;
        }
    }
}
