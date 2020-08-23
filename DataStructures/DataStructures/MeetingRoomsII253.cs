using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    class MeetingRoomsII253
    {
        public int MinMeetingRooms(int[][] intervals)
        {
            if (intervals == null || intervals.Length == 0)
            {
                return 0;
            }

            Sort(intervals, 0);
            var endTimes = new int[intervals.Length];
            for (int i = 0; i < intervals.Length; i++)
            {
                endTimes[i] = intervals[i][1];
            }

            var minHeap = new MinHeap(intervals.Length);
            minHeap.Insert(intervals[0][1]);
            var rooms = 0;
            var maxrooms = rooms;
            for (int i = 1; i < intervals.Length; i++)
            {
                if (!minHeap.IsEmpty() && minHeap.Peek() <= intervals[i][0])
                {
                    minHeap.Pop();
                }

                minHeap.Insert(intervals[i][1]);
            }

            return minHeap.Size();
        }

        private static void Sort<T>(T[][] data, int col)
        {
            Comparer<T> comparer = Comparer<T>.Default;
            Array.Sort<T[]>(data, (x, y) => comparer.Compare(x[col], y[col]));
        }
    }
}
