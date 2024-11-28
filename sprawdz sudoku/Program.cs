using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace sprawdz_sudoku
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CheckSudoku(args);
        }



        public static void CheckSudoku(string[] args)
        {
            var result = "yes";
            var sudoku = new int[9, 9];

            for (int i = 0; i < sudoku.GetLength(0); i++)
            {
                var row = Console.ReadLine().Split(' ');
                for (int j = 0; j < sudoku.GetLength(1);j++)
                {
                    sudoku[i,j] = int.Parse(row[j]);
                }
            }

            for (int i = 0; i < sudoku.GetLength(0); i++)
            {
                for (int j = 0; j < sudoku.GetLength(1); j++)
                {
                    Console.Write($"{sudoku[i,j]} ");
                }
                Console.WriteLine();
            }

            var block1 = new List<int>();
            var block2 = new List<int>();
            var block3 = new List<int>();
            var block4 = new List<int>();
            var block5 = new List<int>();
            var block6 = new List<int>();
            var block7 = new List<int>();
            var block8 = new List<int>();
            var block9 = new List<int>();

            var blocks = new List<List<int>>()
                {
                    block1, block2, block3,
                    block4, block5, block6,
                    block7, block8, block9
                };

            for (int i = 0; i < sudoku.GetLength(0); i++)
            {
                var row = new List<int>();
                var col = new List<int>();

                for (int j = 0; j < sudoku.GetLength(1); j++)
                {
                    //row1
                    if(i < 3 && j < 3)
                    {
                        block1.Add(sudoku[i, j]);
                    }
                    if(i < 3 && j >=3 && j < 6)
                    {
                        block2.Add(sudoku[i, j]);
                    }
                    if (i < 3 && j >= 6)
                    {
                        block3.Add(sudoku[i, j]);
                    }
                    //row2
                    if (i >=3 && i < 6 && j < 3)
                    {
                        block4.Add(sudoku[i, j]);
                    }
                    if (i >=3 && i < 6 && j >= 3 && j < 6)
                    {
                        block5.Add(sudoku[i, j]);
                    }
                    if (i >=3 && i < 6 && j >= 6)
                    {
                        block6.Add(sudoku[i, j]);
                    }
                    //row3
                    if (i >= 6 && j < 3)
                    {
                        block7.Add(sudoku[i, j]);
                    }
                    if (i >= 6 && j >= 3 && j < 6)
                    {
                        block8.Add(sudoku[i, j]);
                    }
                    if (i >= 6 && j >= 6)
                    {
                        block9.Add(sudoku[i, j]);
                    }

                    row.Add(sudoku[i, j]);
                    col.Add(sudoku[j, i]);
                }

                if(row.Sum()!= 45 || col.Sum()!=45)
                {
                    result = "no";
                }
            }

            foreach (var block in blocks)
            {
                if (block.Sum() != 45)
                {
                    result = "no";
                }
            }

            Console.WriteLine(result);
        }
    }
}
