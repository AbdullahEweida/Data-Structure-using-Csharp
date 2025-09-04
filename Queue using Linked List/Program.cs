using Queue_using_Linked_List;

MyQueue<int> queue = new MyQueue<int>();
queue.Enqueue(10);
queue.Enqueue(20);
queue.Enqueue(30);
queue.Enqueue(40);
queue.Enqueue(50);

Console.WriteLine("After Enqueue 10, 20, 30, 40, 50");
queue.Display();

Console.WriteLine("Front: " + queue.Front());
Console.WriteLine("Rear: " + queue.Rear());
Console.WriteLine("Dequeue: " + queue.Dequeue());
Console.WriteLine("Peek: " + queue.Peek());
Console.WriteLine("Size: " + queue.Size());

Console.WriteLine("After Dequeue");
queue.Display();