using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_interview_problems.Csharp_Fundamentals
{
    public class LRU_AND_FRU
    {
        public LRU_AND_FRU()
        {
        }
    }

    public class LRUCache<TKey, TValue>
    {
        private readonly int capacity;
        private readonly Dictionary<TKey, LinkedListNode<(TKey key, TValue value)>> cacheMap;
        private readonly LinkedList<(TKey key, TValue value)> lruList;

        public LRUCache(int capacity)
        {
            this.capacity = capacity;
            this.cacheMap = new Dictionary<TKey, LinkedListNode<(TKey key, TValue value)>>();
            this.lruList = new LinkedList<(TKey key, TValue value)>();
        }

        public TValue Get(TKey key)
        {
            if (cacheMap.TryGetValue(key, out LinkedListNode<(TKey key, TValue value)> node))
            {
                // Move the accessed node to the front (most recently used)
                lruList.Remove(node);
                lruList.AddFirst(node);
                return node.Value.value;
            }
            return default(TValue); // Or throw an exception/return a specific value
        }

        public void Put(TKey key, TValue value)
        {
            if (cacheMap.ContainsKey(key))
            {
                // Key exists, update value and move to front
                LinkedListNode<(TKey key, TValue value)> node = cacheMap[key];
                node.Value = (key, value);
                lruList.Remove(node);
                lruList.AddFirst(node);
            }
            else
            {
                // New key, add to cache
                if (cacheMap.Count >= capacity)
                {
                    // Cache is full, remove the least recently used item (last node)
                    LinkedListNode<(TKey key, TValue value)> lruNode = lruList.Last;
                    lruList.RemoveLast();
                    cacheMap.Remove(lruNode.Value.key);
                }
                // Add the new item to the front of the list and dictionary
                LinkedListNode<(TKey key, TValue value)> newNode = new LinkedListNode<(TKey key, TValue value)>((key, value));
                lruList.AddFirst(newNode);
                cacheMap.Add(key, newNode);
            }
        }
    }

    class FRUCache<TKey, TValue>
    {
        private int capacity { get; set; }
        private PriorityQueue<TKey, int> List = new PriorityQueue<TKey, int>();
        private Dictionary<TKey, TValue> CacheLookup = new Dictionary<TKey, TValue>();
        private Dictionary<TKey, int> UsageCount = new Dictionary<TKey, int>();

        public FRUCache(int capacity)
        {
            this.capacity = capacity;
        }

        public TValue Get(TKey key)
        {
            if (CacheLookup.TryGetValue(key, out TValue value))
            {
                if (UsageCount.ContainsKey(key))
                {
                    UsageCount[key]++;
                }
                else
                {
                    UsageCount[key] = 1;
                }
                List.Enqueue(key, UsageCount[key]);
                return value;
            }
            return default(TValue);
        }

        public void Put(TKey key, TValue value)
        {
            if (CacheLookup.Count >= capacity)
            {
                if (List.TryDequeue(out TKey leastUsedKey, out _))
                {
                    CacheLookup.Remove(leastUsedKey);
                    UsageCount.Remove(leastUsedKey);
                }
            }
            CacheLookup[key] = value;
            UsageCount[key] = UsageCount.ContainsKey(key) ? UsageCount[key] + 1 : 1;
            List.Enqueue(key, UsageCount[key]);
        }
    }

}
