using System;
using Binary_Search_Tree__BST_;

class Program
{
    static void Main()
    {
        BST<int> bst = new BST<int>();

        // Insert elements
        bst.Insert(50);
        bst.Insert(30);
        bst.Insert(70);
        bst.Insert(20);
        bst.Insert(40);
        bst.Insert(60);
        bst.Insert(80);

        Console.WriteLine("FancyPrint:");
        bst.FancyPrint();

        Console.WriteLine("InOrder Traversal:");
        bst.InOrderTraversal();   // 20 30 40 50 60 70 80

        Console.WriteLine("PreOrder Traversal:");
        bst.PreOrderTraversal();  // 50 30 20 40 70 60 80

        Console.WriteLine("PostOrder Traversal:");
        bst.PostOrderTraversal(); // 20 40 30 60 80 70 50

        Console.WriteLine("LevelOrder Traversal:");
        bst.BFS(); // 50 30 70 20 40 60 80

        Console.WriteLine("\nSearch 40: " + bst.Search(40)); // true
        Console.WriteLine("Search 90: " + bst.Search(90)); // false

        Console.WriteLine("\nHeight of tree: " + bst.Height()); // 2

        Console.WriteLine("\nDelete 20 (leaf node):");
        bst.Delete(20);
        bst.InOrderTraversal(); // 30 40 50 60 70 80

        Console.WriteLine("\nDelete 30 (node with one child):");
        bst.Delete(30);
        bst.InOrderTraversal(); // 40 50 60 70 80

        Console.WriteLine("\nDelete 50 (node with two children):");
        bst.Delete(50);
        bst.InOrderTraversal(); // 40 60 70 80

        Console.WriteLine("\nClear tree:");
        bst.Clear();
        bst.InOrderTraversal(); // (nothing)
    }
}
