using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Warsztat_Rabat_na_loty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Zadanie1();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }

        public static void Zadanie1()
        {
            //zebranie danych
            Console.Write("Podaj swoją datę urodzenia w formacie RRRR-MM-DD: ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            var today = DateTime.Today;

            var passengerAge = today.Year - birthDate.Year;
            if (birthDate > today.AddYears(-passengerAge))
            {
                passengerAge--;
            }

            Console.Write("Podaj datę lotu w formacie RRRR-MM-DD: ");
            DateTime flightDate = DateTime.Parse(Console.ReadLine());

            var monthsBeforeFlight = -(((today.Year - flightDate.Year) * 12) + today.Month - flightDate.Month);

            Console.Write("Czy lot jest krajowy (T/N)? ");
            string isDomesticFlightInput = Console.ReadLine().ToLower();
            bool isDomesticFlight = isDomesticFlightInput == "t" ? true : isDomesticFlightInput == "n" ? false : throw new ArgumentException("Podano niepoprawne dane");

            Console.WriteLine("Czy jesteś stałym klientem (T/N)? ");
            string isRegularCustomerInput = Console.ReadLine().ToLower();
            bool isRegularCustomer = isRegularCustomerInput == "t" ? true : isRegularCustomerInput == "n" ? false : throw new ArgumentException("Podano niepoprawne dane");

            bool isFlightInSeason =
                //święto 1
                flightDate.Month >= 12 && flightDate.Month <= 1 && flightDate.Day >= 20 && flightDate.Day <= 10 ||
                //święto 2
                flightDate.Month >= 3 && flightDate.Month <= 4 && flightDate.Day >= 20 && flightDate.Day <= 10 ||
                //wakacje
                flightDate.Month == 6 || flightDate.Month == 7;

            double discount = CalculateTheDiscount(passengerAge, isDomesticFlight, monthsBeforeFlight, isFlightInSeason, isRegularCustomer);

            //wypisanie danych
            var listDataBuilder = new StringBuilder();

            listDataBuilder.AppendLine("=== Do obliczeń przyjęto: ");
            listDataBuilder.AppendLine($" * Data urodzenia: {birthDate:d}");
            listDataBuilder.AppendLine($" * Data lotu: {flightDate:D}.{(isFlightInSeason ? " Lot w sezonie" : string.Empty)}");
            if(isDomesticFlight)
            {
                listDataBuilder.AppendLine(" * Lot krajowy");
            }
            listDataBuilder.AppendLine($" * Stały klient: {(isRegularCustomer ? "Tak" : "Nie")}");
            listDataBuilder.AppendLine();
            listDataBuilder.AppendLine($"Przysługuje Ci rabat w wysokości: {discount:P0}");

            Console.WriteLine(listDataBuilder.ToString());

        }

        public static double CalculateTheDiscount(int passengerAge, bool isDomesticFlight, int monthsBeforeFlight, bool isFlightInSeason, bool isRegularCustomer)
        {
            if (passengerAge < 2)
            {
                if (isDomesticFlight)
                {
                    return 0.8;
                }
                if (!isDomesticFlight)
                {
                    return 0.7;
                }
            }

            if(passengerAge >=2 && passengerAge <= 16)
            {
                return 0.1;
            }

            return 0;
        }

    }
}
