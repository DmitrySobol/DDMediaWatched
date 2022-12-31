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

        public Series(FileStream f)
        {
            //length
            length = Program.FileReadInt32(f);
            //countWatch
            countWatch = Program.FileReadInt32(f);
        }

        public void SaveToBin(FileStream f)
        {
            //length
            Program.FileWriteInt32(f, length);
            //countWatch
            Program.FileWriteInt32(f, countWatch);
        }

        public void setLength(int length)
        {
            this.length = length;
        }

        public int getLength()
        {
            return length;
        }

        public int getCountWatch()
        {
            return countWatch;
        }

        public override string ToString()
        {
            string s = String.Format("{0:f2} min|{1} times", length / 60d, countWatch);
            return s;
        }
    }
}
