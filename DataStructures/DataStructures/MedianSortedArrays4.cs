using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    class MedianSortedArrays4
    {
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var result = new int[nums1.Length + nums2.Length];

            if (nums1 == null || nums1.Length == 0)
            {
                return Median(nums2);
            }

            if (nums2 == null || nums2.Length == 0)
            {
                return Median(nums1);
            }

            var oneIndex = 0;
            var twoIndex = 0;
            var index = 0;

            while (oneIndex < nums1.Length && twoIndex < nums2.Length)
            {
                if (nums1[oneIndex] <= nums2[twoIndex])
                {
                    result[index] = nums1[oneIndex];
                    oneIndex++;
                }
                else
                {
                    result[index] = nums2[twoIndex];
                    twoIndex++;
                }

                index++;
            }

            while (oneIndex < nums1.Length)
            {
                result[index] = nums1[oneIndex];
                index++;
                oneIndex++;
            }

            while (twoIndex < nums2.Length)
            {
                result[index] = nums2[twoIndex];
                index++;
                twoIndex++;
            }

            return Median(result);
        }

        public static double Median(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            if (nums.Length % 2 != 0)
            {
                var index = (nums.Length - 1) / 2;
                return nums[index];
            }

            var even = nums.Length / 2;
            var odd = even - 1;

            return ((double)nums[even] / 2) + ((double)nums[odd] / 2);
        }

    }
}
