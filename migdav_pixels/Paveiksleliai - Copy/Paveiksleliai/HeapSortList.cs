using System;
using System.Collections.Generic;
using System.Text;

namespace Paveiksleliai_24bit
{
    class HeapSortList
    {
        int skait = 0;

        //trecias variantas
        public void heapSortas(MyDataList list)
        {
            int n = list.Length;
            skait++;

            // Build heap (rearrange array) 
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                skait++;
                heapify(list, n, i);
            }

            // One by one extract an element from heap 
            for (int i = n - 1; i >= 0; i--)
            {

                skait++;

                // Move current root to end 
                Swap(GetNth(list.first, 0), GetNth(list.first, i));
                //int temp = array[0];
                //array[0] = array[i];
                //array[i] = temp;

                // call max heapify on the reduced heap 

                skait++;

                heapify(list, i, 0);
            }
            Console.WriteLine("SkaitliukasLinkedList =" + skait);
        }

        void heapify(MyDataList list, int n, int i)
        {
            //Console.WriteLine("im");
            skait++;
            int largest = i; // Initialize largest as root 
            skait++;
            int l = 2 * i + 1; // left = 2*i + 1 
            skait++;
            int r = 2 * i + 2; // right = 2*i + 2 
            //int a = array[0];
            // If left child is larger than root 
            if (l < n && GetNth(list.first, l).data > GetNth(list.first, largest).data)
            {
                largest = l;
                skait++;
            }

            // If right child is larger than largest so far 
            if (r < n && GetNth(list.first, r).data > GetNth(list.first, largest).data)
            {
                largest = r;
                skait++;
            }

            // If largest is not root 
            if (largest != i)
            {
                skait++;
                Swap(GetNth(list.first, i), GetNth(list.first, largest));
                //int swap = array[i];
                //array[i] = array[largest];
                //array[largest] = swap;

                // Recursively heapify the affected sub-tree 
                skait++;
                heapify(list, n, largest);
            }
        }

        private MyLinkedListNode GetNth(MyLinkedListNode f, int index)
        {
            skait++;
            MyLinkedListNode current = f;
            skait++;
            int count = 0; /* index of Node we are  
                        currently looking at */
            while (current != null)
            {
                if (count == index)
                {
                    skait++;
                    return current;
                }
                skait++;
                count++;
                skait++;
                current = current.nextNode;
            }
            return null;

        }

        private void Swap(MyLinkedListNode a, MyLinkedListNode b)
        {
            skait++;
            int d = a.data;
            skait++;
            a.data = b.data;
            skait++;
            b.data = d;
        }
    }
}
