using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    public class Max_Heap
    {
        private List<int> elements = new List<int>();
        public int GetMax()
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
        public int RemoveMax()
        {
            if (elements.Count == 0)
                throw new InvalidOperationException("Heap is empty");
            int max = elements[0];
            elements[0] = elements[elements.Count - 1];
            elements.RemoveAt(elements.Count - 1);
            HeapifyDown(0);
            return max;
        }
        private void HeapifyUp(int index)
        {
            while (index > 0)
            {
                int parentIndex = (index - 1) / 2;
                if (elements[index] <= elements[parentIndex])
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
                int largestIndex = index;
                if (leftChildIndex <= lastIndex && elements[leftChildIndex] > elements[largestIndex])
                    largestIndex = leftChildIndex;
                if (rightChildIndex <= lastIndex && elements[rightChildIndex] > elements[largestIndex])
                    largestIndex = rightChildIndex;
                if (largestIndex == index)
                    break;
                // Swap
                int temp = elements[index];
                elements[index] = elements[largestIndex];
                elements[largestIndex] = temp;
                index = largestIndex;
            }
        }
        static public void Main_Max_Heap()
        {
            Max_Heap maxHeap = new Max_Heap();
            maxHeap.Insert(10);
            maxHeap.Insert(20);
            maxHeap.Insert(5);
            Console.WriteLine("Max: " + maxHeap.GetMax()); // 20
            Console.WriteLine("Removed Max: " + maxHeap.RemoveMax()); // 20
            Console.WriteLine("New Max: " + maxHeap.GetMax()); // 10
        }
    }
}
