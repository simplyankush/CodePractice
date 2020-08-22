using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    class BrickWall554
    {
        public static  int LeastBricks(IList<IList<int>> wall)
        {
            if (wall == null || wall.Count == 0)
            {
                return 0;
            }

            Dictionary<int, int> edgeCounts = new Dictionary<int, int>();
            int boundary = 0;
            foreach (var row in wall)
            {
                boundary = 0;

                foreach (var brick in row)
                {
                    boundary = boundary + brick;

                    if (edgeCounts.ContainsKey(boundary))
                    {
                        edgeCounts[boundary]++;
                    }
                    else
                    {
                        edgeCounts[boundary] = 1;
                    }
                }
            }

            edgeCounts.Remove(boundary);


            var result = wall.Count;

            foreach (var edgeBoundary in edgeCounts.Keys)
            {
                var cuts = result - edgeCounts[edgeBoundary];

                if (cuts < result)
                {
                    result = cuts;
                }
            }

            return result;


        }

        internal static int LeastBricks(List<List<int>> wall)
        {
            if (wall == null || wall.Count == 0)
            {
                return 0;
            }

            Dictionary<int, int> edgeCounts = new Dictionary<int, int>();
            int boundary = 0;
            foreach (var row in wall)
            {
                boundary = 0;

                foreach (var brick in row)
                {
                    boundary = boundary + brick;

                    if (edgeCounts.ContainsKey(boundary))
                    {
                        edgeCounts[boundary]++;
                    }
                    else
                    {
                        edgeCounts[boundary] = 1;
                    }
                }
            }

            edgeCounts.Remove(boundary);


            var max = wall.Count;
            var result = max;
            foreach (var edgeBoundary in edgeCounts.Keys)
            {
                var cuts = max - edgeCounts[edgeBoundary];

                if (cuts < result)
                {
                    result = cuts;
                }
            }

            return result;

        }
    }
}
