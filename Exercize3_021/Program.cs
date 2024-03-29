﻿using System;
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
        public void DeleteFirstNode()
        {
            // if list is empty
            if (LAST == null)
                return;
            // if list has one node
            if (LAST.next == LAST)
            {
                LAST = null;
                return;
            }

            LAST.next = LAST.next.next;
        }
        public void DeleteLastNode()
        {
            // if list is empty
            if (LAST == null)
                return;
            // if list has one node
            if (LAST.next == LAST)
            {
                LAST = null;
                return;
            }

            Node p = LAST.next;
            while (p.next != LAST)
                p = p.next;
            p.next = LAST.next;
            LAST = p;
        }
        public void DeleteNode(int x)
        {
            //If the List is Empty
            if (LAST == null)
                return;
            //If want delete only node
            if (LAST.next == LAST && LAST.rollNumber ==x)
            {
                LAST = null;
                return;
            }
            //If want delete the first node
            if (LAST.next.rollNumber == x)
            {
                LAST.next = LAST.next.next;
                return;
            }
            //If want delete the node in between the list
            Node p = LAST.next;
            while (p.next != LAST.next)
            {
                if (p.next.rollNumber == x)
                    break;
                p = p.next;
            }
            if (p.next == LAST.next)
                Console.WriteLine(x + " not found in the list.");
            else
            {
                p.next = p.next.next;
                if (LAST.rollNumber == x)
                    LAST = p;
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
                    case 6:
                        list.DeleteFirstNode();
                        break;
                    case 7:
                        list.DeleteLastNode();
                        break;
                    case 8:
                        Console.WriteLine("Enter the element to be deleted : ");
                        data = Convert.ToInt32(Console.ReadLine());
                        list.DeleteNode(data);
                        break;
                    default:
                        Console.WriteLine("Wrong choice");
                        break;
                }
                Console.WriteLine();
            }
            Console.WriteLine("Exiting");
        }
    }
}