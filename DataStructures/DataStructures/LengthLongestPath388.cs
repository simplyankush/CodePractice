using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures
{
    public class LengthLongestPath388
    {

            public static int LengthLongestPath(string input)
            {

                string prevDirPath = string.Empty;
                Stack<string> stack = new Stack<string>();
                List<string> prevDirs = new List<string>();
                string longestPath = string.Empty;
                foreach (var line in input.Split('\n'))
                {
                    // count the occurences of tab to find the current level
                    int currentLevel = line.Where(x => x == '\t').Count();
                    Console.WriteLine("Current Level: " + currentLevel);
                    Console.WriteLine("prevDirLen:" + prevDirs.Count());

                    var cline = line.Replace("\t", "");

                    // adjust the previous directories to remove directories at higher level than current level
                    while (currentLevel < prevDirs.Count() && prevDirs.Count() > 0)
                    {
                        prevDirs.RemoveAt(prevDirs.Count() - 1);
                    }


                    if (cline.Contains(".") && cline[cline.Length - 1] != '.')
                    {
                        var path = string.Empty;

                        foreach (var dir in prevDirs)
                        {
                            path = string.Format("{0}/{1}", path, dir);
                        }

                        path = string.Format("{0}/{1}", path, cline);

                        if (path.Length > longestPath.Length)
                        {
                            longestPath = path;
                            Console.WriteLine(longestPath);
                        }

                    }
                    else
                    {
                        prevDirs.Add(cline);
                    }
                }

                if (longestPath.Length > 0 && longestPath[0] == '/')
                {
                    longestPath = longestPath.Substring(1);
                }

                return longestPath.Length;

            }
        }
    }
