using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class MinHeap
    {
            int[] items;

            int size;

        public MinHeap(int maxSize)
        {
            items = new int[maxSize];
            size = 0;
        }

        public MinHeap(int[] arr)
            {
                items = arr;
                size = arr.Length;
                BuildHeap();
            }

            private void BuildHeap()
            {
                int start = size / 2;
                for (int i = start; i >= 0; i--)
                {
                    Heapify(i);
                }
            }

            private void Heapify(int root)
            {
                int smallest = root;
                int left = (root * 2) + 1;
                int right = (root * 2) + 2;

                if (left < size && items[left] < items[smallest])
                {
                    smallest = left;
                }

                if (right < size && items[right] < items[smallest])
                {
                    smallest = right;
                }

                if (smallest != root)
                {
                    var temp = items[root];
                    items[root] = items[smallest];
                    items[smallest] = temp;

                    Heapify(smallest);
                }
            }

            public int Pop()
            {
                if (size > 0)
                {
                    var smallest = items[0];
                    items[0] = items[size - 1];
                    size--;
                    Heapify(0);
                    return smallest;
                }

                throw new Exception("Heap is empty");
            }

            public bool IsEmpty()
            {
                return size <= 0;
            }

            public void PrintHeap()
            {
                for (int i = 0; i < size; i++)
                {
                    Console.Write(items[i] + "  ");
                }

                Console.WriteLine();
            }

            public void Insert(int key)
            {
                 items[size] = key;
                 size++;

                 HeapifyBottomUp(size - 1);
            }

            private void HeapifyBottomUp(int node)
            {
                 var parent = (node - 1) / 2;

                 if (parent < 0)
                 {
                     return;
                 }

                if (items[node] < items[parent])
                {
                    var temp = items[node];
                    items[node] = items[parent];
                    items[parent] = temp;

                    HeapifyBottomUp(parent);
                }
            }

        public int Size()
        {
            return size;
        }

        public int Peek()
        {
            if (size > 0)
            {
                return items[0];
            }

            throw new Exception("Heap is empty");
        }
    }
}
