using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DDMediaWatched
{
    public struct Record
    {
        public int F_ID { get; private set; }

        public int P_ID { get; private set; }

        public short[] CountWatch { get; private set; }

        public Record(int F_ID, int P_ID, short[] CountWatch)
        {
            this.F_ID = F_ID;
            this.P_ID = P_ID;
            this.CountWatch = CountWatch;
        }

        public Record(FileStream f)
        {
            //ID
            F_ID = BinaryFile.ReadInt32(f);
            P_ID = BinaryFile.ReadInt32(f);
            //CountWatch
            int p = BinaryFile.ReadInt32(f);
            CountWatch = new short[p];
            for (int i = 0; i < p; i++)
                CountWatch[i] = BinaryFile.ReadInt16(f);
        }

        public void SaveToBin(FileStream f)
        {
            //ID
            BinaryFile.WriteInt32(f, F_ID);
            BinaryFile.WriteInt32(f, P_ID);
            //series
            BinaryFile.WriteInt32(f, CountWatch.Length);
            foreach (short s in CountWatch)
                BinaryFile.WriteInt16(f, s);
        }
    }
}
