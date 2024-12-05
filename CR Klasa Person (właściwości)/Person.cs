using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR_Klasa_Person__właściwości_
{
    public class Person
    {
        private string familyName ;
        private string firstName;
        private DateTime birthday;

        public Person(string familyName, string firstName, DateTime birthday)
        {
            FamilyName = PrepareFamilyName(familyName);
            FirstName = PrepareFirstName(firstName);
            Birthday = ValidateBirthday(birthday);
        }


        public string FamilyName { get; private set; }
        public string FirstName { get; private set; }
        public DateTime Birthday { get; private set; }

        private static string ValidateAndFormatName(string name, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"Incorrect data for {fieldName}");

            name = name.Trim();
            if (!IsValidName(name))
                throw new ArgumentException($"Incorrect data for {fieldName}");

            return name;
        }

        private static string PrepareFamilyName(string familyName)
        {
            if (familyName.Contains("-"))
            {
                var parts = familyName.Split('-');
                if (parts.Length != 2)
                    throw new ArgumentException("Incorrect data for FamilyName");

                return string.Join("-", parts.Select(part => ValidateAndFormatName(part, "FamilyName")));
            }

            return ValidateAndFormatName(familyName, "FamilyName");
        }

        private static string PrepareFirstName(string firstName)
        {
            return ValidateAndFormatName(firstName, "FirstName");
        }

        private static bool IsValidName(string str)
        {
            if (!str.All(char.IsLetter) ||
                 str.Length < 2 ||
                 !char.IsUpper(str[0]) ||
                 !str.Substring(1).All(char.IsLower))
            {
                return false;
            }
            return true;
        }

        private static DateTime ValidateBirthday(DateTime birthday)
        {
            if (birthday > DateTime.Now)
            {
                throw new ArgumentException("Incorrect data for Birthday");
            }
            return birthday;
        }

        public override string ToString()
        {
            return $"{FirstName} {FamilyName} ({Birthday:yyyy-MM-dd})";
        }

    }
}
