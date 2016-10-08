using System;
using CourseworkOneMetro.Models.EmptyStringValidation;

namespace CourseworkOneMetro.Models
{
    public class Instutution
    {
        public string InstitutionTitle { get; set; }

        public string InstitutionAddress { get; set; }

        public string ValidateInstitutionTitle()
        {
            return ValidationUtilities.ValidateNonEmpty("InstitutionTitle", this.InstitutionTitle);
        }

        public string ValidateInstitutionAddress()
        {
            return ValidationUtilities.ValidateNonEmpty("InstitutionAddress", this.InstitutionAddress);
        }

    }
}