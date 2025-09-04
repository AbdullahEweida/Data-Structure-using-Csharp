using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Linked_List;//this is for using my linked list

namespace Queue_using_Linked_List
{
    public class MyQueue<T>
    {
        MyLinkedList<T> list = new MyLinkedList<T>();

        public void Enqueue(T value)
        {
            list.AddLast(value);
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty");
            }
            T value = list.HeadValue();
            list.RemoveFirst();
            return value;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty");
            }
            return list.HeadValue();
        }

        public bool IsEmpty()
        {
            return list.Size() == 0;
        }

        public int Size()
        {
            return list.Size();
        }

        public T Front()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty");
            }
            return list.HeadValue();
        }

        public T Rear()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty");
            }
            return list.TailValue();
        }

        public void Display()
        {
            list.Traverse(value => Console.Write(value + " "));
            Console.WriteLine();
        }

    }
}
