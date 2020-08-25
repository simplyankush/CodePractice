using System;
using System.Collections.Generic;

namespace DataStructures
{
    /**
     * 
     * Design and implement a data structure for Least Recently Used (LRU) cache.
     * It should support the following operations: get and put.

get(key) - Get the value (will always be positive) of the key if the key exists in the cache, otherwise return -1.
put(key, value) - Set or insert the value if the key is not already present. When the cache reached its capacity, it should invalidate the least recently used item before inserting a new item.

The cache is initialized with a positive capacity.

Follow up:
Could you do both operations in O(1) time complexity?
     * 
     * LRUCache cache = new LRUCache( 2 );

cache.put(1, 1);
cache.put(2, 2);
cache.get(1);       // returns 1
cache.put(3, 3);    // evicts key 2
cache.get(2);       // returns -1 (not found)
cache.put(4, 4);    // evicts key 1
cache.get(1);       // returns -1 (not found)
cache.get(3);       // returns 3
cache.get(4);       // returns 4
     * 
     * 
     * 
     **/



    /**
     * Doubly ended linked list to store items and a dictionary.LL will have two pointers to head and tail.
     * Dictionary will store the nodes for fast lookup.
     * Linkedlist will maintain the order of LRU.
     * MRU will be at head. LRU will be at tail.
     * Get - retrieve node from dictionary, delete from LL and add back to head of LL.
     * Put - check if item exists in dict, if yes then item should be deleted from dict and LL. 
     * Its value should be updated and it should be added back at head.
     * 
     * if item doesnt exist, check for size. If size is full, delete LRU from tail.
     * add new item at head.
     * 
     */
    public class LRUCache146
    {
        Node tail;
        Node head;

        int cap;
        Dictionary<int, Node> items;

        public LRUCache146(int capacity)
        {
            tail = new Node();
            head = new Node();
            head.next = tail;
            tail.prev = head;
            cap = capacity;
            items = new Dictionary<int, Node>();
        }

        public int Get(int key)
        {
            if (items.ContainsKey(key))
            {
                var item = items[key];
                RemoveNode(item);
                AddItemToLL(item);

                return item.val;
            }


            return -1;
        }

        public void Put(int key, int value)
        {
            if (items.ContainsKey(key))
            {
                var itemA = items[key];
                RemoveNode(itemA);
                itemA.val = value;
                AddItemToLL(itemA);
                items[key] = itemA;
                return;
            }
            else if (items.Count == cap)
            {
                var lru = tail.prev;
                RemoveNode(lru);

                items.Remove(lru.key);
            }

            var item = new Node(null, null, key, value);
            items[key] = item;
            AddItemToLL(item);
        }

        public void AddItemToLL(int key, int val)
        {
            var item = new Node();
            item.val = val;
            item.key = key;

            AddItemToLL(item);
        }

        public void AddItemToLL(Node item)
        {
            var temp = head.next;
            head.next = item;
            item.prev = head;
            item.next = temp;
            temp.prev = item;
        }

        public void RemoveNode(Node item)
        {
            var prev = item.prev;
            var next = item.next;
            prev.next = next;
            next.prev = prev;
        }


    }

    public class Node
    {
        public Node prev;
        public Node next;
        public int val;
        public int key;

        public Node(Node p, Node n, int key, int val)
        {
            prev = p;
            next = n;
            this.val = val;
            this.key = key;
        }

        public Node()
        {
        }
    }

}
