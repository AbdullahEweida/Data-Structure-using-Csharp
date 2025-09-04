using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_using_Array
{
    public class My_Stack <T>
    {
        T[] arr;
        int top;
        public My_Stack(int size)
        {
            arr = new T[size];
            top = -1;
        }

        public void Push(T item)
        {
            if (top == arr.Length - 1)
            {
                throw new StackOverflowException("Stack is full");
            }
            arr[++top] = item;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new StackOverflowException("Stack is empty");
            }
            return arr[top--];
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new StackOverflowException("Stack is empty");
            }
            return arr[top];
        }

        public bool IsEmpty()
        {
            return top == -1;
        }

        public int Size()
        {
            return top + 1;
        }

        public void Display()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack is empty");
                return;
            }
            for (int i = top; i >= 0; i--)
            {
                Console.WriteLine(arr[i]);
            }
        }
    }
}
