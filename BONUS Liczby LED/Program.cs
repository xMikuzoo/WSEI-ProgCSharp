using System.Text;

namespace BONUS_Liczby_LED
{
    internal class Program
    {
        private static string BuildLedOne()
        {
            var builder = new StringBuilder();
            builder.AppendLine("   ");
            builder.AppendLine("  |");
            builder.AppendLine("  |");

            return builder.ToString();
        }

        private static string BuildLedTwo()
        {
            var builder = new StringBuilder();
            builder.AppendLine(" _ ");
            builder.AppendLine(" _|");
            builder.AppendLine("|_ ");

            return builder.ToString();
        }

        private static string BuildLedThree()
        {
            var builder = new StringBuilder();
            builder.AppendLine(" _ ");
            builder.AppendLine(" _|");
            builder.AppendLine(" _| ");

            return builder.ToString();
        }

        private static string BuildLedFour()
        {
            var builder = new StringBuilder();
            builder.AppendLine("   ");
            builder.AppendLine("|_|");
            builder.AppendLine("  |");

            return builder.ToString();
        }

        private static string BuildLedFive()
        {
            var builder = new StringBuilder();
            builder.AppendLine(" _ ");
            builder.AppendLine("|_ ");
            builder.AppendLine(" _|");

            return builder.ToString();
        }

        private static string BuildLedSix()
        {
            var builder = new StringBuilder();
            builder.AppendLine(" _ ");
            builder.AppendLine("|_ ");
            builder.AppendLine("|_|");

            return builder.ToString();
        }

        private static string BuildLedSeven()
        {
            var builder = new StringBuilder();
            builder.AppendLine(" _ ");
            builder.AppendLine("  |");
            builder.AppendLine("  |");

            return builder.ToString();
        }

        private static string BuildLedEight()
        {
            var builder = new StringBuilder();
            builder.AppendLine(" _ ");
            builder.AppendLine("|_|");
            builder.AppendLine("|_|");

            return builder.ToString();
        }

        private static string BuildLedNine()
        {
            var builder = new StringBuilder();
            builder.AppendLine(" _ ");
            builder.AppendLine("|_|");
            builder.AppendLine("  |");

            return builder.ToString();
        }

        private static string BuildLedZero()
        {
            var builder = new StringBuilder();
            builder.AppendLine(" _ ");
            builder.AppendLine("| |");
            builder.AppendLine("|_|");

            return builder.ToString();
        }
        private static Dictionary<int,string> ledDigitDictionary = new Dictionary<int,string>
            {
                {0, BuildLedZero()},
                {1, BuildLedOne()},
                {2, BuildLedTwo()},
                {3, BuildLedThree()},
                {4, BuildLedFour()},
                {5, BuildLedFive()},
                {6, BuildLedSix()},
                {7, BuildLedSeven()},
                {8, BuildLedEight()},
                {9, BuildLedNine()},
            };

        static void Main(string[] args)
        {
            PrintLedDigits();
        }
        public static void PrintLedDigits()
        {
            var input = Console.ReadLine();
            var digits = input.Select(x => int.Parse(x.ToString())).ToList();

            var ledDigits = digits.Select(x => ledDigitDictionary[x]).ToList();

            var numbersRows = new List<List<string>>();

            foreach (var ledDigit in ledDigits)
            {
                var ledDigitRows = ledDigit.Split('\n');
                var numberRows = new List<string>();

                foreach(var ledDigitRow in ledDigitRows)
                {
                    if(!string.IsNullOrEmpty(ledDigitRow))
                    {
                        string ledDigitRowData = "";
                        for (int i = 0; i < 3; i++)
                        {
                            ledDigitRowData += ledDigitRow[i];
                        }
                        numberRows.Add(ledDigitRowData);
                    }
                }
                numbersRows.Add(numberRows);
            }

            string firstRow = "";
            string secondRow = "";
            string thirdRow = "";

            foreach (var numberRow in numbersRows)
            {
                for(int i = 0; i < numberRow.Count(); i++)
                {
                    if(i == 0)
                    {
                        firstRow += numberRow[i];
                    }
                    if (i == 1)
                    {
                        secondRow += numberRow[i];
                    }
                    if (i == 2)
                    {
                        thirdRow += numberRow[i];
                    }
                }
            }

            Console.WriteLine(firstRow);
            Console.WriteLine(secondRow);
            Console.WriteLine(thirdRow);
        }
    }
}
