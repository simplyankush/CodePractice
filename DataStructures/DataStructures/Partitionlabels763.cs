using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures
{

    /**
     *A string S of lowercase English letters is given.
     *We want to partition this string into as many parts as possible so that each letter appears in at most one part,
     *and return a list of integers representing the size of these parts. 
     * 
     * Take one pass of the string and create a Dictionary of char : indexesOfEachChar call it charIndexes
     * Now for splitting into partitions
     *
     *Find the first character S[0] and the lastIndex of this character
     * let firstIndex = 0
     * iterate i from firstIndex till lastIndex.
     * if charIndexes[s[i]]>.Last() > lastindex, then lastIndexes = charIndexes[s[i]]>.Last()
     *
     *once i > lastindex, we have our partition ready at index i
     *
     *now firstIndex = i;
     *
     * Repeat above steps until we reach end of String 
     *
     * 
     */


    class Partitionlabels763
    {
        public IList<int> PartitionLabels(string S)
        {
            var charIndexes = new Dictionary<char, List<int>>();

            for (int i = 0; i < S.Length; i++)
            {
                var c = S[i];
                if (charIndexes.ContainsKey(c))
                {
                    var l = charIndexes[c];
                    l.Add(i);
                }
                else
                {
                    charIndexes[c] = new List<int>() { i };
                }
            }


            int index = 0;
            var partitions = new List<int>();
            int first = 0;
            while (index < S.Length)
            {
                var lastIndex = charIndexes[S[first]].Last();
                var tempIndex = first;

                while (tempIndex <= lastIndex)
                {
                    lastIndex = Math.Max(lastIndex, charIndexes[S[tempIndex]].Last());
                    tempIndex++;
                }

                partitions.Add(tempIndex - first);

                first = tempIndex;
                index = tempIndex;

            }

            return partitions;
        }
}
