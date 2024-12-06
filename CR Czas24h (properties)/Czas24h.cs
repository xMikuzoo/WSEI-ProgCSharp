using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR_Czas24h__properties_
{
    public class Czas24h
    {
        private int liczbaSekund;

        public int Sekunda
        {
            get => liczbaSekund - Godzina * 60 * 60 - Minuta * 60;
            // uzupełnij kod - zdefiniuj setters'a
            set 
            {
                ValidateParameters(Tuple.Create(value, 59));
                liczbaSekund = liczbaSekund - Sekunda + value;
            }
        }

        public int Minuta
        {
            get => (liczbaSekund / 60) % 60;
            // uzupełnij kod - zdefiniuj setters'a
            set
            {
                ValidateParameters(Tuple.Create(value, 59));
                liczbaSekund = liczbaSekund - (Minuta * 60) + (value * 60);
            }
        }

        public int Godzina
        {
            get => liczbaSekund / 3600;
            // uzupełnij kod - zdefiniuj setters'a
            set
            {
                ValidateParameters(Tuple.Create(value, 23));
                liczbaSekund = liczbaSekund - (Godzina * 3600) + (value * 3600);
            }
        }

        public Czas24h(int godzina, int minuta, int sekunda)
        {
            // uzupełnij kod zgłaszając wyjątek ArgumentException
            // w sytuacji niepoprawnych danych
            ValidateParameters(Tuple.Create(minuta, 59), Tuple.Create(sekunda, 59), Tuple.Create(godzina, 23));

            liczbaSekund = sekunda + 60 * minuta + 3600 * godzina;
        }

        public override string ToString() => $"{Godzina}:{Minuta:D2}:{Sekunda:D2}";

        public void ValidateParameters(params Tuple<int, int>[] parameters)
        {
            foreach (var parameter in parameters)
            {
                int value = parameter.Item1;
                int max = parameter.Item2;

                if (!IsValid(value, max))
                {
                    throw new ArgumentException();
                }
            }
        }
        private  bool IsValid(int value, int range)
        {
            if (value < 0 || value > range)
            {
                return false ;
            }
            return true;
        }
    }
}
