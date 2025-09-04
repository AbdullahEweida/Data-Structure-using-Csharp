using System;
using System.Collections.Generic;

namespace Graph
{
    public class Graph_using_Adj_List
    {
        private List<int>[] adjList;
        private int size;

        public Graph_using_Adj_List(int size)
        {
            adjList = new List<int>[size];
            for (int i = 0; i < size; i++)
            {
                adjList[i] = new List<int>();
            }
            this.size = size;
        }

        public void AddEdge(int from, int to)
        {
            if (from >= 0 && from < size && to >= 0 && to < size)
            {
                adjList[from].Add(to);
                adjList[to].Add(from); // Undirected
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid vertex index");
            }
        }

        public void RemoveEdge(int from, int to)
        {
            if (from >= 0 && from < size && to >= 0 && to < size)
            {
                adjList[from].Remove(to);
                adjList[to].Remove(from); // Undirected
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid vertex index");
            }
        }

        public bool HasEdge(int from, int to)
        {
            if (from >= 0 && from < size && to >= 0 && to < size)
            {
                return adjList[from].Contains(to);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid vertex index");
            }
        }

        public void PrintGraph()
        {
            for (int i = 0; i < size; i++)
            {
                Console.Write(i + ": ");
                foreach (var neighbor in adjList[i])
                {
                    Console.Write(neighbor + " ");
                }
                Console.WriteLine();
            }
        }

        public int Size => size;

        static public void Main_Graph_using_Adj_List()
        {
            Graph_using_Adj_List g = new Graph_using_Adj_List(5);
            g.AddEdge(0, 1);
            g.AddEdge(0, 4);
            g.AddEdge(1, 2);
            g.AddEdge(1, 3);
            g.AddEdge(1, 4);
            g.AddEdge(2, 3);
            g.AddEdge(3, 4);
            Console.WriteLine("Graph (Adjacency List):");
            g.PrintGraph();
            Console.WriteLine("\n\nCheck edges:");
            Console.WriteLine("0-1: " + g.HasEdge(0, 1));
            Console.WriteLine("2-4: " + g.HasEdge(2, 4));
            Console.WriteLine("\nRemove edge 1-4");
            g.RemoveEdge(1, 4);
            g.PrintGraph();
        }

    }

}
