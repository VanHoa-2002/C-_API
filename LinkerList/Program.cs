using System.Collections.Generic;
using System.Xml;

namespace LinkerListTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList<string> linkLst = new LinkedList<string>();
            linkLst.AddLast("123");
            linkLst.AddLast("456");
            linkLst.AddLast("789");
            linkLst.AddLast("414545");
            linkLst.AddLast("45454242422");
            LinkedListNode<string> node = linkLst.First;
     /*       while (node != null){
                Console.WriteLine(node.Value);
                node = node.Next;
            }*/
            LinkedListNode<string> linkedListNode = linkLst.Last;
            while (linkedListNode != null)
            {
                Console.WriteLine(linkedListNode.Value);
                linkedListNode = linkedListNode.Previous;
            }
        }               
    }
}
