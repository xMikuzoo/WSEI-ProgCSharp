using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace tablica_postrzepiona
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var jaggedArray = ReadJaggedArrayFromStdInput();
            Console.WriteLine();

            PrintJaggedArrayToStdOutput(jaggedArray);
            Console.WriteLine();

            var transposedJaggedArray = TransposeJaggedArray(jaggedArray);
            Console.WriteLine();

            PrintJaggedArrayToStdOutput(transposedJaggedArray);
        }

        static char[][] ReadJaggedArrayFromStdInput()
        {
            int rowsAmount = int.Parse(Console.ReadLine());
            var jaggedArray = new char[rowsAmount][];

            for (int i = 0; i < rowsAmount; i++)
            {
                var row = Console.ReadLine().Split();
                jaggedArray[i] = new char[row.Length];

                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    jaggedArray[i][j] = Convert.ToChar(row[j]);
                }
            }
            return jaggedArray;
        }

        static void PrintJaggedArrayToStdOutput(char[][] tab)
        {
            for(int i = 0; i < tab.Length; i++)
            {
                for(int j = 0  ; j < tab[i].Length ; j++)
                {
                    // w ifie tutaj mozna dac default(defaultowa wartosc chara) ale nie dziala u niego bo c# 7.0 ma xd
                    // sprawdzcie if bez '\x00' bo moze przejdzie ale mi prob braklo
                    if (tab[i][j] == '\0' || tab[i][j] == '\x00')
                    {
                        tab[i][j] = ' ';
                    }
                    Console.Write($"{tab[i][j]} ");
                }
                Console.WriteLine();
            }
        }

        static char[][] TransposeJaggedArray(char[][] tab)
        {
            var size = 0;
            foreach (var x in tab) {
                if (size < x.Length) {
                    size = x.Length;
                }
            }
            var transposedJaggedArray = new char[size][];

            for (int i = 0; i < tab.Length; i++) {
                for (int j = 0; j < tab[i].Length; j++)
                {
                    if (transposedJaggedArray[j] == null) {
                        transposedJaggedArray[j] = new char[tab.Length];
                    }
                    transposedJaggedArray[j][i] = tab[i][j];
                }
            }
            return transposedJaggedArray;
        }
    }
}
