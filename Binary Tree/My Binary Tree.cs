using System;
using System.Collections.Generic;

namespace Binary_Tree
{
    public class My_Binary_Tree<T>
    {
        private class Node
        {
            public T Data;
            public Node Left;
            public Node Right;

            public Node(T data)
            {
                Data = data;
                Left = null;
                Right = null;
            }
        }

        private Node root = null;

        // Insert : Inserting by Level Order.
        public void Insert(T data)
        {
            Node newNode = new Node(data);

            if (root == null)
            {
                root = newNode;
                return;
            }

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                Node current = queue.Dequeue();

                if (current.Left == null)
                {
                    current.Left = newNode;
                    break;
                }
                else
                {
                    queue.Enqueue(current.Left);
                }

                if (current.Right == null)
                {
                    current.Right = newNode;
                    break;
                }
                else
                {
                    queue.Enqueue(current.Right);
                }
            }
        }

        // InOrder Traversal
        public void InOrderTraversal()
        {
            InOrderTraversal(root);
            Console.WriteLine();
        }

        private void InOrderTraversal(Node node)
        {
            if (node != null)
            {
                InOrderTraversal(node.Left);
                Console.Write(node.Data + " ");
                InOrderTraversal(node.Right);
            }
        }

        // PreOrder Traversal
        public void PreOrderTraversal()
        {
            PreOrderTraversal(root);
            Console.WriteLine();
        }

        private void PreOrderTraversal(Node node)
        {
            if (node != null)
            {
                Console.Write(node.Data + " ");
                PreOrderTraversal(node.Left);
                PreOrderTraversal(node.Right);
            }
        }

        // PostOrder Traversal
        public void PostOrderTraversal()
        {
            PostOrderTraversal(root);
            Console.WriteLine();
        }

        private void PostOrderTraversal(Node node)
        {
            if (node != null)
            {
                PostOrderTraversal(node.Left);
                PostOrderTraversal(node.Right);
                Console.Write(node.Data + " ");
            }
        }

        // Level Order Traversal
        public void LevelOrderTraversal()
        {
            if (root == null) return;

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                Node current = queue.Dequeue();
                Console.Write(current.Data + " ");

                if (current.Left != null) queue.Enqueue(current.Left);
                if (current.Right != null) queue.Enqueue(current.Right);
            }
            Console.WriteLine();
        }

        // Delete Node (replace with deepest node)
        public void Delete(T data)
        {
            if (root == null) return;

            if (root.Left == null && root.Right == null)
            {
                if (root.Data.Equals(data))
                    root = null;
                return;
            }

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            Node nodeToDelete = null;
            Node current = null;

            while (queue.Count > 0)
            {
                current = queue.Dequeue();

                if (current.Data.Equals(data))
                    nodeToDelete = current;

                if (current.Left != null)
                    queue.Enqueue(current.Left);
                if (current.Right != null)
                    queue.Enqueue(current.Right);
            }

            if (nodeToDelete != null && current != null)
            {
                T deepestValue = current.Data;
                DeleteDeepest(current);
                nodeToDelete.Data = deepestValue;
            }
        }

        private void DeleteDeepest(Node deepest)
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                Node current = queue.Dequeue();

                if (current.Left != null)
                {
                    if (current.Left == deepest)
                    {
                        current.Left = null;
                        return;
                    }
                    else
                    {
                        queue.Enqueue(current.Left);
                    }
                }

                if (current.Right != null)
                {
                    if (current.Right == deepest)
                    {
                        current.Right = null;
                        return;
                    }
                    else
                    {
                        queue.Enqueue(current.Right);
                    }
                }
            }
        }

        //this method Maded by chatGPT
        public void FancyPrint()
        {
            int height = GetHeight(root);
            PrintLevel(new List<Node> { root }, 1, height);
        }
        private void PrintLevel(List<Node> nodes, int level, int height)
        {
            if (nodes.Count == 0 || nodes.All(n => n == null))
                return;

            int floor = height - level;
            int edgeLines = (int)Math.Pow(2, Math.Max(floor - 1, 0));
            int firstSpaces = (int)Math.Pow(2, floor) - 1;
            int betweenSpaces = (int)Math.Pow(2, floor + 1) - 1;

            PrintWhitespaces(firstSpaces);

            List<Node> newNodes = new List<Node>();
            foreach (var node in nodes)
            {
                if (node != null)
                {
                    Console.Write(node.Data);
                    newNodes.Add(node.Left);
                    newNodes.Add(node.Right);
                }
                else
                {
                    Console.Write(" ");
                    newNodes.Add(null);
                    newNodes.Add(null);
                }
                PrintWhitespaces(betweenSpaces);
            }
            Console.WriteLine();
            for (int i = 1; i <= edgeLines; i++)
            {
                for (int j = 0; j < nodes.Count; j++)
                {
                    PrintWhitespaces(firstSpaces - i);
                    if (nodes[j] == null)
                    {
                        PrintWhitespaces(edgeLines + edgeLines + i + 1);
                        continue;
                    }

                    if (nodes[j].Left != null)
                        Console.Write("/");
                    else
                        PrintWhitespaces(1);

                    PrintWhitespaces(i + i - 1);

                    if (nodes[j].Right != null)
                        Console.Write("\\");
                    else
                        PrintWhitespaces(1);

                    PrintWhitespaces(edgeLines + edgeLines - i);
                }
                Console.WriteLine();
            }

            PrintLevel(newNodes, level + 1, height);
        }
        private void PrintWhitespaces(int count)
        {
            for (int i = 0; i < count; i++)
                Console.Write(" ");
        }
        private int GetHeight(Node node)
        {
            if (node == null) return 0;
            return 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
        }

    }
}
