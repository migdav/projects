using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace Paveiksleliai_24bit
{
    class MyDataArray : DataArray
    {
        // naudojama Operatyvinei
        int[] bs;
        public MyDataArray(int size)
        { }

        public MyDataArray(int w, int h, byte[] b)
        {
            //Taškus verčiame į spalvų kodus
            bs = new int[w * h];
            int j = 54;
            int reiksme;
            for (int i = 0; i < bs.Length; i++)
            {
                reiksme = (((b[j + 2] << 8) + b[j + 1]) << 8) + b[j];
                bs[i] = reiksme;
                j += 3;
            }
            length = bs.Length;
        }

        public override int this[int index]
        {
            get { return bs[index]; }
            set { bs[index] = value; }
        }

    }
}
