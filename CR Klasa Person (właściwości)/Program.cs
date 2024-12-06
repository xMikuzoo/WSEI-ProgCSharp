using System;

namespace CR_Klasa_Person__właściwości_
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /* Test: FamilyName, spacje przed i po nazwisku powinny być usunięte */
            Person p5 = new Person("  Aaa  ", "Bbb", new DateTime(2000, 1, 1));
            Console.WriteLine(p5.FamilyName);
        }
    }
}
