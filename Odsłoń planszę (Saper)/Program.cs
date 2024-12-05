namespace Odsłoń_planszę__Saper_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UncoverTheBoard();
        }

        public static void UncoverTheBoard()
        {
            var minswepperBoardSize = Console.ReadLine().Split();

            var minswepperBoard = new char[int.Parse(minswepperBoardSize[0]), int.Parse(minswepperBoardSize[1])];

            for(int i = 0; i  < minswepperBoard.GetLength(0); i++)
            {
                var rowData = Console.ReadLine();
                for(int j = 0; j < minswepperBoard.GetLength(1); j++)
                {
                    minswepperBoard[i, j] = rowData[j];
                }
            }

            for (int i = 0; i < minswepperBoard.GetLength(0); i++)
            {
                for (int j = 0; j < minswepperBoard.GetLength(1); j++)
                {
                    var currentPosition = minswepperBoard[i, j];
                    var count = 0;
                    if(currentPosition != '*')
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            for (int l = 0; l < 3; l++)
                            {
                                int rowIndex = i + k -1 ;
                                int colIndex = j + l -1 ;

                                if (rowIndex >= 0 && rowIndex < minswepperBoard.GetLength(0) &&
                                    colIndex >= 0 && colIndex < minswepperBoard.GetLength(1))
                                {
                                    var boardCell = minswepperBoard[rowIndex, colIndex];
                                    if (boardCell == '*')
                                    {
                                        count++;
                                    }

                                }
                            }
                        }
                    }
                    if(count != 0)
                    {
                        minswepperBoard[i, j] = Convert.ToChar(count.ToString());
                    }
                }
            }


            for (int i = 0; i < minswepperBoard.GetLength(0); i++)
            {
                for (int j = 0; j < minswepperBoard.GetLength(1); j++)
                {
                    Console.Write($"{minswepperBoard[i, j]}");
                }
                Console.WriteLine();
            }

        }
    }
}
