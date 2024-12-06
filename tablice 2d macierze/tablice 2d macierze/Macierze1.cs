using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tablice_2d_macierze
{
    public static class Macierze1
    {
        public static void PrintTransposedMatrix(string[] args)
        {
            var matrixSize = Console.ReadLine().Split();
            var m = int.Parse(matrixSize[0]);
            var n = int.Parse(matrixSize[1]);

            var rows = new string[m];
            for (int i = 0; i < m; i++)
            {
                rows[i] = Console.ReadLine();
            }

            var matrix = new int[m, n];

            for (int i = 0; i < m; i++)
            {
                var row = rows[i].Split();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = int.Parse(row[j]);
                }
            }

            var transposedMatrix = new int[n, m];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    transposedMatrix[j, i] = matrix[i, j];
                }
                Console.WriteLine();
            }


            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{transposedMatrix[i, j]} ");
                }
                Console.WriteLine();
            }

        }
    }
}
