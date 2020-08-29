using System;
using System.Collections.Generic;

namespace DataStructures
{
    /**
     * Given a collection of intervals, merge all overlapping intervals.
     * 
     * Input: intervals = [[1,3],[2,6],[8,10],[15,18]]
      Output: [[1,6],[8,10],[15,18]]
      Explanation: Since intervals [1,3] and [2,6] overlaps, merge them into [1,6].
     * 
     * Sort the intervals in order of Start times.
     * now only consecutive intervals with overlap
     * two consecutive intervals overlap only if the start time of the second is before the end time of the first
     *  
     * Push the first interval onto the stack
     * for each interval from 1: n
     *    check stack.peek() 
     *    
     *    if stack.Peek().End > interval[i].Start
     *        var prev = stack.Pop()
     *        merge(prev, interval[i])
     *    
     *    else
     *        stack.Push(interval)
     *   
     * 
     **/


    public class MergeIntervals56
    {
        public MergeIntervals56()
        {
        }
        public int[][] Merge(int[][] intervals)
        {
            if (intervals == null || intervals.Length < 2)
            {
                return intervals;
            }

            Sort(intervals, 0);

            var mergedIntervals = new Stack<int[]>();

            for (int i = 0; i < intervals.Length; i++)
            {
                if (mergedIntervals.Count == 0)
                {
                    mergedIntervals.Push(intervals[i]);
                }
                else
                {
                    var prev = mergedIntervals.Peek();
                    var curr = intervals[i];
                    if (prev[1] >= curr[0])
                    {
                        mergedIntervals.Pop();
                        var start = prev[0];
                        var end = Math.Max(prev[1], curr[1]);


                        var merged = new int[] { start, end };

                        mergedIntervals.Push(merged);
                    }
                    else
                    {
                        mergedIntervals.Push(intervals[i]);
                    }
                }
                // if end of the prev interval is after the start of curr interval

            }

            var result = new List<int[]>();
            while (mergedIntervals.Count > 0)
            {
                result.Add(mergedIntervals.Pop());
            }

            return result.ToArray();
        }

        public static void Sort<T>(T[][] data, int col)
        {
            Comparer<T> comparer = Comparer<T>.Default;
            Array.Sort<T[]>(data, (x, y) => comparer.Compare(x[col], y[col]));
        }
    }
}
