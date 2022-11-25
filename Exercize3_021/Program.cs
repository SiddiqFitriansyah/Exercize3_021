using System;
using System.Collections.Generic;

namespace Exercize3_021
{
    class Node
    {
        /*Create Nodes for the circular nexted list*/
        public int rollNumber;
        public string name;
        public Node next;

        public Node(int nim)
        {
            rollNumber = nim;
            next = null;
        }
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
            Node p = LAST.next;
            do
            {
                Console.Write(p.rollNumber + " ");
                p = p.next;
            } while (p != LAST.next);

            Console.WriteLine();
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
        public void InsertInBeginning(int data)
        {
            Node temp = new Node(data);
            temp.next = LAST.next;
            LAST.next = temp;
        }
        public void InsertInEmptyList(int data)
        {
            Node temp = new Node(data);
            LAST = temp;
            LAST.next = LAST;
        }
        public void InsertAtTheEnd(int data)
        {
            Node temp = new Node(data);
            temp.next = LAST.next;
            LAST.next = temp;
            LAST = temp;
        }
        public void CreateList()
        {
            int i, n, data;
            Console.WriteLine("Enter the Number of Node: ");
            n = Convert.ToInt32(Console.ReadLine());

            if (n == null)
                return;
            Console.Write("Enter the Element to be Inserted: ");
            data = Convert.ToInt32(Console.ReadLine());
            InsertInEmptyList(data);

            for (i = 2; i < data; i++)/*For i lebih dari data yang dibuat*/
            {
                Console.Write("Enter the Elemenet to be Inserted: ");
                InsertAtTheEnd(data);
            }
        }
        public void InsertAfter(int data, int x)
        {
            Node p = LAST.next;
            do
            {
                if (p.rollNumber == x)
                    break;
                p = p.next;
            } while (p != LAST.next);

            if (p == LAST.next && p.rollNumber != x)
                Console.WriteLine(x + " not present in the list.");
            else
            {
                Node temp = new Node(data);
                temp.next = p.next;
                if (p == LAST)
                    LAST = temp;
            }
        }
        public static void Main(string[] args)
        {
            int choice, data, x;

            CircularList list = new CircularList();

            list.CreateList();

            while (true)
            {
                Console.WriteLine("1.Display list.");
                Console.WriteLine("2.Insert in an empty list.");
                Console.WriteLine("3.Insert in the beginning of the list.");
                Console.WriteLine("4.Insert at the end of the list.");
                Console.WriteLine("5.Insert after a node.");
                Console.WriteLine("6.Delete first node.");
                Console.WriteLine("7.Delete last node.");
                Console.WriteLine("8.Delete any node.");
                Console.WriteLine("9.Quit.");

                Console.Write("Enter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 9)
                    break;

                switch (choice)
                {
                    case 1:
                        list.DisplayList();
                        break;
                    case 2:
                        Console.WriteLine("Enter the element to be insterted : ");
                        data = Convert.ToInt32(Console.ReadLine());
                        list.InsertInEmptyList(data);
                        break;
                    case 3:
                        Console.WriteLine("Enter the element to be inserted : ");
                        data = Convert.ToInt32(Console.ReadLine());
                        list.InsertInBeginning(data);
                        break;
                    case 4:
                        Console.WriteLine("Enter the element to be inserted : ");
                        data = Convert.ToInt32(Console.ReadLine());
                        list.InsertAtTheEnd(data);
                        break;

                    case 5:
                        Console.WriteLine("Enter the element to be inserted : ");
                        data = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the element after which to be inserted : ");
                        x = Convert.ToInt32(Console.ReadLine());
                        list.InsertAfter(data, x);
                        break;
                }
                Console.WriteLine();
            }
            Console.WriteLine("Exiting");
        }
    }
}