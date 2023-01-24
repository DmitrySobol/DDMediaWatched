using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DDMediaWatched
{
    public class Series
    {
        private int
            length,//length in seconds
            countWatch;

        public Series()
        {
            this.length = 0;
            this.countWatch = 0;
        }

        public Series(int length, int countWatch)
        {
            this.length = length;
            this.countWatch = countWatch;
        }

        public Series(FileStream f)
        {
            //length
            length = BinaryFile.FileReadInt32(f);
            //countWatch
            countWatch = BinaryFile.FileReadInt32(f);
        }

        public void SaveToBin(FileStream f)
        {
            //length
            BinaryFile.FileWriteInt32(f, length);
            //countWatch
            BinaryFile.FileWriteInt32(f, countWatch);
        }

        public void setLength(int length)
        {
            this.length = length;
        }

        public int getLength()
        {
            return length;
        }

        public int getWatchedLength()
        {
            return length * countWatch;
        }

        public int getUniqueWatchedLength()
        {
            if (countWatch > 0)
                return length;
            return 0;
        }

        public void setCountWatch(int countWatch)
        {
            this.countWatch = countWatch;
        }

        public int getCountWatch()
        {
            return countWatch;
        }

        public void addWatch()
        {
            this.countWatch++;
        }

        public override string ToString()
        {
            string s = String.Format("{0:f2} min|{1} times", length / 60d, countWatch);
            return s;
        }
    }
}
