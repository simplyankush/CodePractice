using System;
namespace DataStructures
{
    public class MergeSort
    {
        public MergeSort()
        {
        }


        public static int[] MergeSorts(int[] array, int left , int right)
        {
            if (right > left)
            {
                int mid = (left + right) / 2;
                MergeSorts(array, left, mid);
                MergeSorts(array, mid + 1, right);
                Merge(array, mid, left, right);
            }

            return array;
        }

        private static void Merge(int[] arr, int l, int m, int r)
        {
            // Find sizes of two subarrays to be merged 
            int n1 = m - l + 1;
            int n2 = r - m;

            /* Create temp arrays */
            int[] L = new int[n1];
            int[] R = new int[n2];

            /*Copy data to temp arrays*/
            for (int t = 0; t < n1; ++t)
            {
                L[t] = arr[l + t];
            }

            for (int f = 0; f < n2; ++f)
            {
                R[f] = arr[m + 1 + f];
            }

            /* Merge the temp arrays */

            // Initial indexes of first and second subarrays 
            int i = 0, j = 0;

            // Initial index of merged subarry array 
            int k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }

            /* Copy remaining elements of L[] if any */
            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            /* Copy remaining elements of R[] if any */
            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }
    }
}
