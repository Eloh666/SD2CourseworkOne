using System;
using CourseworkOneMetro.Models.Utils;

namespace CourseworkOneMetro.Models
{
    /// <summary>
    /// Created by Davide Morello
    /// Last Modified October 
    /// model for the institution
    /// </summary>
    public class Instutution
    {
        public string InstitutionTitle { get; set; }

        public string InstitutionAddress { get; set; }

        // validates institution name
        // the requirements for validating the institution name were "may be left blank"
        // for this reason the validation will always return a null error string
        public string ValidateInstitutionTitle()
        {
            return null;
        }

        // validates address
        // since no requirement was offered the rule for validating the address is, must be null if the title 
        // null, otherwise must provided (not an empty string)
        public string ValidateInstitutionAddress()
        {
            if (this.InstitutionTitle == null)
            {
                return this.InstitutionAddress == null ? null : "Please also provide the institution title";
            }
            else
            {
                return ValidationUtilities.ValidateNonEmpty("Institution Address", this.InstitutionAddress);
            }
        }

    }
}