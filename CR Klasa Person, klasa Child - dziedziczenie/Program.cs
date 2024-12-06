namespace CR_Klasa_Person__klasa_Child___dziedziczenie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Test();
        }

        static void Test() {

            /* Test: tworzenie obiektu Child
               modyfikacja danych */
            try
            {
                Person o = new Person(familyName: "Molenda", firstName: "Krzysztof", age: 30);
                Person m = new Person(familyName: "Molenda", firstName: "Ewa", age: 29);
                Child d = new Child(familyName: "Molenda", firstName: "Anna", age: 14,
                                    mother: m, father: o);
                d.modifyFirstName("Aneta");
                Console.WriteLine(d);
                d.modifyFirstName("Kolenda");
                Console.WriteLine(d);
                d.modifyAge(12);
                Console.WriteLine(d);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
