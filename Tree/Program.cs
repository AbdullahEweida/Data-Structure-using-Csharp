Tree<string> tree = new Tree<string>("Root");

var child1 = new TreeNode<string>("Child 1");
var child2 = new TreeNode<string>("Child 2");
var child3 = new TreeNode<string>("Child 3");

tree.Root.AddChild(child1);
tree.Root.AddChild(child2);
tree.Root.AddChild(child3);

child1.AddChild(new TreeNode<string>("Child 1.1"));
child1.AddChild(new TreeNode<string>("Child 1.2"));
child2.AddChild(new TreeNode<string>("Child 2.1"));
child3.AddChild(new TreeNode<string>("Child 3.1"));
child3.AddChild(new TreeNode<string>("Child 3.2"));

Console.WriteLine("Tree structure:");
Tree<string>.PrintTree(tree.Root);

var found = tree.Root.Find("Child 2.1");
Console.WriteLine(found != null
    ? $"\nFound node: {found.Value}"
    : "\nNode not found");

Console.WriteLine("\nRemoving 'Child 1.2'...");
child1.RemoveChild("Child 1.2");

Console.WriteLine("\nTree structure after removal:");
Tree<string>.PrintTree(tree.Root);