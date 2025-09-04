using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linked_List
{
    public class MyLinkedList<T>
    {
        class Node
        {
            public T data;
            public Node next;
            public Node(T value)
            {
                data = value;
                next = null;
            }
        }
        Node head = null;
        Node tail = null;
        int count = 0;
        public void AddFirst(T value)
        {
            Node newNode = new Node(value);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.next = head;
                head = newNode;
            }
            count++;
        }

        public void AddLast(T value)
        {
            Node newNode = new Node(value);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.next = newNode;
                tail = newNode;
            }
            count++;
        }

        public void RemoveFirst()
        {
            if (head == null)
            {
                throw new InvalidOperationException("List is empty");
            }
            head = head.next;
            count--;
            if (head == null)
            {
                tail = null;
            }
        }

        public void RemoveLast()
        {
            if (head == null)
            {
                throw new InvalidOperationException("List is empty");
            }
            if (head.next == null)
            {
                head = null;
                tail = null;
            }
            else
            {
                Node current = head;
                while (current.next != tail)
                {
                    current = current.next;
                }
                current.next = null;
                tail = current;
            }
            count--;
        }

        public int Size()
        {
            return count;
        }

        public void Traverse(Action<T> action)
        {
            Node current = head;
            while (current != null)
            {
                action(current.data); // Implement the action you want to perform
                current = current.next;
            }
        }

        public void Print()
        {
            Traverse( value => Console.Write(value + " -> "));
            Console.WriteLine("null");
        }

        public T HeadValue()
        {
            if (head == null)
            {
                throw new InvalidOperationException("List is empty");
            }
            return head.data;
        }
        
        public T TailValue()
        {
            if (tail == null)
            {
                throw new InvalidOperationException("List is empty");
            }
            return tail.data;
        }
    }
}
