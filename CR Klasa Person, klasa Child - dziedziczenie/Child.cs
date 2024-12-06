using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR_Klasa_Person__klasa_Child___dziedziczenie
{
    public class Child : Person
    {
        private Person mother;
        private Person father;

        public Child(string firstName, string familyName, int age)  : base(firstName, familyName, age)
        {
        }

        public Child(string firstName, string familyName, int age, Person mother = null, Person father = null) : base(firstName, familyName, age)
        {
            if (age > 15)
            {
                throw new ArgumentException("Child’s age must be less than 15!");
            }

            this.mother = mother;
            this.father = father;
        }

        public static Child CreateWithFather(string firstName, string familyName, int age, Person father) {
            return new Child(familyName: "Molenda", firstName: "Anna", age: 14, father: father);
        }

        public static Child CreateWithMother(string firstName, string familyName, int age, Person father)
        {
            return new Child(familyName: "Molenda", firstName: "Anna", age: 14, mother: father);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{FirstName} {FamilyName} ({Age})");
            sb.AppendLine(mother == null ? $"mother: No data" : $"mother: {mother.ToString()}");
            sb.Append(father == null ? $"father: No data" : $"father: {father.ToString()}");

            return sb.ToString();
        }

        public override void modifyAge(int value)
        {
            if (value < 0 | value > 15)
            {
                throw new ArgumentException("Child’s age must be less than 15!");
            }
            this.Age = value;
        }
    }
}
