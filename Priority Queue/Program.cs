using Priority_Queue;

PriorityQueue<int> pq = new PriorityQueue<int>();

pq.Enqueue(10);
pq.Enqueue(5);
pq.Enqueue(20);
pq.Enqueue(1);

Console.WriteLine("Peek (min): " + pq.Peek());  // 1

Console.WriteLine("Dequeue: " + pq.Dequeue()); // 1
Console.WriteLine("Dequeue: " + pq.Dequeue()); // 5

Console.WriteLine("Peek (min): " + pq.Peek());  // 10