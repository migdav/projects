using System;
using System.Collections.Generic;
using System.Text;

namespace Paveiksleliai_24bit
{
    class MyLinkedListNode
    {
        public MyLinkedListNode nextNode { get; set; }
        public MyLinkedListNode prevNode { get; set; }
        public int data { get; set; }
        public MyLinkedListNode(int data, MyLinkedListNode n)
        {
            this.data = data;
            this.nextNode = null;
            this.prevNode = null;
        }
        public MyLinkedListNode(int data, MyLinkedListNode n, MyLinkedListNode p)
        {
            this.data = data;
            this.nextNode = n;
            this.prevNode = p;
        }
        public MyLinkedListNode(int data)
        {
            this.data = data;
        }
        public MyLinkedListNode()
        { }
    }
}
