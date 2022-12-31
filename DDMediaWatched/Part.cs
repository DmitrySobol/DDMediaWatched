using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DDMediaWatched
{
    public class Part
    {
        private string
            name;//Name of part (Season, Film ...)

        private int
            commonLength,//common length
            number,//Number of part
            width,//Resolution width
            height;//Resolution height

        private long
            sizeD;//Size on disk in bytes

        private string
            path;//Path to part

        private byte
            isPathFile;//Is path file? Else directory

        private List<Series>
            series;//Series

        private Franchise
            parentFranchise;

        public Part(Franchise parent)
        {
            name = "";
            commonLength = 1440;
            width = 0;
            height = 0;
            number = -1;
            sizeD = 0;
            path = "";
            isPathFile = 0;
            parentFranchise = parent;
            series = new List<Series>();
        }

        public Part(FileStream f, Franchise parent)
        {
            parentFranchise = parent;
            int p = 0;
            //number
            number = Program.FileReadInt32(f);
            //name
            name = Program.FileReadString(f);
            //resolution
            width = Program.FileReadInt32(f);
            height = Program.FileReadInt32(f);
            //sizeD
            sizeD = Program.FileReadInt64(f);
            //path
            path = Program.FileReadString(f);
            //isPathFile
            isPathFile = Program.FileReadByte(f);
            //common length
            commonLength = Program.FileReadInt32(f);
            //series
            p = Program.FileReadInt32(f);
            series = new List<Series>();
            for (int i = 0; i < p; i++)
                series.Add(new Series(f));
        }

        public void SaveToBin(FileStream f)
        {
            //number
            Program.FileWriteInt32(f, number);
            //name
            Program.FileWriteString(f, name);
            //resolution
            Program.FileWriteInt32(f, width);
            Program.FileWriteInt32(f, height);
            //sizeD
            Program.FileWriteInt64(f, sizeD);
            //path
            Program.FileWriteString(f, path);
            //isPathFile
            Program.FileWriteByte(f, isPathFile);
            //common length
            Program.FileWriteInt32(f, commonLength);
            //series
            Program.FileWriteInt32(f, series.Count);
            foreach (Series s in series)
                s.SaveToBin(f);
        }

        public void findSize()
        {
            string path = parentFranchise.getAbsolutePath();
            if (path == "null")
                return;
            long sizeBack = sizeD;
            path += this.path;
            if (isPathFile == 0)
                if (Directory.Exists(path))
                {
                    sizeD = 0;
                    Program.DirectorySize(path, ref sizeD);
                }
            if (isPathFile != 0)
                if (File.Exists(path))
                {
                    sizeD = 0;
                    FileInfo f = new FileInfo(path);
                    sizeD = f.Length;
                }
            Program.form1.Log(String.Format("{0}'s size has been updated from {1:f2} GB to {2:f2} GB", this.getName(), sizeBack / 1024d / 1024 / 1024, sizeD / 1024d / 1024 / 1024));
        }

        public void setIsPathFile(bool isPathFile)
        {
            if (isPathFile)
                this.isPathFile = 1;
            else
                this.isPathFile = 0;
        }

        public long getSize()
        {
            return sizeD;
        }

        public int getLength()
        {
            int length = 0;
            foreach (Series series in this.series)
                length += series.getLength();
            return length;
        }

        public string getName()
        {
            return name;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public int getNumber()
        {
            return number;
        }

        public void setNumber(int number)
        {
            this.number = number;
        }

        public string getPath()
        {
            return path;
        }

        public void setPath(string path)
        {
            this.path = path;
        }

        public int getWidth()
        {
            return width;
        }

        public void setWidth(int width)
        {
            this.width = width;
        }

        public int getHeight()
        {
            return height;
        }

        public void setHeight(int height)
        {
            this.height = height;
        }

        public int getCommonLength()
        {
            return this.commonLength;
        }
        
        public void setCommonLength(int length)
        {
            this.commonLength = length;
        }

        public void setSeriesLengthToCommon()
        {
            foreach (Series s in series)
                s.setLength(this.commonLength);
        }

        public override string ToString()
        {
            string s = "";
            s += String.Format("{0,-15}| {1}\r\n", "Number", this.getNumber());
            s += String.Format("{0,-15}| {1}\r\n", "Name", this.getName());
            s += String.Format("{0,-15}| {1}\r\n", "Path", this.getPath());
            s += String.Format("{0,-15}| {1}\r\n", "Path type", this.isPathFile > 0 ? "File" : "Dirr");
            s += String.Format("{0,-15}| {1:f2} GB\r\n", "Size on disk", this.getSize() / 1024D / 1024 / 1024);
            s += String.Format("{0,-15}| {1}x{2}\r\n", "Resolution", this.getWidth(), this.getHeight());
            s += String.Format("{0,-15}| {1:f2} Hr\r\n", "Length", this.getLength() / 3600d);
            int i = 0;
            foreach (Series ser in series)
            {
                i++;
                s += String.Format("{0,3}| {1}\r\n", i, ser.ToString());
            }
            return s;
        }
    }
}
