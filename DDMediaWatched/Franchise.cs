using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DDMediaWatched
{
    public class Franchise
    {
        public enum FranchiseType {Anime, Cartoon, Film, Dorama, No};

        private List<string>
            names;

        private List<Part>
            parts;

        private string
            path;

        private FranchiseType
            type;

        private int
            number,
            mark;

        private DateTime
            startingDate;

        public Franchise()
        {
            names = new List<string>();
            names.Add("");
            parts = new List<Part>();
            path = "";
            type = FranchiseType.No;
            number = Program.GetFirstAvailableNumber();
            mark = -1;
            startingDate = new DateTime(2000, 1, 1);
        }

        public Franchise(string[] args)
        {
            names = new List<string>();
            this.setNames(args[0].Trim().Split(';'));
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
                this.path = path;
                int[] ser = new int[args.Length - 3];
                for (int i = 3; i < args.Length; i++)
                    ser[i - 3] = int.Parse(args[i]);
                for (int i = 0; i < ser.Length; i++)
                {
                    parts.Add(new Part(String.Format("Part {0}", i + 1), "", i + 1, ser[i], true, false, this));
                }
            }
            else
            {
                this.path = "";
                parts.Add(new Part("Film", path, 1, 1, true, true, this));
            }
            number = Program.GetFirstAvailableNumber();
            mark = -1;
            startingDate = new DateTime(2000, 1, 1);
        }

        public Franchise(FileStream f)
        {
            int p = 0;
            //number
            number = Program.FileReadInt32(f);
            //type
            type = (FranchiseType)Program.FileReadInt32(f);
            //names
            p = Program.FileReadInt32(f);
            names = new List<string>();
            for (int i = 0; i < p; i++)
                names.Add(Program.FileReadString(f));
            //mark
            mark = Program.FileReadInt32(f);
            //path
            path = Program.FileReadString(f);
            //parts
            p = Program.FileReadInt32(f);
            parts = new List<Part>();
            for (int i = 0; i < p; i++)
                parts.Add(new Part(f, this));
            //startingDate
            int yy = Program.FileReadInt32(f);
            int mm = Program.FileReadInt32(f);
            int dd = Program.FileReadInt32(f);
            startingDate = new DateTime(yy, mm, dd);
        }

        public void SaveToBin(FileStream f)
        {
            //number
            Program.FileWriteInt32(f, number);
            //type
            Program.FileWriteInt32(f, (int)type);
            //names
            Program.FileWriteInt32(f, names.Count);
            foreach (string s in names)
                Program.FileWriteString(f, s);
            //mark
            Program.FileWriteInt32(f, mark);
            //path
            Program.FileWriteString(f, path);
            //parts
            Program.FileWriteInt32(f, parts.Count);
            foreach (Part s in parts)
                s.SaveToBin(f);
            //startingDate
            Program.FileWriteInt32(f, startingDate.Year);
            Program.FileWriteInt32(f, startingDate.Month);
            Program.FileWriteInt32(f, startingDate.Day);
        }
        //Names
        public void setNames(string[] names)
        {
            this.names.Clear();
            foreach (string s in names)
                this.names.Add(s.Trim());
        }

        public string getName()
        {
            return names[0];
        }

        public string getAllNames()
        {
            string s = "";
            for (int i = 0; i < names.Count - 1; i++)
                s += names[i] + "; ";
            s += names[names.Count - 1];
            return s;
        }

        public string getOtherNames()
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
        public int getLength()
        {
            int length = 0;
            foreach (Part part in this.parts)
                length += part.getLength();
            return length;
        }
        //Size
        public long getSize()
        {
            long p = 0;
            foreach (Part part in parts)
                p += part.getSize();
            return p;
        }
        //BPS
        public double getBPS()
        {
            return this.getSize() / (this.getLength() / 60d / 24);
        }
        //Path
        public void setPath(string path)
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

        public string getPath()
        {
            return path;
        }

        public string getAbsolutePath()
        {
            if (Program.pathLetter == "null")
                return "null";
            return Program.pathLetter + path;
        }
        //Type
        public void setType(int index)
        {
            if (index >= 0)
                this.type = (FranchiseType)index;
            else
                this.type = FranchiseType.No;
        }

        public FranchiseType getType()
        {
            return type;
        }

        public int getTypeInt()
        {
            int p = (int)this.type;
            if (this.type == FranchiseType.No)
                p = -1;
            return p;
        }

        public string getTypeString()
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
        //Number
        public void setNumber(int number)
        {
            this.number = number;
        }

        public int getNumber()
        {
            return number;
        }
        //Mark
        public int getMark()
        {
            return mark;
        }
        //Parts
        public List<Part> getParts()
        {
            return parts;
        }
        //Date
        public DateTime getStartingDate()
        {
            return startingDate;
        }

        public void setStartingDate(string arg)
        {
            string[] args = arg.Split('.');
            if (args.Length < 3)
                return;
            this.setStartingDate(int.Parse(args[0]), int.Parse(args[1]), int.Parse(args[2]));
        }

        public void setStartingDate(int yy, int mm, int dd)
        {
            startingDate = new DateTime(yy, mm, dd);
        }
        //Other
        public override string ToString()
        {
            string s = "";
            s += String.Format("{0,-15}| {1}\r\n", "Number", this.getNumber());
            s += String.Format("{0,-15}| {1}\r\n", "Name", this.getName());
            s += String.Format("{0,-15}| {1}\r\n", "Other names", this.getOtherNames());
            s += String.Format("{0,-15}| {1}\r\n", "Path", this.getPath());
            s += String.Format("{0,-15}| {1}\r\n", "Type", this.getTypeString());
            s += String.Format("{0,-15}| {1}\r\n", "Mark", this.getMark() < 0 ? "" : this.getMark().ToString());
            s += String.Format("{0,-15}| {1}\r\n", "Date", this.startingDate.Year == 2000 ? "" : this.startingDate.ToString("yyyy.MM.dd"));
            s += String.Format("{0,-15}| {1:f2} GB\r\n", "Size", this.getSize() / 1024d / 1024/ 1024);
            s += String.Format("{0,-15}| {1:f2} Hr\r\n", "Length", this.getLength() / 3600d);
            return s;
        }
    }
}
