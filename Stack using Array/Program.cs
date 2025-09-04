using Stack_using_Array;

My_Stack<int> stack = new My_Stack<int>(10);

stack.Push(1);
stack.Push(2);
stack.Push(3);
stack.Push(4);
stack.Push(5);
stack.Push(6);
stack.Push(7);
stack.Push(8);
stack.Push(9);
stack.Push(10);

stack.Display();

Console.WriteLine("Popped element is: " + stack.Pop());
Console.WriteLine("Popped element is: " + stack.Pop());

stack.Display();

Console.WriteLine("Top element is: " + stack.Peek());