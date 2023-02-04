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
            length = BinaryFile.ReadInt32(f);
            //countWatch
            countWatch = BinaryFile.ReadInt32(f);
        }

        public void SaveToBin(FileStream f)
        {
            //length
            BinaryFile.WriteInt32(f, length);
            //countWatch
            BinaryFile.WriteInt32(f, countWatch);
        }

        public void SetLength(int length)
        {
            this.length = length;
        }

        public int GetLength()
        {
            return length;
        }

        public int GetWatchedLength()
        {
            return length * countWatch;
        }

        public int GetUniqueWatchedLength()
        {
            return countWatch > 0 ? length : 0;
        }

        public int GetNoTouchedLength()
        {
            return countWatch == 0 ? length : 0;
        }

        public void SetCountWatch(int countWatch)
        {
            this.countWatch = countWatch;
        }

        public int GetCountWatch()
        {
            return countWatch;
        }

        public void AddWatch()
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
