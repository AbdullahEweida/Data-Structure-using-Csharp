using dbLinked_List;

My_double_Linked_List<int> db = new My_double_Linked_List<int>();

db.AddToFront(10);
db.AddToFront(20);
db.AddToFront(30);
db.AddToFront(40);
db.AddToFront(50);

db.Print();

db.AddToEnd(60);
db.AddToEnd(70);
db.AddToEnd(80);
db.AddToEnd(90);
db.AddToEnd(100);

db.Print();

db.RemoveFromFront();
db.RemoveFromFront();
db.RemoveFromFront();
db.RemoveFromFront();
db.RemoveFromFront();

db.Print();

db.RemoveFromEnd();
db.RemoveFromEnd();
db.RemoveFromEnd();

db.Print();

db.Reverse();
db.Print();