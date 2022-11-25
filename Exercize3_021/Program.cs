using System;

namespace Exercize3_021
{
    class Node
    {
        /*Create Nodes for the circular nexted list*/
        public int rollNumber;
        public string name;
        public Node next;
    }
    class CircularList
    {
        Node LAST;
        public CircularList()
        {
            LAST = null;
        }
        public void DisplayList()
        {
            if (LAST == null)
            {
                Console.WriteLine("List Is Empty");
                return;
            }

        }
        public bool Search(int rollNo, ref Node previous, ref Node current)/*Search for the specified node*/
        {
            for (previous = current = LAST.next; current != LAST; previous = current, current = current.next)
            {
                if (rollNo == current.rollNumber)
                    return (true);/*Returns true if the node is found*/
            }
            if (rollNo == LAST.rollNumber)/*if the node is present at the end*/
                return true;
            else
                return (false);/*Returns false if the node is not found*/
        }
        public bool ListEmpty()
        {
            if (LAST == null)
                return true;
            else
                return false;
        }
        public void traverse()/*Traverses all the nodes of the list*/
        {
            if (ListEmpty())
                Console.WriteLine("\nList is Empty");
            else
            {
                Console.WriteLine("\nRecords in the List are:\n");
                Node currentNode;
                currentNode = LAST.next;
                while (currentNode != LAST)
                {
                    Console.Write(currentNode.rollNumber + "  " + currentNode.name + "\n");
                    currentNode = currentNode.next;
                }
                Console.WriteLine(LAST.rollNumber + "  " + LAST.name + "\n");
            }
        }
        public void FirstNode()
        {
            if (ListEmpty())
                Console.WriteLine("\nList is Empty");
            else
                Console.WriteLine("\nThe First Record in the List is:\n\n" + LAST.next.rollNumber + "  " + LAST.next.name);
        }
        
    }
}