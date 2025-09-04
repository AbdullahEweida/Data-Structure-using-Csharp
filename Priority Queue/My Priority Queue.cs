using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Priority_Queue
{
    public class PriorityQueue<T> where T : IComparable<T>
    {
        private List<T> elements = new List<T>();

        public int Count => elements.Count;

        public void Enqueue(T item)
        {
            elements.Add(item);
            HeapifyUp(elements.Count - 1);
        }

        public T Dequeue()
        {
            if (elements.Count == 0)
                throw new InvalidOperationException("Priority Queue is empty");

            T min = elements[0];
            elements[0] = elements[elements.Count - 1];
            elements.RemoveAt(elements.Count - 1);
            HeapifyDown(0);
            return min;
        }

        public T Peek()
        {
            if (elements.Count == 0)
                throw new InvalidOperationException("Priority Queue is empty");
            return elements[0];
        }

        private void HeapifyUp(int index)
        {
            while (index > 0)
            {
                int parent = (index - 1) / 2;
                if (elements[index].CompareTo(elements[parent]) >= 0)
                    break;

                // Swap
                T temp = elements[index];
                elements[index] = elements[parent];
                elements[parent] = temp;

                index = parent;
            }
        }

        private void HeapifyDown(int index)
        {
            int lastIndex = elements.Count - 1;
            while (index < elements.Count)
            {
                int left = 2 * index + 1;
                int right = 2 * index + 2;
                int smallest = index;

                if (left <= lastIndex && elements[left].CompareTo(elements[smallest]) < 0)
                    smallest = left;

                if (right <= lastIndex && elements[right].CompareTo(elements[smallest]) < 0)
                    smallest = right;

                if (smallest == index)
                    break;

                // Swap
                T temp = elements[index];
                elements[index] = elements[smallest];
                elements[smallest] = temp;

                index = smallest;
            }
        }
    }
}
