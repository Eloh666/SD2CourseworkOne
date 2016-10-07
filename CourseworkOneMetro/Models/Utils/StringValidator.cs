namespace CourseworkOneMetro.Models.Utils
{
    public class StringValidator
    {
        public bool ValidateNonEmptyField(string value)
        {
            return value != "";
        }
    }
}