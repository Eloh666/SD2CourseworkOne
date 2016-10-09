using System;

namespace CourseworkOneMetro.Models.Utils
{
    /// <summary>
    /// super simple function that returns an error if a string is empty, 
    ///  since it used by three classes was a good idea to pull it out
    /// </summary>
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