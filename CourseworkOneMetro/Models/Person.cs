using System;
using CourseworkOneMetro.Models.Utils;

namespace CourseworkOneMetro.Models
{
    /// <summary>
    /// Created by Davide Morello
    /// Last Modified October 
    /// model for the person
    /// </summary>
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        // validates name
        public string ValidateName()
        {
            return ValidationUtilities.ValidateNonEmpty("Name", this.Name);
        }

        // validates surname
        public string ValidateSurname()
        {
            return ValidationUtilities.ValidateNonEmpty("Surname", this.Surname);
        }
    }
}