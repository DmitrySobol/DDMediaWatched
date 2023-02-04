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
        public int Length { get; set; }//length in seconds
        public int CountWatch { get; set; }

        public Series()
        {
            this.Length = 0;
            this.CountWatch = 0;
        }

        public Series(int length, int countWatch)
        {
            this.Length = length;
            this.CountWatch = countWatch;
        }

        public Series(FileStream f)
        {
            //length
            Length = BinaryFile.ReadInt32(f);
            //countWatch
            CountWatch = BinaryFile.ReadInt32(f);
        }

        public void SaveToBin(FileStream f)
        {
            //length
            BinaryFile.WriteInt32(f, Length);
            //countWatch
            BinaryFile.WriteInt32(f, CountWatch);
        }

        public int GetWatchedLength()
        {
            return Length * CountWatch;
        }

        public int GetUniqueWatchedLength()
        {
            return CountWatch > 0 ? Length : 0;
        }

        public int GetNoTouchedLength()
        {
            return CountWatch == 0 ? Length : 0;
        }

        public void AddWatch()
        {
            this.CountWatch++;
        }

        public override string ToString()
        {
            string s = String.Format("{0:f2} min|{1} times", Length / 60d, CountWatch);
            return s;
        }
    }
}
