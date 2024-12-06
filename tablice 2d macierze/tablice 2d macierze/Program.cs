namespace tablice_2d_macierze
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zadanie1");
            Macierze1.PrintTransposedMatrix(args);

            Console.WriteLine("Zadanie2");
            Macierze2.PrintMultipliedMatrixes(args);

            Console.WriteLine("Zadanie3");
            Macierze3.PrintColumnIdWithBiggestSum(args);

        }
    }
}
