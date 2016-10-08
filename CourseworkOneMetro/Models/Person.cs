using System;

namespace CourseworkOneMetro.Models
{
    public class Person
    {
        protected string _name;
        protected string _surname;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
            }
        }

        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

    }
}