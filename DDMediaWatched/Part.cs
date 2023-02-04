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
        public string Name { get; set; }//Name of part (Season, Film ...)

        public int CommonLength { get; set; }//common length

        public long DiskSize { get; private set; }//Size on disk in bytes

        private string path;
        public string Path
        {
            get
            {
                return path;
            }
            set
            {
                if (value.Length > 5)
                {
                    if (value[0] == '"' && value[value.Length - 1] == '"')
                        value = value.Substring(1, value.Length - 2);
                    if (value.Substring(1, 2) == @":\")
                    {
                        value = value.Substring(3);
                        if (value.IndexOf(ParentFranchise.Path) == 0)
                            value = value.Substring(ParentFranchise.Path.Length);
                    }
                }
                path = value;
            }
        }//Path to part

        private byte isPathFile;//Is path file? Else directory

        public List<Series> Series { get; private set; }//Series

        public Franchise ParentFranchise { get; private set; }

        public Part(Franchise parent)
        {
            Name = "";
            CommonLength = 1440;
            DiskSize = 0;
            Path = "";
            isPathFile = 0;
            ParentFranchise = parent;
            Series = new List<Series>
            {
                new Series(1440, 0)
            };
        }

        public Part(string name, string path, int serCount, bool autoSize, bool autoLength, Franchise parent)
        {
            this.Name = name;
            this.Path = path;
            int typeP = StaticUtils.IsFileOrDirr(this.Path);
            this.isPathFile = 0;
            if (typeP == 1)
                this.isPathFile = 1;
            if (autoSize)
                this.DiskSize = StaticUtils.GetPathSize(this.Path, this.IsFile());
            else
                this.DiskSize = 0;
            if (this.DiskSize < 0)
                this.DiskSize = 0;
            this.CommonLength = 1440;
            if (autoLength)
            {
                int p = StaticUtils.HMStoSecs(StaticUtils.GetVideoLength(this.Path));
                if (p >= 0)
                    this.CommonLength = p;
            }
            ParentFranchise = parent;
            Series = new List<Series>();
            for (int i = 0; i < serCount; i++)
                Series.Add(new Series());
            this.SetSeriesLengthToCommon();
        }

        public Part(FileStream f, Franchise parent)
        {
            ParentFranchise = parent;
            //name
            Name = BinaryFile.ReadString(f);
            //sizeD
            DiskSize = BinaryFile.ReadInt64(f);
            //path
            Path = BinaryFile.ReadString(f);
            //isPathFile
            isPathFile = BinaryFile.ReadByte(f);
            //common length
            CommonLength = BinaryFile.ReadInt32(f);
            //series
            int p = BinaryFile.ReadInt32(f);
            Series = new List<Series>();
            for (int i = 0; i < p; i++)
                Series.Add(new Series(f));
        }

        public void SaveToBin(FileStream f)
        {
            //name
            BinaryFile.WriteString(f, Name);
            //sizeD
            BinaryFile.WriteInt64(f, DiskSize);
            //path
            BinaryFile.WriteString(f, Path);
            //isPathFile
            BinaryFile.WriteByte(f, isPathFile);
            //common length
            BinaryFile.WriteInt32(f, CommonLength);
            //series
            BinaryFile.WriteInt32(f, Series.Count);
            foreach (Series s in Series)
                s.SaveToBin(f);
        }
        //Length
        public int GetLength()
        {
            int length = 0;
            foreach (Series series in this.Series)
                length += series.Length;
            return length;
        }

        public int GetWatchedLength()
        {
            int length = 0;
            foreach (Series series in this.Series)
                length += series.GetWatchedLength();
            return length;
        }

        public int GetUniqueWatchedLength()
        {
            int length = 0;
            foreach (Series series in this.Series)
                length += series.GetUniqueWatchedLength();
            return length;
        }

        public int GetDownloadedLength()
        {
            if (DiskSize == 0)
                return 0;
            return this.GetLength();
        }

        public int GetNoTouchedLength()
        {
            int length = 0;
            foreach (Series series in this.Series)
                length += series.GetNoTouchedLength();
            return length;
        }

        public double GetPersentage()
        {
            double persentage = this.GetUniqueWatchedLength() * 100;
            persentage /= this.GetLength();
            return persentage;
        }

        public void SetSeriesLengthToCommon()
        {
            foreach (Series s in Series)
                s.Length = this.CommonLength;
        }
        //Size
        public void FindSize()
        {
            if (this.ParentFranchise.GetAbsolutePath() == "null")
            {
                Program.Log("There is no media drives!");
                return;
            }
            string path = this.GetAbsolutePath();
            long newSize = 0;
            if (path != "null")
            {
                newSize = StaticUtils.GetPathSize(path, this.IsFile());
                if (newSize == -1)
                {
                    Program.Log(String.Format("{0} - {1}. Path \"{2}\" doesn't exist!", this.ParentFranchise.GetName(), this.Name, this.Path));
                    newSize = 0;
                }
            }
            if (DiskSize != newSize)
                Program.Log(String.Format("{0} - {1} size has been updated from {2:f2} GB to {3:f2} GB", this.ParentFranchise.GetName(), this.Name, DiskSize / 1024d / 1024 / 1024, newSize / 1024d / 1024 / 1024));
            DiskSize = newSize;
        }
        //Path
        public string GetAbsolutePath()
        {
            if (this.Path == "")
                return "null";
            string result = ParentFranchise.GetAbsolutePath();
            if (result == "null")
                return "null";
            result += this.Path;
            return result;
        }

        public void SetIsPathFile(bool isPathFile)
        {
            this.isPathFile = isPathFile ? (byte)1 : (byte)0;
        }

        public bool IsFile()
        {
            return isPathFile > 0;
        }
        //Series
        public void SetSeriesCount(int count)
        {
            if (this.Series.Count == count)
                return;
            if (this.Series.Count < count)
            {
                count -= this.Series.Count;
                for (int i = 0; i < count; i++)
                    this.Series.Add(new Series(this.CommonLength, 0));
            }
            else
            {
                count = this.Series.Count - count;
                for (int i = 0; i < count; i++)
                    this.Series.RemoveAt(this.Series.Count - 1);
            }
        }
        //Other
        public void AddWatch()
        {
            foreach (Series s in Series)
                s.AddWatch();
        }

        public override string ToString()
        {
            string s = "";
            s += String.Format("{0,-15}| {1}\r\n", "Name", this.Name);
            s += String.Format("{0,-15}| {1}\r\n", "Path", this.Path);
            s += String.Format("{0,-15}| {1}\r\n", "Path type", this.IsFile() ? "File" : "Dirr");
            s += String.Format("{0,-15}| {1:f2} GB\r\n", "Size on disk", this.DiskSize / 1024D / 1024 / 1024);
            s += String.Format("{0,-15}| {1}\r\n", "Series", Series.Count);
            s += String.Format("{0,-15}| {1:f2} Hr\r\n", "Length", this.GetLength() / 3600d);
            s += String.Format("{0,-15}| {1:f2} Hr\r\n", "Length W", this.GetWatchedLength() / 3600d);
            s += String.Format("{0,-15}| {1:f2} Hr\r\n", "Length WU", this.GetUniqueWatchedLength() / 3600d);
            int i = 0;
            foreach (Series ser in Series)
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
                Text = this.Name
            };
            ListViewItem.ListViewSubItem subItem;
            //Length
            subItem = new ListViewItem.ListViewSubItem
            {
                Tag = "Length",
                Text = String.Format("{0:f2} Hr", this.GetLength() / 3600d)
            };
            item.SubItems.Add(subItem);
            //Size
            subItem = new ListViewItem.ListViewSubItem
            {
                Tag = "Size",
                Text = this.DiskSize == 0 ? "" : String.Format("{0:f2} Gb", this.DiskSize / 1024d / 1024 / 1024)
            };
            item.SubItems.Add(subItem);
            //BPS
            subItem = new ListViewItem.ListViewSubItem
            {
                Tag = "BPS",
                Text = this.DiskSize == 0 ? "" : String.Format("{0:f0} Mb", (this.DiskSize / 1024d / 1024) / (this.GetLength() / 60d / 24))
            };
            item.SubItems.Add(subItem);
            //%
            subItem = new ListViewItem.ListViewSubItem
            {
                Tag = "%",
                Text = String.Format("{0:f0}%", this.GetPersentage())
            };
            item.SubItems.Add(subItem);
            //Path
            subItem = new ListViewItem.ListViewSubItem
            {
                Tag = "Path",
                Text = this.Path
            };
            item.SubItems.Add(subItem);
            return item;
        }
    }
}
