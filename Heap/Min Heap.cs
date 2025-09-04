using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    public class Min_Heap
    {
        private List<int> elements = new List<int>();
        public int GetMin()
        {
            if (elements.Count == 0)
                throw new InvalidOperationException("Heap is empty");
            return elements[0];
        }
        public void Insert(int element)
        {
            elements.Add(element);
            HeapifyUp(elements.Count - 1);
        }
        public int RemoveMin()
        {
            if (elements.Count == 0)
                throw new InvalidOperationException("Heap is empty");
            int min = elements[0];
            elements[0] = elements[elements.Count - 1];
            elements.RemoveAt(elements.Count - 1);
            HeapifyDown(0);
            return min;
        }
        private void HeapifyUp(int index)
        {
            while (index > 0)
            {
                int parentIndex = (index - 1) / 2;
                if (elements[index] >= elements[parentIndex])
                    break;
                // Swap
                int temp = elements[index];
                elements[index] = elements[parentIndex];
                elements[parentIndex] = temp;
                index = parentIndex;
            }
        }
        private void HeapifyDown(int index)
        {
            int lastIndex = elements.Count - 1;
            while (index <= lastIndex)
            {
                int leftChildIndex = 2 * index + 1;
                int rightChildIndex = 2 * index + 2;
                int smallestIndex = index;
                if (leftChildIndex <= lastIndex && elements[leftChildIndex] < elements[smallestIndex])
                    smallestIndex = leftChildIndex;
                if (rightChildIndex <= lastIndex && elements[rightChildIndex] < elements[smallestIndex])
                    smallestIndex = rightChildIndex;
                if (smallestIndex == index)
                    break;
                // Swap
                int temp = elements[index];
                elements[index] = elements[smallestIndex];
                elements[smallestIndex] = temp;
                index = smallestIndex;
            }
        }
        public int Count()
        {
            return elements.Count;
        }

        public void PrintHeap()
        {
            Console.WriteLine(string.Join(", ", elements));
        }
        static public void Main_Min_Heap()
        {
            Min_Heap minHeap = new Min_Heap();
            minHeap.Insert(5);
            minHeap.Insert(3);
            minHeap.Insert(8);
            minHeap.Insert(1);
            minHeap.Insert(4);
            Console.WriteLine("Min Heap elements:");
            minHeap.PrintHeap();
            Console.WriteLine($"Minimum element: {minHeap.GetMin()}");
            Console.WriteLine($"Removed minimum element: {minHeap.RemoveMin()}");
            Console.WriteLine("Min Heap after removing minimum:");
            minHeap.PrintHeap();
        }
    }
}
