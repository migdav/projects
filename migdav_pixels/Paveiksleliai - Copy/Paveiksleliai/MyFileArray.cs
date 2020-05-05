using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Linq;

namespace Paveiksleliai_24bit
{
    class MyFileArray:DataArray
    {
        public MyFileArray(string filename, int w, int h, byte[] b)
        {
            length = w * h;
            int[] bs = new int[w * h];
            int j = 54;
            int reiksme;
            for (int i = 0; i < bs.Length; i++)
            {
                reiksme = (((b[j + 2] << 8) + b[j + 1]) << 8) + b[j];
                bs[i] = reiksme;
                j += 3;
            }
            if (File.Exists(filename)) File.Delete(filename);
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(filename, FileMode.Create, FileAccess.ReadWrite)))
                {
                    for (int a = 0; a < bs.Length; a++)
                    {
                           writer.Write(bs[a]);
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public FileStream fs { get; set; }

        public override int this[int index]
        {
            get
            {
                Byte[] data = new Byte[8];
                fs.Seek(8 * index, SeekOrigin.Begin);
                fs.Read(data, 0, 8);
                int result = BitConverter.ToInt32(data, 0);
                return result;
            }

            set
            {
                Byte[] data = new Byte[8];
                BitConverter.GetBytes(value).CopyTo(data,0);
                fs.Seek(8 * index, SeekOrigin.Begin);
                fs.Write(data,0,8);
            }
        }
    }
}
