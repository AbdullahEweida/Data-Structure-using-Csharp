using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circular_Queue
{
    public class MyCircularQueue
    {
        private int[] data;
        private int head;
        private int tail;
        private int size;
        private int capacity;
        public MyCircularQueue(int k)
        {
            data = new int[k];
            head = -1;
            tail = -1;
            size = 0;
            capacity = k;
        }
        public bool EnQueue(int value)
        {
            if (IsFull()) return false;
            if (IsEmpty()) head = 0;
            tail = (tail + 1) % capacity;
            data[tail] = value;
            size++;
            return true;
        }
        public bool DeQueue()
        {
            if (IsEmpty()) return false;
            if (head == tail)
            {
                head = -1;
                tail = -1;
            }
            else
            {
                head = (head + 1) % capacity;
            }
            size--;
            return true;
        }
        public int Front()
        {
            if (IsEmpty()) return -1;
            return data[head];
        }
        public int Rear()
        {
            if (IsEmpty()) return -1;
            return data[tail];
        }
        public bool IsEmpty()
        {
            return size == 0;
        }
        public bool IsFull()
        {
            return size == capacity;
        }

    }
}
