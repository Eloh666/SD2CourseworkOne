namespace CourseworkOneMetro.Model
{
    public class Person
    {
        protected string name;
        protected string surname;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public bool ValidateNonEmptyField(string value)
        {
            return value != "";
        }
    }
}