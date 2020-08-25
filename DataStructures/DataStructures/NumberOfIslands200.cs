﻿using System;
namespace DataStructures
{
    public class NumberOfIslands200
    {
        public NumberOfIslands200()
        {
        }

        /**
         * 
         * Given a 2d grid map of '1's (land) and '0's (water), count the number of islands.
         * An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically.
         * You may assume all four edges of the grid are all surrounded by water.
         * Input: grid = [
  ["1","1","1","1","0"],
  ["1","1","0","1","0"],
  ["1","1","0","0","0"],
  ["0","0","0","0","0"]
]
Output: 1
         * 
         **/

        public static int NumIslands(char[][] grid)
        {
            if (grid == null || grid.Length == 0)
            {
                return 0;
            }

            int count = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        count++;
                        FindIslandBoundary(grid, i, j);
                    }
                }
            }

            return count;
        }


        public static void FindIslandBoundary(char[][] grid, int row, int col)
        {
            if (row < 0 || col < 0 || row >= grid.Length || col >= grid[0].Length || grid[row][col] != '1')
            {
                return;
            }

            grid[row][col] = '0';

            FindIslandBoundary(grid, row + 1, col);
            FindIslandBoundary(grid, row - 1, col);
            FindIslandBoundary(grid, row, col + 1);
            FindIslandBoundary(grid, row , col - 1);

        }
    }
}
