using System;
using CourseworkOneMetro.Models.EmptyStringValidation;

namespace CourseworkOneMetro.Models
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public string ValidateName()
        {
            return ValidationUtilities.ValidateNonEmpty("Name", this.Name);
        }

        public string ValidateSurname()
        {
            return ValidationUtilities.ValidateNonEmpty("Surname", this.Surname);
        }
    }
}