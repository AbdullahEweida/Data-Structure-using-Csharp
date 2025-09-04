using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class Graph_using_Adj_Matrix
    {
        private int[,] adjMatrix;
        private int size;
        public Graph_using_Adj_Matrix(int size)
        {
            adjMatrix = new int[size, size];
            this.size = size;
        }
        public void AddEdge(int from, int to)
        {
            if (from >= 0 && from < size && to >= 0 && to < size)
            {
                adjMatrix[from, to] = 1;
                adjMatrix[to, from] = 1; // For undirected graph
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
                adjMatrix[from, to] = 0;
                adjMatrix[to, from] = 0; // For undirected graph
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
                return adjMatrix[from, to] == 1;
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
                if (i == 0) Console.Write("  ");
                Console.Write(i + " ");
            }

            Console.WriteLine();

            for (int i = 0; i < size; i++)
            {
                Console.Write(i + " ");
                for (int j = 0; j < size; j++)
                {
                    Console.Write(adjMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static public void Main_Graph_using_Adj_Matrix()
        {
            Graph_using_Adj_Matrix g = new Graph_using_Adj_Matrix(5);
            g.AddEdge(0, 1);
            g.AddEdge(0, 4);
            g.AddEdge(1, 2);
            g.AddEdge(1, 3);
            g.AddEdge(1, 4);
            g.AddEdge(2, 3);
            g.AddEdge(3, 4);
            Console.WriteLine("Graph (Adjacency Matrix):");
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
