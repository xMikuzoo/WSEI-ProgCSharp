using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprawdz_sudoku
{
    internal class Program
    {
        static void Main(string[] args)
        {
            checkSudoku( 
                new int[9, 9]
                {
                    { 2, 5, 1, 7, 6, 9, 3, 4, 8},
                    { 9, 8, 6, 3, 4, 5, 2, 7, 1},
                    { 3, 7, 4, 8, 2, 1, 6, 9, 5},
                    { 4, 2, 9, 6, 3, 8, 5, 1, 7},
                    { 8, 6, 3, 5, 1, 7, 9, 2, 4},
                    { 5, 1, 7, 4, 9, 2, 8, 3, 6},
                    { 7, 9, 5, 1, 8, 3, 4, 6, 2},
                    { 1, 4, 2, 9, 5, 6, 7, 8, 3},
                    { 6, 3, 8, 2, 7, 4, 1, 5, 9}
                });

            //checkSudoku(
            //    new int[9, 9]
            //    {
            //        { 2, 5, 1, 7, 6, 9, 3, 4, 8},
            //        { 9, 8, 6, 3, 4, 5, 2, 7, 1},
            //        { 3, 7, 4, 8, 2, 1, 6, 9, 5},
            //        { 4, 2, 9, 6, 3, 8, 5, 1, 7},
            //        { 8, 6, 3, 5, 1, 7, 9, 2, 4},
            //        { 5, 1, 7, 4, 9, 2, 8, 3, 6},
            //        { 7, 9, 5, 1, 8, 3, 4, 6, 2},
            //        { 1, 4, 2, 9, 5, 6, 7, 8, 3},
            //        { 6, 3, 8, 2, 7, 4, 1, 9, 5}
            //    });
        }
        public static bool checkSudoku(int[,] sudoku)
        {

            return true;
        }
    }
}
