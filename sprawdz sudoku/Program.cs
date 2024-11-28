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
            //ogolnie to petle do sprawdzania blokow podjebalem ze stacka
            //
            //hashset mi czacik pokazal i to dziala tak ze pozwala na dodanie tylko unikalnych
            //i jak bedziez chcial dodac cos co juz istnieje to ci zwroci false
            CheckSudoku(args);
        }
        public static void CheckSudoku(string[] args)
        {
            var sudoku = new int[9, 9];

            //sprawdza unikalnosc i czy sa od 1-9 w rzedach i kolumnach
            for (int blockRow = 0; blockRow < 3; blockRow++)
            {
                for (int blockCol = 0; blockCol < 3; blockCol++)
                {
                    var sum = 0;
                    var blockSet = new HashSet<int>();

                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            var cellValue = sudoku[blockRow * 3 + i, blockCol * 3 + j];

                            if (!blockSet.Add(cellValue))
                            {
                                Console.WriteLine("no");
                                return;
                            }

                            sum += cellValue;
                        }
                    }
                    if (sum != 45)
                    {
                        Console.WriteLine("no");
                        return;
                    }
                }
            }

            //sprawdza unikalnosc i czy sa od 1-9 w blokach 3x3
            for (int i = 0; i < sudoku.GetLength(0); i++)
            {
                var rowSet = new HashSet<int>();
                var colSet = new HashSet<int>();
                int rowSum = 0, colSum = 0;

                for (int j = 0; j < sudoku.GetLength(1); j++)
                {
                    if (!rowSet.Add(sudoku[i, j]) || !colSet.Add(sudoku[j, i]))
                    {
                        Console.WriteLine("no");
                        return;
                    }

                    rowSum += sudoku[i, j];
                    colSum += sudoku[j, i];
                }

                if (rowSum != 45 || colSum != 45)
                {
                    Console.WriteLine("no");
                    return;
                }
            }

            Console.WriteLine("yes");
        }
    }
}
