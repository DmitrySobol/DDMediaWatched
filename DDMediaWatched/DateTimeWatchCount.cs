using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DDMediaWatched
{
    public class DateTimeWatchCount
    {
        public int Year { get; private set; }
        public int Month { get; private set; }
        public int Day { get; private set; }
        public short WatchCount { get; set; }

        public DateTimeWatchCount(int Year, int Month, int Day, short WatchCount)
        {
            this.Year = Year;
            this.Month = Month;
            this.Day = Day;
            this.WatchCount = WatchCount;
        }

        public DateTimeWatchCount(FileStream f)
        {
            this.Year = BinaryFile.ReadInt32(f);
            this.Month = BinaryFile.ReadInt32(f);
            this.Day = BinaryFile.ReadInt32(f);
            this.WatchCount = BinaryFile.ReadInt16(f);
        }

        public void SaveToBin(FileStream f)
        {
            BinaryFile.WriteInt32(f, this.Year);
            BinaryFile.WriteInt32(f, this.Month);
            BinaryFile.WriteInt32(f, this.Day);
            BinaryFile.WriteInt16(f, this.WatchCount);
        }

        public DateTime GetDateTime()
        {
            return new DateTime(this.Year, this.Month, this.Day);
        }
    }
}
