using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    class TrappingRainWater42
    {
        public int TrapBruteForce(int[] height)
        {

            // need more than 2 columns to trap water
            if (height == null || height.Length <= 2)
            {
                return 0;
            }

            // every position may have some water above it. 
            // we need to find water at every position and then sum of water at all positions
            int water = 0;

            // we should assume any water that collects at pos[0] or pos[n-1] will flow out left and right respectively, because there is no             // physical boundary at either end

            for (int i = 1; i < height.Length - 1; i++)
            {
                var heightOfWater = 0;

                var left = i - 1;
                var right = i + 1;

                var maxLeft = height[left];
                while (left >= 0)
                {
                    if (height[left] > maxLeft)
                    {
                        maxLeft = height[left];
                    }
                    left--;
                }

                var maxRight = height[right];
                while (right < height.Length)
                {
                    if (height[right] > maxRight)
                    {
                        maxRight = height[right];
                    }
                    right++;
                }

                heightOfWater = Math.Min(maxLeft, maxRight);
                if (heightOfWater > height[i])
                {
                    water = water + (heightOfWater - height[i]);
                }

            }

            return water;
        }

        public int TrapDP(int[] height)
        {
            // need more than 2 columns to trap water
            if (height == null || height.Length <= 2)
            {
                return 0;
            }

            // every position may have some water above it. 
            // we need to find water at every position and then sum of water at all positions
            int water = 0;

            var left_max = new int[height.Length];
            var right_max = new int[height.Length];

            left_max[0] = 0;
            right_max[right_max.Length - 1] = 0;

            for (int i = 1; i < left_max.Length; i++)
            {
                // the max element to the left is the Maximum of the previous element and the (max of the elements to the left of the prev element)
                var maxLeft = Math.Max(left_max[i - 1], height[i - 1]);
                left_max[i] = maxLeft;
            }


            for (int i = right_max.Length - 2; i >= 0; i--)
            {
                var maxRight = Math.Max(right_max[i + 1], height[i + 1]);
                right_max[i] = maxRight;
            }

            // iterate from index 1 to n-2, i.e second to last but one
            for (int i = 1; i < height.Length - 1; i++)
            {
                var left = left_max[i];
                var right = right_max[i];

                var heightOfWater = Math.Min(left, right);

                if (heightOfWater > height[i])
                {
                    water = water + heightOfWater - height[i];
                }
            }

            return water;
        }
    }
}
