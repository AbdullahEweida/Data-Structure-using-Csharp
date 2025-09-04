using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash_Tables
{
    public class HashTable<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        private const int DefaultCapacity = 16;
        private const double LoadFactorThreshold = 0.75;

        private LinkedList<Node>[] buckets;
        private int count;

        private class Node
        {
            public TKey Key;
            public TValue Value;
            public Node(TKey k, TValue v) { Key = k; Value = v; }
        }

        public HashTable(int capacity = DefaultCapacity)
        {
            if (capacity <= 0) capacity = DefaultCapacity;
            buckets = new LinkedList<Node>[capacity];
            count = 0;
        }

        public int Count => count;

        private int GetBucketIndex(TKey key)
        {
            int h = key?.GetHashCode() ?? 0;
            // make non-negative and mod by buckets length
            return (h & 0x7fffffff) % buckets.Length;
        }

        public void Put(TKey key, TValue value)
        {
            if (NeedsResize()) Resize(buckets.Length * 2);

            int idx = GetBucketIndex(key);
            if (buckets[idx] == null) buckets[idx] = new LinkedList<Node>();

            foreach (var node in buckets[idx])
            {
                if (Equals(node.Key, key))
                {
                    node.Value = value; // update
                    return;
                }
            }

            buckets[idx].AddLast(new Node(key, value));
            count++;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            int idx = GetBucketIndex(key);
            var list = buckets[idx];
            if (list != null)
            {
                foreach (var node in list)
                {
                    if (Equals(node.Key, key))
                    {
                        value = node.Value;
                        return true;
                    }
                }
            }
            value = default!;
            return false;
        }

        public TValue Get(TKey key)
        {
            if (TryGetValue(key, out var v)) return v;
            throw new KeyNotFoundException("Key not found");
        }

        public bool ContainsKey(TKey key)
        {
            return TryGetValue(key, out _);
        }

        public bool Remove(TKey key)
        {
            int idx = GetBucketIndex(key);
            var list = buckets[idx];
            if (list == null) return false;

            var cur = list.First;
            while (cur != null)
            {
                if (Equals(cur.Value.Key, key))
                {
                    list.Remove(cur);
                    count--;
                    return true;
                }
                cur = cur.Next;
            }
            return false;
        }

        public void Clear()
        {
            buckets = new LinkedList<Node>[DefaultCapacity];
            count = 0;
        }

        public IEnumerable<TKey> Keys
        {
            get
            {
                foreach (var kv in this) yield return kv.Key;
            }
        }

        public IEnumerable<TValue> Values
        {
            get
            {
                foreach (var kv in this) yield return kv.Value;
            }
        }

        private bool NeedsResize()
        {
            return (double)(count + 1) / buckets.Length > LoadFactorThreshold;
        }

        private void Resize(int newCapacity)
        {
            var old = buckets;
            buckets = new LinkedList<Node>[newCapacity];
            count = 0;

            for (int i = 0; i < old.Length; i++)
            {
                var list = old[i];
                if (list == null) continue;
                foreach (var node in list)
                {
                    Put(node.Key, node.Value); // rehashes into new buckets
                }
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            for (int i = 0; i < buckets.Length; i++)
            {
                var list = buckets[i];
                if (list == null) continue;
                foreach (var node in list)
                    yield return new KeyValuePair<TKey, TValue>(node.Key, node.Value);
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public override string ToString()
        {
            return $"HashTable(Count={count}, Buckets={buckets.Length})";
        }
    }
    public class My_Hash_Set
    {
    }
}
