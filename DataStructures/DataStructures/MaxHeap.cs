using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    class MaxHeap
    {
        public static void BuildHeap(int[] arr)
        {
            var size = arr.Length;

            int start = (size / 2) - 1;

            for (int i = start; i >= 0; i--)
            {
                Heapify(arr, i, size);
            }
        }

        public static void Heapify(int[] arr, int root, int size)
        {
            var largest = root;
            var left = root * 2 + 1;
            var right = root * 2 + 2;

            if (left < size && arr[left] > arr[largest])
            {
                largest = left;
            }
            if (right < size && arr[right] > arr[largest])
            {
                largest = right;
            }

            if (largest != root)
            {
                var temp = arr[root];
                arr[root] = arr[largest];
                arr[largest] = temp;

                Heapify(arr, largest, size);
            }
        }

        // A utility function to print the array  
        // representation of Heap  
        public static void printHeap(int[] arr, int n)
        {
            Console.WriteLine("Array representation of Heap is:");

            for (int i = 0; i < n; ++i)
                Console.Write(arr[i] + " ");

            Console.WriteLine();
        }
        ////// Driver Code  
        ////public static void Main()
        ////{
        ////    // Binary Tree Representation  
        ////    // of input array  
        ////    // 1  
        ////    //     / \  
        ////    // 3         5  
        ////    // / \     / \  
        ////    // 4     6 13 10  
        ////    // / \ / \  
        ////    // 9 8 15 17  
        ////    int[] arr = { 1, 3, 5, 4, 6, 13, 10,
        ////            9, 8, 15, 17 };

        ////    int n = arr.Length;

        ////    BuildHeap(arr);

        ////    printHeap(arr, n);
        ////}
    }
}
