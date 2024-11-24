using System;
using System.Collections.Generic;


namespace tablice_2d_macierze
{
    public class Macierze3
    {
        public static void PrintColumnIdWithBiggestSum(string[] args)
        {
            var intArraysList = new List<int[]>();
            while (true)
            {
                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) break;

                var inputArray = input.Split();
                var rowData = new int[inputArray.Length];

                for (int i = 0; i < rowData.Length; i++)
                {
                    rowData[i] = int.Parse(inputArray[i]);
                }

                intArraysList.Add(rowData);
            }

            var colsSum = new int[intArraysList[0].Length];

            for (int i = 0; i < intArraysList.Count; i++)
            {
                for (int j = 0; j < intArraysList[i].Length; j++)
                {
                    colsSum[j] += intArraysList[i][j];
                }
            }

            var max = colsSum[0];
            foreach (var value in colsSum)
            {
                if(value > max)
                {
                    max = value;
                }
            }


            Console.WriteLine(Array.IndexOf(colsSum, max));
        }
    }
}
