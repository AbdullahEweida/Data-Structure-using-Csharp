/// <summary>
/// Represents a generic tree structure.
/// </summary>
/// <summary>
/// Represents a node in a generic tree.
/// </summary>
public class TreeNode<T> where T : IComparable<T>
{
    public T Value { get; set; }
    public List<TreeNode<T>> Children { get; private set; }

    public TreeNode(T value)
    {
        Value = value;
        Children = new List<TreeNode<T>>();
    }

    /// <summary>
    /// Adds a child node to this node.
    /// </summary>
    public void AddChild(TreeNode<T> childNode)
    {
        if (childNode != null)
            Children.Add(childNode);
    }
    /// <summary>
    /// Find and return TreeNode. 
    /// </summary>
    public TreeNode<T> Find(T value)
    {
        if (value.CompareTo(Value) == 0)
        {
            return this;
        }
        foreach (var child in Children)
        {
            var found = child.Find(value);
            if (found != null)
            {
                return found;
            }
        }
        return null;
    }

    public void RemoveChild(T value)
    {
        var childToRemove = Find(value);
        if (childToRemove != null)
        {
            Children.Remove(childToRemove);
        }
    }
}
public class Tree<T> where T : IComparable<T>
{

    public TreeNode<T> Root { get; private set; }

    public Tree(T rootValue)
    {
        Root = new TreeNode<T>(rootValue);
    }
    /// <summary>
    /// Prints the tree in a hierarchical structure.
    /// </summary>
    public static void PrintTree(TreeNode<T> node, string indent = "", bool isLast = true)
    {
        // Display the current node with formatting
        Console.Write(indent);
        Console.Write(isLast ? "└─" : "├─");
        Console.WriteLine(node.Value);

        // Increase indentation for children
        indent += isLast ? "  " : "│ ";

        // Print all children
        for (int i = 0; i < node.Children.Count; i++)
        {
            PrintTree(node.Children[i], indent, i == node.Children.Count - 1);
        }
    }
}