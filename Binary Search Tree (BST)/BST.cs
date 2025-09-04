using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Search_Tree__BST_
{
    public class BST<T> where T : IComparable<T>
    {
        class Node
        {
            public T data;
            public Node left;
            public Node right;
            public Node(T data)
            {
                this.data = data;
                left = null;
                right = null;
            }
        }

        Node root = null;

        public void Insert(T data)
        {
            Queue<Node> queue = new Queue<Node>();
            Node newNode = new Node(data);
            if (root == null)
            {
                root = newNode;
                return;
            }
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                Node current = queue.Dequeue();
                if (data.CompareTo(current.data) < 0)
                {
                    if (current.left == null)
                    {
                        current.left = newNode;
                        return;
                    }
                    else
                    {
                        queue.Enqueue(current.left);
                    }
                }
                else
                {
                    if (current.right == null)
                    {
                        current.right = newNode;
                        return;
                    }
                    else
                    {
                        queue.Enqueue(current.right);
                    }
                }
            }
        }

        public bool Search(T data)
        {
            Node current = root;
            while (current != null)
            {
                if (data.CompareTo(current.data) == 0)
                {
                    return true;
                }
                else if (data.CompareTo(current.data) < 0)
                {
                    current = current.left;
                }
                else
                {
                    current = current.right;
                }
            }
            return false;
        }

        public void InOrderTraversal()
        {
            InOrderTraversal(root);
            Console.WriteLine();
        }
        private void InOrderTraversal(Node node)
        {
            if (node == null) return;
            InOrderTraversal(node.left);
            Console.Write(node.data + " ");
            InOrderTraversal(node.right);
        }

        public void PreOrderTraversal()
        {
            PreOrderTraversal(root);
            Console.WriteLine();
        }
        private void PreOrderTraversal(Node node)
        {
            if (node == null) return;
            Console.Write(node.data + " ");
            PreOrderTraversal(node.left);
            PreOrderTraversal(node.right);
        }

        public void PostOrderTraversal()
        {
            PostOrderTraversal(root);
            Console.WriteLine();
        }
        private void PostOrderTraversal(Node node)
        {
            if (node == null) return;
            PostOrderTraversal(node.left);
            PostOrderTraversal(node.right);
            Console.Write(node.data + " ");
        }

        public void BFS()
        {
            if (root == null) return;
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                Node current = queue.Dequeue();
                Console.Write(current.data + " ");
                if (current.left != null) queue.Enqueue(current.left);
                if (current.right != null) queue.Enqueue(current.right);
            }
            Console.WriteLine();
        }

        public int Height()
        {
            return Height(root);
        }
        private int Height(Node node)
        {
            if (node == null) return -1;
            return 1 + Math.Max(Height(node.left), Height(node.right));
        }

        public void Delete(T data)
        {
            root = Delete(root, data);
        }
        private Node Delete(Node node, T data)
        {
            if (node == null) return null;
            if (data.CompareTo(node.data) < 0)
            {
                node.left = Delete(node.left, data);
            }
            else if (data.CompareTo(node.data) > 0)
            {
                node.right = Delete(node.right, data);
            }
            else
            {
                // Node with only one child or no child
                if (node.left == null) return node.right;
                else if (node.right == null) return node.left;

                // Node with two children: Get the inorder successor (smallest in the right subtree)
                Node temp = MinValueNode(node.right);
                node.data = temp.data;
                node.right = Delete(node.right, temp.data);
            }
            return node;
        }
        private Node MinValueNode(Node node)
        {
            Node current = node;
            while (current.left != null)
            {
                current = current.left;
            }
            return current;
        }

        public void Clear()
        {
            root = null;
        }

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
                    Console.Write(node.data);
                    newNodes.Add(node.left);
                    newNodes.Add(node.right);
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

                    if (nodes[j].left != null)
                        Console.Write("/");
                    else
                        PrintWhitespaces(1);

                    PrintWhitespaces(i + i - 1);

                    if (nodes[j].right != null)
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
            return 1 + Math.Max(GetHeight(node.left), GetHeight(node.right));
        }

    }
}
