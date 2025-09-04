
using Linked_List;

MyLinkedList<int> list = new MyLinkedList<int>();

list.AddFirst(10);
list.AddFirst(20);
list.AddFirst(30);
list.AddFirst(40);

Console.WriteLine("After adding first {10, 20, 30, 40}");
list.Print();

list.AddLast(5);
list.AddLast(15);
list.AddLast(25);
list.AddLast(35);

Console.WriteLine("After adding last {5, 15, 25, 35}");
list.Print();

list.RemoveFirst();
list.RemoveLast();

Console.WriteLine("After removing first and last");
list.Print();

Console.WriteLine("Size: " + list.Size());