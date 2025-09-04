using Hash_Tables;

var map = new HashTable<string, int>();

map.Put("apple", 5);
map.Put("banana", 2);
map.Put("orange", 7);

Console.WriteLine(map); // Count=3

map.Put("banana", 10); // تحديث
Console.WriteLine("banana = " + map.Get("banana"));

if (map.TryGetValue("apple", out var a))
    Console.WriteLine("apple = " + a);

Console.WriteLine("Keys:");
foreach (var k in map.Keys) Console.WriteLine(" - " + k);

Console.WriteLine("Values:");
foreach (var v in map.Values) Console.WriteLine(" - " + v);

Console.WriteLine("Iterate KV pairs:");
foreach (var kv in map) Console.WriteLine(kv.Key + " => " + kv.Value);

Console.WriteLine("Removing 'orange': " + map.Remove("orange"));
Console.WriteLine(map);

map.Clear();
Console.WriteLine("After clear: " + map);