using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    class Arrays
    {
        public static void PrintArray(int[] arr)
        {
            for(int i=0; i<arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }

            Console.WriteLine();
        }
        
        // Program for array rotation
        // Write a function rotate(ar[], d, n) that right rotates arr[] of size n by d elements.

        public static int[] rightRotateArray(int[] array, int d, int n)
        {
            int index = d % n;
            int[] newArray = new int[n];
            for (int i = 0; i < n; i++)
            {
                newArray[index] = array[i];
                index = index + 1;
                index = index % n;
            }

            array = newArray;
            return newArray;
        }

        // Program for array rotation
        // Write a function rotate(ar[], d, n) that left rotates arr[] of size n by d elements.

        public static int[] leftRotateArray(int[] array, int d, int n)
        {
            int index = d % n;
            int[] newArray = new int[n];
            for (int i = 0; i < n; i++)
            {
                newArray[i] = array[index];
                index = index + 1;
                index = index % n;
            }

            array = newArray;
            return newArray;
        }

        public static int PivotIndex(int[] arr)
        {
            int left = 0;
            int right = arr.Length - 1;

            if (arr[left] < arr[right])
            {
                return 0;
            }

            while (left <= right)
            {

                var pivot = (left + right) / 2;

                if (arr[pivot] > arr[pivot + 1])
                {
                    return pivot;
                }
                else if (arr[pivot] < arr[left])
                {
                    left = pivot + 1;
                }
                else
                {
                    right = pivot - 1;
                }
            }

            return 0;

        }

        public static void Main(string[] args)
        {

            Console.WriteLine(PivotIndex(new int[] { 4, 5, 6, 7, 0, 1, 2 }));

            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            PrintArray(arr);
            arr = rightRotateArray(arr, 2, arr.Length);
            PrintArray(arr);
            arr = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            PrintArray(arr);
            arr = leftRotateArray(arr, 2, arr.Length);
            PrintArray(arr);
            Console.ReadLine();
        }

    }
}
