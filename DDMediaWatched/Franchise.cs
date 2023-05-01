using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace DDMediaWatched
{
    public partial class Franchise
    {
        public int ID { get; private set; }


        private readonly List<string> names;

        private List<Part> Parts { get; set; }

        private string path;
        public string Path
        {
            get
            {
                return path;
            }
            set
            {
                if (value.Length > 3)
                {
                    if (value[0] == '"')
                        value = value.Substring(1, value.Length - 2);
                    if (value.Substring(1, 2) == @":\")
                        value = value.Substring(3);
                    path = value;
                }
                else
                    path = "";
                if (path.Length > 0)
                    if (path[path.Length - 1] != '\\')
                        path += '\\';
            }
        }

        private string url;

        public string URL
        {
            get
            {
                return url.Replace(@"$SHIKI$", StaticUtils.GetShikiPath());
            }
            set 
            {
                url = value.Replace(StaticUtils.GetShikiPath(), @"$SHIKI$");
            }
        }

        private FranchiseType type;

        public int Mark { get; set; }

        public int ForWhom { get; set; }

        private DateTime startingDate;

        public Franchise()
        {
            ID = Franchise.GetAvailableID();
            names = new List<string>
            {
                ""
            };
            Parts = new List<Part>();
            Path = "";
            URL = "";
            type = FranchiseType.No;
            Mark = -1;
            ForWhom = 0;
            startingDate = new DateTime(2000, 1, 1);
        }

        public Franchise(string[] args)
        {
            ID = Franchise.GetAvailableID();
            names = new List<string>();
            this.SetNames(args[0].Trim().Split(';'));
            string path = args[1].Trim();
            switch(args[2].ToLower())
            {
                case "a":
                    {
                        this.type = FranchiseType.Anime;
                    }
                    break;
                case "c":
                    {
                        this.type = FranchiseType.Cartoon;
                    }
                    break;
                case "f":
                    {
                        this.type = FranchiseType.Film;
                    }
                    break;
                case "d":
                    {
                        this.type = FranchiseType.Dorama;
                    }
                    break;
                default:
                    {
                        this.type = FranchiseType.No;
                    }
                    break;
            }
            Parts = new List<Part>();
            if (args.Length > 3)
            {
                this.Path = path;
                int[] ser = new int[args.Length - 3];
                for (int i = 3; i < args.Length; i++)
                    ser[i - 3] = int.Parse(args[i]);
                for (int i = 0; i < ser.Length; i++)
                {
                    Parts.Add(new Part(String.Format("Part {0}", i + 1), "", ser[i], true, false, this));
                }
            }
            else
            {
                this.Path = "";
                Parts.Add(new Part("Film", path, 1, true, true, this));
            }
            URL = "";
            Mark = -1;
            ForWhom = 0;
            startingDate = new DateTime(2000, 1, 1);
        }

        public Franchise(FileStream f)
        {
            //ID
            ID = BinaryFile.ReadInt32(f);
            //type
            type = (FranchiseType)BinaryFile.ReadInt32(f);
            //names
            int p = BinaryFile.ReadInt32(f);
            names = new List<string>();
            for (int i = 0; i < p; i++)
                names.Add(BinaryFile.ReadString(f));
            //mark
            Mark = BinaryFile.ReadInt32(f);
            //forWhom
            ForWhom = BinaryFile.ReadInt32(f);
            //path
            Path = BinaryFile.ReadString(f);
            //URL
            URL = BinaryFile.ReadString(f);
            //parts
            p = BinaryFile.ReadInt32(f);
            Parts = new List<Part>();
            for (int i = 0; i < p; i++)
                Parts.Add(new Part(f, this));
            //startingDate
            int yy = BinaryFile.ReadInt32(f);
            int mm = BinaryFile.ReadInt32(f);
            int dd = BinaryFile.ReadInt32(f);
            startingDate = new DateTime(yy, mm, dd);
        }

        public void SaveToBin(FileStream f)
        {
            //ID
            BinaryFile.WriteInt32(f, ID);
            //type
            BinaryFile.WriteInt32(f, (int)type);
            //names
            BinaryFile.WriteInt32(f, names.Count);
            foreach (string s in names)
                BinaryFile.WriteString(f, s);
            //mark
            BinaryFile.WriteInt32(f, Mark);
            //forWhom
            BinaryFile.WriteInt32(f, ForWhom);
            //path
            BinaryFile.WriteString(f, Path);
            //URL
            BinaryFile.WriteString(f, URL);
            //parts
            BinaryFile.WriteInt32(f, Parts.Count);
            foreach (Part s in Parts)
                s.SaveToBin(f);
            //startingDate
            BinaryFile.WriteInt32(f, startingDate.Year);
            BinaryFile.WriteInt32(f, startingDate.Month);
            BinaryFile.WriteInt32(f, startingDate.Day);
        }
        //Names
        public void SetNames(string[] names)
        {
            this.names.Clear();
            foreach (string s in names)
                this.names.Add(s.Trim());
        }

        public string GetName()
        {
            return names[0];
        }

        public string GetAllNames()
        {
            string s = "";
            for (int i = 0; i < names.Count - 1; i++)
                s += names[i] + "; ";
            s += names[names.Count - 1];
            return s;
        }

        public string GetOtherNames()
        {
            string s = "";
            if (names.Count >= 2)
            {
                for (int i = 1; i < names.Count - 1; i++)
                    s += names[i] + "; ";
                s += names[names.Count - 1];
            }
            return s;
        }

        public bool HasSecondaryName()
        {
            if (names.Count > 1)
                return true;
            else
                return false;
        }
        //Length
        public int GetLength()
        {
            int length = 0;
            foreach (Part part in this.Parts)
                length += part.GetLength();
            return length;
        }

        public int GetWatchedLength()
        {
            int length = 0;
            foreach (Part part in this.Parts)
                length += part.GetWatchedLength();
            return length;
        }

        public int GetUniqueWatchedLength()
        {
            int length = 0;
            foreach (Part part in this.Parts)
                length += part.GetUniqueWatchedLength();
            return length;
        }

        public int GetDownloadedLength()
        {
            int length = 0;
            foreach (Part part in this.Parts)
                length += part.GetDownloadedLength();
            return length;
        }

        public int GetNoTouchedLength()
        {
            int length = 0;
            foreach (Part part in this.Parts)
                length += part.GetNoTouchedLength();
            return length;
        }

        public double GetPersentage()
        {
            if (this.GetLength() == 0)
                return 0;
            double persentage = this.GetUniqueWatchedLength() * 100;
            persentage /= this.GetLength();
            return persentage;
        }

        public double GetPersentageAll()
        {
            if (this.GetLength() == 0)
                return 0;
            double persentage = this.GetWatchedLength() * 100;
            persentage /= this.GetLength();
            return persentage;
        }

        public double GetPersentage99_0_100()
        {
            if (this.GetLength() == 0)
                return 0;
            double persentage = this.GetUniqueWatchedLength() * 100;
            persentage /= this.GetLength();
            if (this.GetPersentage() > 99.999d)
                persentage = -1;
            return persentage;
        }

        public FranchisePersentage GetPersentageType()
        {
            FranchisePersentage fp = FranchisePersentage.Zero;
            if (this.GetPersentage() > 0.001d)
                fp = FranchisePersentage.Started;
            if (this.GetPersentage() > 99.999d)
                fp = FranchisePersentage.Full;
            return fp;
        }
        //Size
        public long GetSize()
        {
            long p = 0;
            foreach (Part part in Parts)
                p += part.DiskSize;
            return p;
        }

        public void FindSize()
        {
            if (!StaticUtils.IsMediaDriveExists())
            {
                Program.Log("There is no media drives!");
                return;
            }
            foreach (Part part in this.Parts)
                part.FindSize();
        }

        public FranchiseDown GetDownloadedType()
        {
            if (this.GetSize() == 0)
                return FranchiseDown.NoDownloaded;
            return FranchiseDown.Downloaded;
        }
        //BPS
        public double GetBPS()
        {
            return this.GetSize() / (this.GetDownloadedLength() / 60d / 24);
        }
        //Path
        public string GetAbsolutePath()
        {
            if (!StaticUtils.IsMediaDriveExists())
                return "null";
            return StaticUtils.GetMediaDrivePath() + Path;
        }
        //ULR
        public bool IsURLExists()
        {
            if (this.URL == "")
                return false;
            else
                return true;
        }
        //Type
        public void SetType(int index)
        {
            if (index >= 0)
                this.type = (FranchiseType)index;
            else
                this.type = FranchiseType.No;
        }

        public FranchiseType GetFranchiseType()
        {
            return type;
        }

        public int GetFranchiseTypeInt()
        {
            int p = (int)this.type;
            if (this.type == FranchiseType.No)
                p = -1;
            return p;
        }

        public string GetFranchiseTypeString()
        {
            string s = "";
            switch (type)
            {
                case FranchiseType.Anime:
                    {
                        s = "Anime";
                    }
                    break;
                case FranchiseType.Cartoon:
                    {
                        s = "Cartoon";
                    }
                    break;
                case FranchiseType.Film:
                    {
                        s = "Film";
                    }
                    break;
                case FranchiseType.Dorama:
                    {
                        s = "Dorama";
                    }
                    break;
                case FranchiseType.No:
                    {
                        s = "NULL";
                    }
                    break;
            }
            return s;
        }

        public string GetFranchiseTypeLetter()
        {
            string s = "";
            switch (type)
            {
                case FranchiseType.Anime:
                    {
                        s = "A";
                    }
                    break;
                case FranchiseType.Cartoon:
                    {
                        s = "C";
                    }
                    break;
                case FranchiseType.Film:
                    {
                        s = "F";
                    }
                    break;
                case FranchiseType.Dorama:
                    {
                        s = "D";
                    }
                    break;
                case FranchiseType.No:
                    {
                        s = "NULL";
                    }
                    break;
            }
            return s;
        }
        //Date
        public DateTime GetStartingDate()
        {
            return startingDate;
        }

        public void SetStartingDate(string arg)
        {
            string[] args = arg.Split('.');
            if (args.Length < 3)
                return;
            this.SetStartingDate(int.Parse(args[0]), int.Parse(args[1]), int.Parse(args[2]));
        }

        public void SetStartingDate(int yy, int mm, int dd)
        {
            startingDate = new DateTime(yy, mm, dd);
        }

        public void SetStartingDate(DateTime dt)
        {
            this.startingDate = new DateTime(dt.Year, dt.Month, dt.Day);
        }
        //Parts
        public void AddPart(Part part)
        {
            this.Parts.Add(part);
        }

        public void RemovePart(Part part)
        {
            for (int i = 0; i < this.Parts.Count; i++)
                if (this.Parts[i].Name == part.Name)
                {
                    this.Parts.RemoveAt(i);
                    break;
                }
        }

        public Part GetPart(string name)
        {
            foreach (Part part in this.Parts)
                if (part.Name == name)
                    return part;
            return null;
        }

        public void PartUp(string name)
        {
            for (int i = 1; i < this.Parts.Count; i++)
                if (this.Parts[i].Name == name)
                {
                    Part p = this.Parts[i];
                    this.Parts[i] = this.Parts[i - 1];
                    this.Parts[i - 1] = p;
                    break;
                }
        }

        public void PartDown(string name)
        {
            for (int i = 0; i < this.Parts.Count - 1; i++)
                if (this.Parts[i].Name == name)
                {
                    Part p = this.Parts[i];
                    this.Parts[i] = this.Parts[i + 1];
                    this.Parts[i + 1] = p;
                    break;
                }
        }

        public int GetPartsCountWithName(string name)
        {
            int partsCount = 0;
            foreach (Part part in this.Parts)
                if (part.Name == name)
                    partsCount++;
            return partsCount;
        }

        public ListViewItem[] GetListViewPartsArray()
        {
            ListViewItem[] parts = new ListViewItem[this.Parts.Count];
            int i = 0;
            foreach (Part part in this.Parts)
                parts[i++] = part.ToListViewItem();
            return parts;
        }

        public int GetAvailablePartID()
        {
            int id = 0;
            foreach (Part p in Parts)
                if (p.ID >= id)
                    id = p.ID + 1;
            return id;
        }

        public void DeleteSubpathes()
        {
            foreach (Part part in Parts)
            {
                part.DeletePath();
            }
        }

        public void DeleteZeroSubpathes()
        {
            foreach (Part part in Parts)
            {
                part.DeleteZeroPath();
            }
        }
        //For Whom
        public string GetForWhomName()
        {
            return StaticUtils.GetForWhomName(this.ForWhom);
        }
        //Other
        public void AddWatch()
        {
            foreach (Part p in Parts)
                p.AddWatch();
        }

        public override string ToString()
        {
            string s = "";
            s += String.Format("{0,-15}| {1}\r\n", "ID", this.ID);
            s += String.Format("{0,-15}| {1}\r\n", "Name", this.GetName());
            s += String.Format("{0,-15}| {1}\r\n", "Other names", this.GetOtherNames());
            s += String.Format("{0,-15}| {1}\r\n", "Path", @"X:\" + this.Path);
            s += String.Format("{0,-15}| {1}\r\n", "URL", this.URL);
            s += String.Format("{0,-15}| {1}\r\n", "Type", this.GetFranchiseTypeString());
            s += String.Format("{0,-15}| {1}\r\n", "Mark", this.Mark < 0 ? "" : this.Mark.ToString());
            s += String.Format("{0,-15}| {1}\r\n", "Date", this.startingDate.Year == 2000 ? "" : this.startingDate.ToString("yyyy.MM.dd"));
            s += String.Format("{0,-15}| {1}\r\n", "For whom", this.GetForWhomName());
            s += String.Format("{0,-15}| {1:f2} GB\r\n", "Size", this.GetSize() / 1024d / 1024/ 1024);
            s += String.Format("{0,-15}| {1:f2} Hr\r\n", "Length", this.GetLength() / 3600d);
            s += String.Format("{0,-15}| {1:f2} Hr, {2:f0} %\r\n", "Length W", this.GetWatchedLength() / 3600d, this.GetPersentageAll());
            s += String.Format("{0,-15}| {1:f2} Hr, {2:f0} %\r\n", "Length WU", this.GetUniqueWatchedLength() / 3600d, this.GetPersentage());
            return s;
        }

        public ListViewItem ToListViewItem()
        {
            ListViewItem item = new ListViewItem()
            {
                Text = this.GetName(),
                BackColor = StaticUtils.GetColor(ColorBy, this)
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
                Text = this.GetSize() == 0 ? "" : String.Format("{0:f0} Mb", (this.GetBPS() / 1024 / 1024))
            };
            item.SubItems.Add(si);
            //%
            si = new ListViewItem.ListViewSubItem
            {
                Tag = "%",
                Text = String.Format("{0:f0}%", this.GetPersentage())
            };
            item.SubItems.Add(si);
            //Type
            si = new ListViewItem.ListViewSubItem
            {
                Tag = "Type",
                Text = String.Format("{0}", this.GetFranchiseTypeLetter())
            };
            item.SubItems.Add(si);
            //ForWhom
            si = new ListViewItem.ListViewSubItem
            {
                Tag = "ForWhom",
                Text = String.Format("{0}", this.GetForWhomName())
            };
            item.SubItems.Add(si);
            //Mark
            si = new ListViewItem.ListViewSubItem
            {
                Tag = "Mark",
                Text = String.Format("{0}", this.Mark)
            };
            item.SubItems.Add(si);
            //Path
            si = new ListViewItem.ListViewSubItem
            {
                Tag = "Path",
                Text = this.Path
            };
            item.SubItems.Add(si);
            return item;
        }
    }
}
