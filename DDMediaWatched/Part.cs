using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace DDMediaWatched
{
    public class Part
    {
        private string
            name;//Name of part (Season, Film ...)

        private int
            commonLength;//common length

        private long
            sizeD;//Size on disk in bytes

        private string
            path;//Path to part

        private byte
            isPathFile;//Is path file? Else directory

        private readonly List<Series>
            series;//Series

        private readonly Franchise
            parentFranchise;

        public Part(Franchise parent)
        {
            name = "";
            commonLength = 1440;
            sizeD = 0;
            path = "";
            isPathFile = 0;
            parentFranchise = parent;
            series = new List<Series>
            {
                new Series(1440, 0)
            };
        }

        public Part(string name, string path, int serCount, bool autoSize, bool autoLength, Franchise parent)
        {
            this.name = name;
            this.path = path;
            int typeP = StaticUtils.IsFileOrDirr(this.path);
            this.isPathFile = 0;
            if (typeP == 1)
                this.isPathFile = 1;
            if (autoSize)
                this.sizeD = StaticUtils.GetPathSize(this.path, this.IsFull());
            else
                this.sizeD = 0;
            if (this.sizeD < 0)
                this.sizeD = 0;
            this.commonLength = 1440;
            if (autoLength)
            {
                int p = StaticUtils.HMStoSecs(StaticUtils.GetVideoLength(this.path));
                if (p >= 0)
                    this.commonLength = p;
            }
            parentFranchise = parent;
            series = new List<Series>();
            for (int i = 0; i < serCount; i++)
                series.Add(new Series());
            this.SetSeriesLengthToCommon();
        }

        public Part(FileStream f, Franchise parent)
        {
            parentFranchise = parent;
            //name
            name = BinaryFile.ReadString(f);
            //sizeD
            sizeD = BinaryFile.ReadInt64(f);
            //path
            path = BinaryFile.ReadString(f);
            //isPathFile
            isPathFile = BinaryFile.ReadByte(f);
            //common length
            commonLength = BinaryFile.ReadInt32(f);
            //series
            int p = BinaryFile.ReadInt32(f);
            series = new List<Series>();
            for (int i = 0; i < p; i++)
                series.Add(new Series(f));
        }

        public void SaveToBin(FileStream f)
        {
            //name
            BinaryFile.WriteString(f, name);
            //sizeD
            BinaryFile.WriteInt64(f, sizeD);
            //path
            BinaryFile.WriteString(f, path);
            //isPathFile
            BinaryFile.WriteByte(f, isPathFile);
            //common length
            BinaryFile.WriteInt32(f, commonLength);
            //series
            BinaryFile.WriteInt32(f, series.Count);
            foreach (Series s in series)
                s.SaveToBin(f);
        }
        //Name
        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }
        //Length
        public int GetLength()
        {
            int length = 0;
            foreach (Series series in this.series)
                length += series.GetLength();
            return length;
        }

        public int GetWatchedLength()
        {
            int length = 0;
            foreach (Series series in this.series)
                length += series.GetWatchedLength();
            return length;
        }

        public int GetUniqueWatchedLength()
        {
            int length = 0;
            foreach (Series series in this.series)
                length += series.GetUniqueWatchedLength();
            return length;
        }

        public int GetDownloadedLength()
        {
            if (sizeD == 0)
                return 0;
            return this.GetLength();
        }

        public int GetNoTouchedLength()
        {
            int length = 0;
            foreach (Series series in this.series)
                length += series.GetNoTouchedLength();
            return length;
        }

        public double GetPersentage()
        {
            double persentage = this.GetUniqueWatchedLength() * 100;
            persentage /= this.GetLength();
            return persentage;
        }

        public int GetCommonLength()
        {
            return this.commonLength;
        }

        public void SetCommonLength(int length)
        {
            this.commonLength = length;
        }

        public void SetSeriesLengthToCommon()
        {
            foreach (Series s in series)
                s.SetLength(this.commonLength);
        }
        //Size
        public long GetSize()
        {
            return sizeD;
        }

        public void SetSize(long size)
        {
            this.sizeD = size;
        }

        public int FindSize()
        {
            long newSize = 0;
            int output = 0;
            if (this.path == "")
            {
                newSize = 0;
            }
            string path = parentFranchise.GetAbsolutePath();
            if (path == "null")
            {
                Program.Log("There is no media drives or no parent's path!");
                return output;
            }
            if (this.path.Length > 0)
            {
                path += this.path;
                newSize = StaticUtils.GetPathSize(path, this.IsFull());
                if (newSize == -1)
                {
                    Program.Log(String.Format("{0} - {1}. Path \"{2}\" has been removed!", this.parentFranchise.GetName(), this.GetName(), this.GetPath()));
                    this.path = "";
                    newSize = 0;
                }
            }
            if (sizeD != newSize)
                Program.Log(String.Format("{0} - {1} size has been updated from {2:f2} GB to {3:f2} GB", this.parentFranchise.GetName(), this.GetName(), sizeD / 1024d / 1024 / 1024, newSize / 1024d / 1024 / 1024));
            //else
            //    Program.Log(String.Format("{0,-35} size hasn't been updated!", this.getName()));
            if (sizeD == 0 && newSize > 0)
                output = 1;
            if (sizeD == newSize)
                output = 2;
            if (sizeD > 0 && newSize == 0)
                output = 3;
            if (sizeD != newSize && sizeD > 0 && newSize > 0)
                output = 4;
            sizeD = newSize;
            return output;
            //0 no path
            //1 0 -> x
            //2 x == x
            //3 x -> 0
            //4 x -> y
        }
        //Path
        public string GetPath()
        {
            return path;
        }

        public string GetAbsolutePath()
        {
            string s = "";
            if (this.path != "")
                s = parentFranchise.GetAbsolutePath() + this.path;
            return s;
        }

        public void SetPath(string path)
        {
            if (path.Length > 3)
            {
                if (path[0] == '"')
                    path = path.Substring(1, path.Length - 2);
                if (path.Substring(1, 2) == @":\")
                    path = path.Substring(3);
                if (path.Length >= GetParent().GetPath().Length)
                    if (path.Substring(0, GetParent().GetPath().Length) == GetParent().GetPath())
                    {
                        path = path.Substring(GetParent().GetPath().Length);
                    }
                this.path = path;
            }
            else
                this.path = path;
        }

        public byte GetIsPathFile()
        {
            return isPathFile;
        }

        public void SetIsPathFile(bool isPathFile)
        {
            if (isPathFile)
                this.isPathFile = 1;
            else
                this.isPathFile = 0;
        }
        //Series
        public List<Series> GetSeries()
        {
            return series;
        }

        public void SetSeriesCount(int count)
        {
            if (this.GetSeries().Count == count)
                return;
            if (this.GetSeries().Count < count)
            {
                count -= this.GetSeries().Count;
                for (int i = 0; i < count; i++)
                    this.GetSeries().Add(new Series(this.GetCommonLength(), 0));
            }
            else
            {
                count = this.GetSeries().Count - count;
                for (int i = 0; i < count; i++)
                    this.GetSeries().RemoveAt(this.GetSeries().Count - 1);
            }
        }
        //Other
        public bool IsFull()
        {
            if (isPathFile == 1)
                return true;
            if (isPathFile == 0)
                return false;
            return false;//ERROR
        }

        public Franchise GetParent()
        {
            return parentFranchise;
        }

        public void AddWatch()
        {
            foreach (Series s in series)
                s.AddWatch();
        }

        public override string ToString()
        {
            string s = "";
            s += String.Format("{0,-15}| {1}\r\n", "Name", this.GetName());
            s += String.Format("{0,-15}| {1}\r\n", "Path", this.GetPath());
            s += String.Format("{0,-15}| {1}\r\n", "Path type", this.IsFull() ? "File" : "Dirr");
            s += String.Format("{0,-15}| {1:f2} GB\r\n", "Size on disk", this.GetSize() / 1024D / 1024 / 1024);
            s += String.Format("{0,-15}| {1:f2} Hr\r\n", "Length", this.GetLength() / 3600d);
            s += String.Format("{0,-15}| {1:f2} Hr\r\n", "Length W", this.GetWatchedLength() / 3600d);
            s += String.Format("{0,-15}| {1:f2} Hr\r\n", "Length WU", this.GetUniqueWatchedLength() / 3600d);
            int i = 0;
            foreach (Series ser in series)
            {
                i++;
                s += String.Format("{0,4}| {1}\r\n", i, ser.ToString());
            }
            return s;
        }

        public ListViewItem ToListViewItem()
        {
            ListViewItem item = new ListViewItem()
            {
                Text = this.GetName()
            };
            ListViewItem.ListViewSubItem si;
            //Length
            si = new ListViewItem.ListViewSubItem
            {
                Tag = "Length",
                Text = String.Format("{0:f2} Hr", this.GetLength() / 3600d)
            };
            item.SubItems.Add(si);
            //Size
            si = new ListViewItem.ListViewSubItem
            {
                Tag = "Size",
                Text = this.GetSize() == 0 ? "" : String.Format("{0:f2} Gb", this.GetSize() / 1024d / 1024 / 1024)
            };
            item.SubItems.Add(si);
            //BPS
            si = new ListViewItem.ListViewSubItem
            {
                Tag = "BPS",
                Text = this.GetSize() == 0 ? "" : String.Format("{0:f0} Mb", (this.GetSize() / 1024d / 1024) / (this.GetLength() / 60d / 24))
            };
            item.SubItems.Add(si);
            //%
            si = new ListViewItem.ListViewSubItem
            {
                Tag = "%",
                Text = String.Format("{0:f0}%", this.GetPersentage())
            };
            item.SubItems.Add(si);
            //Path
            si = new ListViewItem.ListViewSubItem
            {
                Tag = "Path",
                Text = this.GetPath()
            };
            item.SubItems.Add(si);
            return item;
        }
    }
}
