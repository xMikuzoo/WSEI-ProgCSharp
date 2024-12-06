namespace CR_Czas24h__properties_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Test 2
            var t = new Czas24h(2, 15, 37);
            t.Minuta = 20;
            t.Godzina = 24;
            Console.WriteLine(t);
        }
    }
}
