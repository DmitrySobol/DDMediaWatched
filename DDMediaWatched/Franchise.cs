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
        enum FranchiseType {Anime, Cartoon, Film, Dorama, No};

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

        public Franchise()
        {
            names = new List<string>();
            names.Add("");
            parts = new List<Part>();
            path = "";
            type = FranchiseType.No;
            number = Program.GetFirstAvailableNumber();
            mark = -1;
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
        }

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

        public int getLength()
        {
            int length = 0;
            foreach (Part part in this.parts)
                length += part.getLength();
            return length;
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

        public void setPath(string path)
        {
            this.path = path;
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

        public void setType(int index)
        {
            if (index >= 0)
                this.type = (FranchiseType)index;
            else
                this.type = FranchiseType.No;
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

        public void setNumber(int number)
        {
            this.number = number;
        }

        public int getNumber()
        {
            return number;
        }

        public int getMark()
        {
            return mark;
        }

        public List<Part> getParts()
        {
            return parts;
        }

        public long getSize()
        {
            long p = 0;
            foreach (Part part in parts)
                p += part.getSize();
            return p;
        }

        public override string ToString()
        {
            string s = "";
            s += String.Format("{0,-15}| {1}\r\n", "Number", this.getNumber());
            s += String.Format("{0,-15}| {1}\r\n", "Name", this.getName());
            s += String.Format("{0,-15}| {1}\r\n", "Other names", this.getOtherNames());
            s += String.Format("{0,-15}| {1}\r\n", "Path", this.getPath());
            s += String.Format("{0,-15}| {1}\r\n", "Type", this.getTypeString());
            s += String.Format("{0,-15}| {1}\r\n", "Mark", this.getMark() < 0 ? "" : this.getMark().ToString());
            s += String.Format("{0,-15}| {1:f2} GB\r\n", "Size", this.getSize() / 1024d / 1024/ 1024);
            s += String.Format("{0,-15}| {1:f2} Hr\r\n", "Length", this.getLength() / 3600d);
            return s;
        }
    }
}
