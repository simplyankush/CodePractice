using System;
namespace DataStructures
{
    public class RotateImage48
    {
        public RotateImage48()
        {
        }
        public void Rotate(int[][] matrix)
        {
            /**
            *Transpose the matrix
            *Reverse every row
            */

            for (int i = 0; i < matrix.Length; i++)
            {

                for (int j = i; j < matrix[i].Length; j++)
                {
                    Swap(matrix, i, j);
                }
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                Reverse(matrix, i);
            }
        }



        public void Swap(int[][] matrix, int row, int col)
        {
            if (row == col || row < 0 || row >= matrix.Length || col < 0 || col >= matrix.Length)
            {
                return;
            }

            var temp = matrix[row][col];
            matrix[row][col] = matrix[col][row];
            matrix[col][row] = temp;
        }

        public void Reverse(int[][] matrix, int row)
        {
            if (row >= matrix.Length || row < 0)
            {
                return;
            }

            int i = 0;
            int j = matrix[row].Length - 1;

            while (j > i)
            {
                var temp = matrix[row][i];
                matrix[row][i] = matrix[row][j];
                matrix[row][j] = temp;
                j--;
                i++;
            }

        }
    }
}
