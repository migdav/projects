using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Paveiksleliai_24bit;
//copy
namespace Paveiksleliai
{
    class Program
    {
        static void Main(string[] args)
        {
            //Konvertuojame paveikslėlį if JPG į BMP
            var name = Path.GetFileNameWithoutExtension(args[0]);
            Bitmap image = new Bitmap(args[0]);
            image.Save(name + ".bmp", ImageFormat.Bmp);

            //BMP bylos nuskaitymas 
            using (FileStream file = new FileStream(name + ".bmp", FileMode.Open, FileAccess.Read))
            { 
                byte[] b = new byte[file.Length];

                file.Read(b, 0, (int)file.Length);

                int width = BitConverter.ToInt32(b, 0x0012); //paveikslėlio plotis
                int height = BitConverter.ToInt32(b, 0x0016); //paveikslėlio aukštis

                byte[] copyA = b;
                byte[] copyB = b;
                byte[] copyC = b;
                byte[] copyD = b;

                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //Operatyvine
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                var watch = System.Diagnostics.Stopwatch.StartNew();
                MyDataArray array = new MyDataArray(width, height, copyA);
                Console.WriteLine("Pixeliu kiekis:"+array.Length);
                HeapSortArray sortArray = new HeapSortArray();
                sortArray.heapSortArray(array);
                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                Console.WriteLine(elapsedMs);
                int j = 54;
                for (int i = 0; i < array.Length; i++)
                {
                    byte[] p = BitConverter.GetBytes(array[i]);
                    copyA[j] = p[0];
                    copyA[j + 1] = p[1];
                    copyA[j + 2] = p[2];
                    j += 3;
                }
                using (FileStream file2 = new FileStream(name + "_heapSortArrayOP.bmp", FileMode.Create, FileAccess.Write))
                {
                    file2.Seek(0, SeekOrigin.Begin);
                    file2.Write(copyA, 0, (int)file.Length);
                    file2.Close();
                }
                Console.WriteLine("baigiau");
                // FINALLY VEIKIA
                watch = System.Diagnostics.Stopwatch.StartNew();
                MyDataList list = new MyDataList(width, height, copyB);
                HeapSortList sortList = new HeapSortList();
                sortList.heapSortas(list);
                watch.Stop();
                elapsedMs = watch.ElapsedMilliseconds;
                Console.WriteLine(elapsedMs);
                j = 54;
                MyLinkedListNode d = list.first;
                for (int i = 0; i < width * height; i++)
                {
                    byte[] p = BitConverter.GetBytes(d.data);
                    copyB[j] = p[0];
                    copyB[j + 1] = p[1];
                    copyB[j + 2] = p[2];
                    j += 3;
                    d = d.nextNode;
                }
                using (FileStream file2 = new FileStream(name + "_heapSortListOP.bmp", FileMode.Create, FileAccess.Write))
                {
                    file2.Seek(0, SeekOrigin.Begin);
                    file2.Write(copyB, 0, (int)file.Length);
                    file2.Close();
                }

                ////////////////Rikiavimas ratu, bet gavosi labiau linijom////////////////
                int middle = array.Length / 2;
                int middlePlius = middle;
                int middleMinus = middle;
                MyDataArray newArray = new MyDataArray(width, height, copyC);
                for (int i = 0; i < array.Length; i++)
                {
                    int v1 = newArray[middle];
                    int v2 = array[i];
                    newArray[middle] = array[i];
                    if (i % 2 == 0)
                    {
                        newArray[middleMinus] = array[i];
                        middleMinus--;
                    }
                    else
                    {
                        newArray[middlePlius] = array[i];
                        middlePlius++;
                    }
                }
                j = 54;
                for (int i = 0; i < newArray.Length; i++)
                {
                    byte[] p = BitConverter.GetBytes(newArray[i]);
                    copyC[j] = p[0];
                    copyC[j + 1] = p[1];
                    copyC[j + 2] = p[2];
                    j += 3;
                }
                using (FileStream file2 = new FileStream(name + "_ArrayCircled.bmp", FileMode.Create, FileAccess.Write))
                {
                    file2.Seek(0, SeekOrigin.Begin);
                    file2.Write(copyC, 0, (int)file.Length);
                    file2.Close();
                }

                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //Diskine issorine
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                string filename;
                filename = "_heapSortArrayD.dat";
                MyFileArray arrayFile = new MyFileArray(filename, width, height, b);
                HeapSortArray sortArrayD = new HeapSortArray();
                byte[] arrayback = new byte[arrayFile.Length];
                using (arrayFile.fs = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite))
                {
                    Console.WriteLine("\n FILE ARRAY \n");
                    //arrayFile.Print(width * height);
                    sortArrayD.heapSortArray(arrayFile);
                    //rrayFile.Print(width * height);
                    arrayback = arrayFile.ToFile(copyD);
                }
                using (FileStream file3 = new FileStream(name + "_heapSortArrayD.bmp", FileMode.Create, FileAccess.Write))
                {
                    file3.Seek(0, SeekOrigin.Begin);
                    file3.Write(arrayback, 0, (int)file.Length);
                    file3.Close();
                }

                file.Close();
            }
        }
    }
}
