using System;
using System.Collections.Generic;
using System.Text;

namespace Paveiksleliai_24bit
{
    class HeapSortArray
    {
        int skait = 0;
        public void heapSortArray(DataArray array)
        {
            int n = array.Length;

            for (int i = n / 2 - 1; i >= 0; i--)
            {
                skait++;
                heapify(array, n, i);
            }

            for (int i = n - 1; i >= 0; i--)
            {
                //array.Swap(0, i);
                int temp = array[0];
                skait++;
                array[0] = array[i];
                skait++;
                array[i] = temp;
                skait++;
                heapify(array, i, 0);
            }
            Console.WriteLine("Skaitliukas=" +skait);
        }

        void heapify(DataArray array, int n, int i)
        {
            int largest = i;
            skait++;
            int l = 2 * i + 1;
            skait++;
            int r = 2 * i + 2;
            skait++;
            int a = array[0];
            skait++;

            if (l < n && array[l] > array[largest])
            { 
                largest = l;
                skait++;
            }


            if (r < n && array[r] > array[largest])
            {
                largest = r;
                skait++;
            }
                
            if (largest != i)
            {
                //array.Swap(i, largest);
                int swap = array[i];
                skait++;
                array[i] = array[largest];
                skait++;
                array[largest] = swap;
                skait++;

                heapify(array, n, largest);
            }
        }

    }
}
