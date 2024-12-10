using System.Text;

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
                Console.WriteLine("Coś poszło nie tak :/");
                Console.WriteLine(e.Message);
                Console.WriteLine("Zacznijmy jeszcze raz");
                Zadanie1 ();
            }
        }
        public static void Zadanie1()
        {
            //zebranie danych
            DateTime birthDate = ReadBirthDate();
            DateTime flightDate = ReadFlightDate();
            bool isDomesticFlight = ReadTrueFalse("Czy lot jest krajowy");
            bool isRegularCustomer = ReadTrueFalse("Czy jesteś stałym klientem");

            //przygotowanie danych
            bool isFlightInSeason =
                flightDate.Month >= 12 && flightDate.Month <= 1 && flightDate.Day >= 20 && flightDate.Day <= 10 ||
                flightDate.Month >= 3 && flightDate.Month <= 4 && flightDate.Day >= 20 && flightDate.Day <= 10 ||
                flightDate.Month == 6 || flightDate.Month == 7;

            var today = DateTime.Today;

            var passengerAge = today.Year - birthDate.Year;
            if (birthDate > today.AddYears(-passengerAge))
            {
                passengerAge--;
            }

            var monthsBeforeFlight = -(((today.Year - flightDate.Year) * 12) + today.Month - flightDate.Month);

            double discount = CalculateTheDiscount(passengerAge, isDomesticFlight, monthsBeforeFlight, isFlightInSeason, isRegularCustomer);

            //wypisanie danych
            var listDataBuilder = new StringBuilder();

            listDataBuilder.AppendLine();
            listDataBuilder.AppendLine("=== Do obliczeń przyjęto: ");
            listDataBuilder.AppendLine($" * Data urodzenia: {birthDate:d}");
            listDataBuilder.AppendLine($" * Data lotu: {flightDate:D}.{(isFlightInSeason ? " Lot w sezonie" : string.Empty)}");
            if(isDomesticFlight)
            {
                listDataBuilder.AppendLine(" * Lot krajowy");
            }
            listDataBuilder.AppendLine($" * Stały klient: {(isRegularCustomer ? "Tak" : "Nie")}");
            listDataBuilder.AppendLine();
            listDataBuilder.AppendLine($"Przysługuje Ci rabat w wysokości: {discount:P}");
            listDataBuilder.AppendLine($"Data wygenerowania raportu: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");

            Console.WriteLine(listDataBuilder.ToString());
        }

        public static DateTime ReadBirthDate()
        {
            while (true)
            {
                Console.Write("Podaj swoją datę urodzenia w formacie RRRR-MM-DD: ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime birthDate))
                {
                    return birthDate;
                }
                Console.WriteLine("Niepoprawny format daty. Spróbuj ponownie.");
            }
        }
        public static DateTime ReadFlightDate()
        {
            while (true)
            {
                Console.Write("Podaj datę lotu w formacie RRRR-MM-DD: ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime flightDate))
                {
                    return flightDate;
                }
                Console.WriteLine("Niepoprawny format daty. Spróbuj ponownie.");
            }
        }
        public static bool ReadTrueFalse(string message)
        {
            while (true)
            {
                Console.Write($"{message} (T/N)? ");
                string input = Console.ReadLine().ToLower();
                if (input == "t" || input == "n")
                {
                    return input == "t" ? true : false;
                }
                Console.WriteLine("Podano niepoprawne dane");
            }
        }
        public static double CalculateTheDiscount(int passengerAge, bool isDomesticFlight, int monthsBeforeFlight, bool isFlightInSeason, bool isRegularCustomer)
        {
            double discount = 0;

            if(!isDomesticFlight && (passengerAge > 2 || isFlightInSeason))
            {
                return 0;
            }

            if (monthsBeforeFlight >= 5)
            {
                discount += 0.1;
            }

            if (!isDomesticFlight && !isFlightInSeason)
            {
                discount += 0.15;
            }

            if (passengerAge >= 18 && isRegularCustomer)
            {
                discount += 0.15;
            }

            if (passengerAge < 2)
            {
                if (isDomesticFlight)
                {
                    discount += 0.8;
                }
                else 
                {
                    discount += 0.7;
                }

                return discount >= 0.8 ? 0.8 : discount;
            }

            if(passengerAge >= 2 && passengerAge <= 16)
            {
                discount += 0.1;
            }
            
            return discount >= 0.3 ? 0.3 : discount;
        }
    }
}