using Binary_Tree;

class Program
{
    static void Main(string[] args)
    {
        My_Binary_Tree<int> bt = new My_Binary_Tree<int>();

        // inserting nodes
        bt.Insert(1);
        bt.Insert(2);
        bt.Insert(3);
        bt.Insert(4);
        bt.Insert(5);
        bt.Insert(6);
        bt.Insert(7);
        bt.Insert(8);
        bt.Insert(9);

        Console.WriteLine("Fancy Print:");
        bt.FancyPrint();

        Console.WriteLine("\nInOrder Traversal:");
        bt.InOrderTraversal();

        Console.WriteLine("PreOrder Traversal:");
        bt.PreOrderTraversal();

        Console.WriteLine("PostOrder Traversal:");
        bt.PostOrderTraversal();

        Console.WriteLine("LevelOrder Traversal:");
        bt.LevelOrderTraversal();

        Console.WriteLine("\nDelete node 3 and reprint:");
        bt.Delete(3);
        bt.FancyPrint();
    }
}
