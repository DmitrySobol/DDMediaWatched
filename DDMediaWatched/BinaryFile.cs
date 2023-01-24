﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DDMediaWatched
{
    public static class BinaryFile
    {
        private static byte[]
            buf = new byte[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
        public static int FileReadInt32(FileStream f)
        {
            f.Read(buf, 0, 4);
            return BitConverter.ToInt32(buf, 0);
        }

        public static void FileWriteInt32(FileStream f, int a)
        {
            f.Write(BitConverter.GetBytes(a), 0, 4);
        }

        public static long FileReadInt64(FileStream f)
        {
            f.Read(buf, 0, 8);
            return BitConverter.ToInt64(buf, 0);
        }

        public static void FileWriteInt64(FileStream f, long a)
        {
            f.Write(BitConverter.GetBytes(a), 0, 8);
        }

        public static string FileReadString(FileStream f)
        {
            f.Read(buf, 0, 4);
            int p = BitConverter.ToInt32(buf, 0);
            byte[] BigBuf = new byte[p];
            f.Read(BigBuf, 0, p);
            return Encoding.UTF8.GetString(BigBuf, 0, p);
        }

        public static void FileWriteString(FileStream f, string a)
        {
            byte[] BigBuf = Encoding.UTF8.GetBytes(a);
            f.Write(BitConverter.GetBytes(BigBuf.Length), 0, 4);
            f.Write(BigBuf, 0, BigBuf.Length);
        }

        public static byte FileReadByte(FileStream f)
        {
            f.Read(buf, 0, 1);
            return buf[0];
        }

        public static void FileWriteByte(FileStream f, byte a)
        {
            buf[0] = a;
            f.Write(buf, 0, 1);
        }
    }
}
