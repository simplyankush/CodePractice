using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    class MaxProductSubarray152
    {
        public int MaxProduct(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            var max = nums[0];
            var min = nums[0];
            var globalMax = max;

            for (int i = 1; i < nums.Length; i++)
            {
                var tempMin = min * nums[i];
                var tempMax = max * nums[i];

                max = Math.Max(Math.Max(tempMax, tempMin), nums[i]);
                min = Math.Min(Math.Min(tempMin, tempMax), nums[i]);

                if (max > globalMax)
                {
                    globalMax = max;
                }
            }


            return globalMax;
        }
    }
}
