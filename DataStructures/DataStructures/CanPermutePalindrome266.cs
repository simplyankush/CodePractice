using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    class CanPermutePalindrome266
    {
        public bool CanPermutePalindrome(string s)
        {
            Dictionary<char, int> charCounts = BuildCharCounts(s);

            /// palindrome can have at max one char with odd count
            var oddCharCounts = 0;
            foreach (var count in charCounts.Values)
            {
                if (count % 2 == 1)
                {
                    oddCharCounts++;
                }

                if (oddCharCounts > 1)
                {
                    return false;
                }

            }

            return true;
        }

        private Dictionary<char, int> BuildCharCounts(string input)
        {
            var charCounts = new Dictionary<char, int>();
            foreach (var c in input)
            {
                if (charCounts.ContainsKey(c))
                {
                    charCounts[c]++;
                }
                else
                {
                    charCounts[c] = 1;
                }
            }

            return charCounts;
        }
    }
}
