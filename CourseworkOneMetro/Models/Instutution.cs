using System;
using CourseworkOneMetro.Models.Utils;

namespace CourseworkOneMetro.Models
{
    /// <summary>
    /// model for the institution
    /// </summary>
    public class Instutution
    {
        public string InstitutionTitle { get; set; }

        public string InstitutionAddress { get; set; }

        // validates institution name
        public string ValidateInstitutionTitle()
        {
            return ValidationUtilities.ValidateNonEmpty("InstitutionTitle", this.InstitutionTitle);
        }

        // validates address
        public string ValidateInstitutionAddress()
        {
            return ValidationUtilities.ValidateNonEmpty("InstitutionAddress", this.InstitutionAddress);
        }

    }
}