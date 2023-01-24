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
        public enum FranchiseType {Anime, Cartoon, Film, Dorama, No};
        public enum FranchiseDown {Downloaded, NoDownloaded };
        public enum FranchisePersentage {Zero, Started, Full };

        private readonly List<string>
            names;

        private readonly List<Part>
            parts;

        private string
            path,
            URL;

        private FranchiseType
            type;

        private int
            mark;

        private DateTime
            startingDate;

        public Franchise()
        {
            names = new List<string>
            {
                ""
            };
            parts = new List<Part>();
            path = "";
            URL = "";
            type = FranchiseType.No;
            mark = -1;
            startingDate = new DateTime(2000, 1, 1);
        }

        public Franchise(string[] args)
        {
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
            parts = new List<Part>();
            if (args.Length > 3)
            {
                this.SetPath(path);
                int[] ser = new int[args.Length - 3];
                for (int i = 3; i < args.Length; i++)
                    ser[i - 3] = int.Parse(args[i]);
                for (int i = 0; i < ser.Length; i++)
                {
                    parts.Add(new Part(String.Format("Part {0}", i + 1), "", ser[i], true, false, this));
                }
            }
            else
            {
                this.path = "";
                parts.Add(new Part("Film", path, 1, true, true, this));
            }
            URL = "";
            mark = -1;
            startingDate = new DateTime(2000, 1, 1);
        }

        public Franchise(FileStream f)
        {
            //type
            type = (FranchiseType)BinaryFile.FileReadInt32(f);
            //names
            int p = BinaryFile.FileReadInt32(f);
            names = new List<string>();
            for (int i = 0; i < p; i++)
                names.Add(BinaryFile.FileReadString(f));
            //mark
            mark = BinaryFile.FileReadInt32(f);
            //path
            path = BinaryFile.FileReadString(f);
            //URL
            URL = BinaryFile.FileReadString(f);
            //parts
            p = BinaryFile.FileReadInt32(f);
            parts = new List<Part>();
            for (int i = 0; i < p; i++)
                parts.Add(new Part(f, this));
            //startingDate
            int yy = BinaryFile.FileReadInt32(f);
            int mm = BinaryFile.FileReadInt32(f);
            int dd = BinaryFile.FileReadInt32(f);
            startingDate = new DateTime(yy, mm, dd);
        }

        public void SaveToBin(FileStream f)
        {
            //type
            BinaryFile.FileWriteInt32(f, (int)type);
            //names
            BinaryFile.FileWriteInt32(f, names.Count);
            foreach (string s in names)
                BinaryFile.FileWriteString(f, s);
            //mark
            BinaryFile.FileWriteInt32(f, mark);
            //path
            BinaryFile.FileWriteString(f, path);
            //URL
            BinaryFile.FileWriteString(f, URL);
            //parts
            BinaryFile.FileWriteInt32(f, parts.Count);
            foreach (Part s in parts)
                s.SaveToBin(f);
            //startingDate
            BinaryFile.FileWriteInt32(f, startingDate.Year);
            BinaryFile.FileWriteInt32(f, startingDate.Month);
            BinaryFile.FileWriteInt32(f, startingDate.Day);
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
        //Length
        public int GetLength()
        {
            int length = 0;
            foreach (Part part in this.parts)
                length += part.GetLength();
            return length;
        }

        public int GetWatchedLength()
        {
            int length = 0;
            foreach (Part part in this.parts)
                length += part.GetWatchedLength();
            return length;
        }

        public int GetUniqueWatchedLength()
        {
            int length = 0;
            foreach (Part part in this.parts)
                length += part.GetUniqueWatchedLength();
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
            foreach (Part part in parts)
                p += part.GetSize();
            return p;
        }

        public void FindSize()
        {
            if (Program.pathLetter == "null")
            {
                Program.form1.Log("There is no media drives!");
                return;
            }
            if (this.GetPath() == "")
            {
                Program.form1.Log("There is no path!");
                return;
            }
            foreach (Part part in this.GetParts())
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
            return this.GetSize() / (this.GetLength() / 60d / 24);
        }
        //Path
        public void SetPath(string path)
        {
            if (path.Length > 3)
            {
                if (path[0] == '"')
                    path = path.Substring(1, path.Length - 2);
                if (path.Substring(1, 2) == @":\")
                    path = path.Substring(3);
                this.path = path;
            }
            else
                this.path = "";
            if (this.path.Length > 0)
                if (this.path[this.path.Length - 1] != '\\')
                    this.path += '\\';
        }

        public string GetPath()
        {
            return path;
        }

        public string GetAbsolutePath()
        {
            if (Program.pathLetter == "null")
                return "null";
            return Program.pathLetter + path;
        }
        //ULR
        public string GetURL()
        {
            return URL;
        }

        public void SetURL(string URL)
        {
            this.URL = URL;
        }

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
        //Mark
        public int GetMark()
        {
            return mark;
        }
        //Parts
        public List<Part> GetParts()
        {
            return parts;
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
        //Other
        public override string ToString()
        {
            string s = "";
            s += String.Format("{0,-15}| {1}\r\n", "Name", this.GetName());
            s += String.Format("{0,-15}| {1}\r\n", "Other names", this.GetOtherNames());
            s += String.Format("{0,-15}| {1}\r\n", "Path", this.GetPath());
            s += String.Format("{0,-15}| {1}\r\n", "URL", this.GetURL());
            s += String.Format("{0,-15}| {1}\r\n", "Type", this.GetFranchiseTypeString());
            s += String.Format("{0,-15}| {1}\r\n", "Mark", this.GetMark() < 0 ? "" : this.GetMark().ToString());
            s += String.Format("{0,-15}| {1}\r\n", "Date", this.startingDate.Year == 2000 ? "" : this.startingDate.ToString("yyyy.MM.dd"));
            s += String.Format("{0,-15}| {1:f2} GB\r\n", "Size", this.GetSize() / 1024d / 1024/ 1024);
            s += String.Format("{0,-15}| {1:f2} Hr\r\n", "Length", this.GetLength() / 3600d);
            s += String.Format("{0,-15}| {1:f2} Hr\r\n", "Length W", this.GetWatchedLength() / 3600d);
            s += String.Format("{0,-15}| {1:f2} Hr\r\n", "Length WU", this.GetUniqueWatchedLength() / 3600d);
            return s;
        }

        public ListViewItem ToListViewItem(string colorBy)
        {
            ListViewItem item = new ListViewItem()
            {
                Text = this.GetName(),
                BackColor = StaticUtils.GetColor(colorBy, this)
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
