using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Paveiksleliai_24bit
{
    class MyDataList:DataList
    {
        public MyLinkedListNode first { get; set; }
        public MyLinkedListNode last { get; set; }

        public MyDataList()
        { }
        public MyDataList(int w, int h, byte[] b)
        {
            MyLinkedListNode next = new MyLinkedListNode();
            MyLinkedListNode previous = new MyLinkedListNode();

            int j = 54;
            int reiksme;
            for (int i = 0; i < w*h; i++)
            {
                reiksme = (((b[j + 2] << 8) + b[j + 1]) << 8) + b[j];
                PutDataBack(reiksme);
                j += 3;
            }
            length = w * h;
        }

        public void PutDataBack(int data)
        {
            var dd = new MyLinkedListNode(data, null);
            if (first != null)
            {
                last.nextNode = dd;
                last = dd;
            }
            else
            {
                first = dd;
                last = dd;
            }
        }

        public void PutDataFirst(int data)
        {
            first = new MyLinkedListNode(data, first);
        }

    }
}
