using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbLinked_List
{
    internal class My_double_Linked_List<T>
    {
        public class Node
        {
            public T data;
            public Node next;
            public Node prev;
            public Node(T value)
            {
                data = value;
                next = null;
                prev = null;
            }
        }
        private Node head = null;
        private Node tail = null;
        private int size = 0;
        public void AddToFront(T value)
        {
            Node newNode = new Node(value);
            if (IsEmpty())
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.next = head;
                head.prev = newNode;
                head = newNode;
            }
            size++;
        }
        public void AddToEnd(T value)
        {
            Node newNode = new Node(value);
            if (IsEmpty())
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.next = newNode;
                newNode.prev = tail;
                tail = newNode;
            }
            size++;
        }
        public T RemoveFromFront()
        {
            if (IsEmpty()) throw new InvalidOperationException("List is Empty");

            T removedData = head.data;

            if (head == tail)
            {
                head = null;
                tail = null;
                return removedData;
            }
            else
            {
                head = head.next;
                head.prev = null;
                return removedData;
            }
            size--;
        }
        public T RemoveFromEnd()
        {

            if (IsEmpty()) throw new Exception("List is empty");

            T removedData = tail.data;

            if (head == tail)
            {
                head = null;
                tail = null;
                return removedData;
            }
            else
            {
                tail = tail.prev;
                tail.next = null;
                return removedData;
            }
            size--;
        }
        public int GetSize()
        {
            return size;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            size = 0;
        }

        public void TraverseForward(Action<T> action)
        {
            Node current = head;
            while (current != null)
            {
                action(current.data);
                current = current.next;
            }
        }

        public void TraverseBackward(Action<T> action)
        {
            Node current = tail;
            while (current != null)
            {
                action(current.data);
                current = current.prev;
            }
        }

        public void Reverse()
        {
            Node current = head;
            Node temp = null;
            while (current != null)
            {
                temp = current.prev;
                current.prev = current.next;
                current.next = temp;
                current = current.prev;
            }
            if (temp != null)
            {
                head = temp.prev;
            }
        }
        
        public void Print()
        {
            Console.Write("Linked List: null <-> ");
            TraverseForward(data => Console.Write(data + " <-> "));
            Console.WriteLine("null");
        }
    }
}
