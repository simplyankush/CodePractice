using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    class HitCounter362
    {
        /**
         * Problem 362
         * Design a hit counter which counts the number of hits received in the past 5 minutes.

           Each function accepts a timestamp parameter(in seconds granularity) and you may assume that calls are being made to the system in chronological order(ie, the timestamp is monotonically increasing). You may assume that the earliest timestamp starts at 1.

           It is possible that several hits arrive roughly at the same time.
        **/

        Queue<int> counter;
        /** Initialize your data structure here. */
        public HitCounter362()
        {
            counter = new Queue<int>();
        }

        /** Record a hit.
            @param timestamp - The current timestamp (in seconds granularity). */
        public void Hit(int timestamp)
        {
            counter.Enqueue(timestamp);
        }

        /** Return the number of hits in the past 5 minutes.
            @param timestamp - The current timestamp (in seconds granularity). */
        public int GetHits(int timestamp)
        {
            while (counter.Count != 0 && (timestamp - counter.Peek() >= 300))
            {
                counter.Dequeue();
            }

            return counter.Count;
        }
    }
}
