using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class CriticalConnections1192
    {
        bool[] visited;
        List<List<int>> adjList;
        int[] identifiers;
        int[] lowValues;
        int count = 0;

        public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections)
        {
            visited = new bool[n];
            identifiers = new int[n];
            lowValues = new int[n];

            adjList = new List<List<int>>();
            for (int i = 0; i < n; i++)
            {
                adjList.Add(new List<int>());
            }

            var result = new List<IList<int>>();

            foreach (var conn in connections)
            {
                var a = conn[0];
                var b = conn[1];

                adjList[a].Add(b);
                adjList[b].Add(a);
            }

            dfs(0, -1);

            for (int i = 0; i < n; i++)
            {
                foreach (var neighbor in adjList[i])
                {
                    if (identifiers[i] < lowValues[neighbor])
                    {
                        result.Add(new List<int>() { i, neighbor });
                    }
                }
            }


            return result;

        }

        public void dfs(int current, int previous)
        {
            visited[current] = true;
            identifiers[current] = count;
            lowValues[current] = count;
            count++;

            var neighbors = adjList[current];

            foreach (var n in neighbors)
            {
                if (n == previous)
                {
                    continue;
                }

                if (!visited[n])
                {
                    dfs(n, current);
                }


                lowValues[current] = Math.Min(lowValues[current], lowValues[n]);
            }
        }
    }
}
