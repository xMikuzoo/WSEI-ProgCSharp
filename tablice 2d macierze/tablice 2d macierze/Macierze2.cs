namespace tablice_2d_macierze
{
    public static class Macierze2
    {
        public static void PrintMultipliedMatrixes(string[] args)
        {
            var matrix1Size = Console.ReadLine().Split();
            var m1 = int.Parse(matrix1Size[0]);
            var n1 = int.Parse(matrix1Size[1]);
            var matrix1 = new int[m1, n1];

            var rows1 = Console.ReadLine().Split();
            var index1 = 0;
            for (int i = 0; i < m1; i++)
            {
                for (int j = 0; j < n1; j++)
                {
                    matrix1[i, j] = int.Parse(rows1[index1++]);
                }
            }

            var matrix2Size = Console.ReadLine().Split();
            var m2 = int.Parse(matrix2Size[0]);
            var n2 = int.Parse(matrix2Size[1]);

            if(n1 != m2)
            {
                Console.WriteLine("impossible");
                return;
            }

            var matrix2 = new int[m2, n2];

            var rows2 = Console.ReadLine().Split();
            var index2 = 0;
            for (int i = 0; i < m2; i++)
            {
                
                for (int j = 0; j < n2; j++)
                {
                    matrix2[i, j] = int.Parse(rows2[index2++]);
                }
            }

            var mulitipliedMatrix = new int[m1, n2];
            for (int i = 0; i < m1; i++)
            {
                for (int j = 0; j < n2; j++)
                {
                    for (int k = 0; k < n1; k++)
                    {
                        mulitipliedMatrix[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }

            Console.WriteLine("wynik mnozenia maciery");
            for (int i = 0; i < m1; i++)
            {
                for (int j = 0; j < n2; j++)
                {
                    Console.Write($"{mulitipliedMatrix[i, j]} ");
                }
                Console.WriteLine();
            }
            }
    }
}
