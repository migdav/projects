using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Paveiksleliai_24bit
{
    abstract class DataArray
    {
        protected int length;
        public int Length { get { return length; } }
        public abstract int this[int index] { get; set; }
        public void Print(int n)
        {
            for (int i = 0; i < n; i++)
                Console.Write(" {0} ", this[i]);
            Console.WriteLine();
        }

        public byte[] ToFile(byte[]b)
        {
            int j = 54;
            for (int i = 0; i < this.Length; i++)
            {
                byte[] p = BitConverter.GetBytes(this[i]);
                b[j] = p[0];
                b[j + 1] = p[1];
                b[j + 2] = p[2];
                j += 3;
            }
            return b;
        }

    }
}
