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
            series.Add(new Series(0, 1440));
        }

        public Part(string name, string path, int number, int serCount, bool autoSize, bool autoLength, Franchise parent)
        {
            this.name = name;
            width = 0;
            height = 0;
            this.number = number;
            this.path = path;
            int typeP = Program.IsFileOrDirr(this.path);
            this.isPathFile = 0;
            if (typeP == 1)
                this.isPathFile = 1;
            if (autoSize)
                this.sizeD = Program.GetPathSize(this.path, this.isFull());
            else
                this.sizeD = 0;
            if (this.sizeD < 0)
                this.sizeD = 0;
            this.commonLength = 1440;
            if (autoLength)
            {
                int p = Program.HMStoSecs(Program.GetVideoLength(this.path));
                if (p >= 0)
                    this.commonLength = p;
            }
            parentFranchise = parent;
            series = new List<Series>();
            for (int i = 0; i < serCount; i++)
                series.Add(new Series());
            this.setSeriesLengthToCommon();
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

        public int findSize()
        {
            long newSize = 0;
            int output = 0;
            if (this.path == "")
            {
                newSize = 0;
            }
            string path = parentFranchise.getAbsolutePath();
            if (path == "null")
                return output;
            if (this.path.Length > 0)
            {
                path += this.path;
                newSize = Program.GetPathSize(path, this.isFull());
            }
            if (sizeD != newSize)
                Program.form1.Log(String.Format("{0} - {1} size has been updated from {2:f2} GB to {3:f2} GB", this.parentFranchise.getName(), this.getName(), sizeD / 1024d / 1024 / 1024, newSize / 1024d / 1024 / 1024));
            //else
            //    Program.form1.Log(String.Format("{0,-35} size hasn't been updated!", this.getName()));
            if (sizeD == 0 && newSize > 0)
                output = 1;
            if (sizeD == newSize)
                output = 2;
            if (sizeD > 0 && newSize == 0)
                output = 3;
            sizeD = newSize;
            return output;
            //0 no path
            //1 0 -> x
            //2 x -> x
            //3 x -> 0
        }

        public void setIsPathFile(bool isPathFile)
        {
            if (isPathFile)
                this.isPathFile = 1;
            else
                this.isPathFile = 0;
        }

        public byte getIsPathFile()
        {
            return isPathFile;
        }

        public bool isFull()
        {
            if (isPathFile == 1)
                return true;
            if (isPathFile == 0)
                return false;
            return false;//ERROR
        }

        public long getSize()
        {
            return sizeD;
        }

        public void setSize(long size)
        {
            this.sizeD = size;
        }

        public int getLength()
        {
            int length = 0;
            foreach (Series series in this.series)
                length += series.getLength();
            return length;
        }

        public int getWatchedLength()
        {
            int length = 0;
            foreach (Series series in this.series)
                length += series.getWatchedLength();
            return length;
        }

        public int getUniqueWatchedLength()
        {
            int length = 0;
            foreach (Series series in this.series)
                length += series.getUniqueWatchedLength();
            return length;
        }

        public double getPersentage()
        {
            double persentage = this.getUniqueWatchedLength() * 100;
            persentage /= this.getLength();
            return persentage;
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

        public string getAbsolutePath()
        {
            string s = "";
            if (this.path != "")
                s = parentFranchise.getAbsolutePath() + this.path;
            return s;
        }

        public void setPath(string path)
        {
            if (path.Length > 3)
            {
                if (path[0] == '"')
                    path = path.Substring(1, path.Length - 2);
                if (path.Substring(1, 2) == @":\")
                    path = path.Substring(3);
                if (path.Length >= getParent().getPath().Length)
                    if (path.Substring(0, getParent().getPath().Length) == getParent().getPath())
                    {
                        path = path.Substring(getParent().getPath().Length);
                    }
                this.path = path;
            }
            else
                this.path = "";
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

        public List<Series> getSeries()
        {
            return series;
        }

        public Franchise getParent()
        {
            return parentFranchise;
        }

        public void addWatch()
        {
            foreach (Series s in series)
                s.addWatch();
        }

        public override string ToString()
        {
            string s = "";
            s += String.Format("{0,-15}| {1}\r\n", "Number", this.getNumber());
            s += String.Format("{0,-15}| {1}\r\n", "Name", this.getName());
            s += String.Format("{0,-15}| {1}\r\n", "Path", this.getPath());
            s += String.Format("{0,-15}| {1}\r\n", "Path type", this.isFull() ? "File" : "Dirr");
            s += String.Format("{0,-15}| {1:f2} GB\r\n", "Size on disk", this.getSize() / 1024D / 1024 / 1024);
            s += String.Format("{0,-15}| {1}x{2}\r\n", "Resolution", this.getWidth(), this.getHeight());
            s += String.Format("{0,-15}| {1:f2} Hr\r\n", "Length", this.getLength() / 3600d);
            s += String.Format("{0,-15}| {1:f2} Hr\r\n", "Length W", this.getWatchedLength() / 3600d);
            s += String.Format("{0,-15}| {1:f2} Hr\r\n", "Length WU", this.getUniqueWatchedLength() / 3600d);
            int i = 0;
            foreach (Series ser in series)
            {
                i++;
                s += String.Format("{0,4}| {1}\r\n", i, ser.ToString());
            }
            return s;
        }
    }
}
