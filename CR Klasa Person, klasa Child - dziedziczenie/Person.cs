using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR_Klasa_Person__klasa_Child___dziedziczenie
{
    public class Person
    {
        private string firstName;
        private string familyName;
        private int age;
        public Person(string firstName, string familyName, int age)
        {
            if (age < 0) {
                throw new ArgumentException("Age must be positive!");
            }

            this.firstName = PrepareName(firstName);
            this.familyName = PrepareName(familyName);
            this.age = age;
        }

        public string FirstName { get { return this.firstName; } protected set { this.firstName = PrepareName(value); } }
        public string FamilyName { get { return this.familyName; } protected set { this.familyName = PrepareName(value); } }
        public int Age { get { return this.age; } protected set {this.age = value; } }
        private string PrepareName(string name)
        {
            name = name.Replace(" ","");
            if(!name.All(char.IsLetter) || string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Wrong name!");
            }

            name = name.ToLower();
            name = char.ToUpper(name[0]) + name.Substring(1);

            return name;
        }

        public override string ToString()
        {
            return $"{FirstName} {FamilyName} ({Age})";
        }

        public void modifyFirstName(string value)
        {
            this.firstName = PrepareName(value);
        }

        public void modifyFamilyName(string value)
        {
            this.familyName = PrepareName(value);
        }

        public virtual void modifyAge(int value)
        {
            this.age= value;
        }
    }
}
