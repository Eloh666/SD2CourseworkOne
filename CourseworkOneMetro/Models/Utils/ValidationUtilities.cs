using System;

namespace CourseworkOneMetro.Models.EmptyStringValidation
{
    public class ValidationUtilities
    {
        public static string ValidateNonEmpty(string field, string property)
        {
            if (String.IsNullOrWhiteSpace(property))
            {
                return field + " cannot be blank";
            }
            else
            {
                return null;
            }
        }
    }
}