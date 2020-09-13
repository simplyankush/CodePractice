using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures
{
    public class NextClosestTime681
    {
        public NextClosestTime681()
        {
        }

        public static string NextClosestTime(string time)
        {

            var combinations = Combinations(time);
            var closestTime = "";
            var closestInterval = 1441;

            var timeAsMinutes = Minutes(time);

            foreach (var combination in combinations)
            {
                var minutes = Minutes(combination);
                if (IsValid(combination))
                {
                    Console.WriteLine(combination);
                    var difference = minutes - timeAsMinutes;
                    difference = difference <= 0 ? difference + 1440 : difference;
                    if (difference > 0 && difference < closestInterval)
                    {
                        closestInterval = difference;
                        closestTime = combination;
                    }
                }
            }

            return closestTime;
        }

        public static List<string> Combinations(string time)
        {
            HashSet<string> results = new HashSet<string>();

            var digits = time.Where(c => c != ':').ToList();

            foreach (var digitOne in digits)
            {
                foreach (var digitTwo in digits)
                {
                    foreach (var digitThree in digits)
                    {
                        foreach (var digitFour in digits)
                        {
                            results.Add(string.Format("{0}{1}:{2}{3}", digitOne, digitTwo, digitThree, digitFour));
                        }
                    }
                }
            }

            return results.ToList();

        }

        public static int Minutes(string time)
        {
            var hourString = time.Substring(0, 2);
            var hours = Int32.Parse(hourString);
            var minString = time.Substring(3, 2);
            var minutes = Int32.Parse(minString) + (hours * 60);

            return minutes;
        }

        public static bool IsValid(string time)
        {
            var hourString = time.Substring(0, 2);
            var hours = Int32.Parse(hourString);
            var minString = time.Substring(3, 2);
            var minutes = Int32.Parse(minString);

            return hours >= 0 && hours <= 23 && minutes >= 0 && minutes < 60;
        }
    }
}
