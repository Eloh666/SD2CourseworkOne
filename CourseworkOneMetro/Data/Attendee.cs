using System.ComponentModel;
using System.Windows.Controls.Primitives;
using CourseworkOneMetro.Models;

namespace CourseworkOneMetro.Model
{
    public class Attendee : Person
    {
        public uint AttendeeRef { get; set; }
        public string ConferenceName { get; set; }
        public string RegistrationType { get; set; }
        public bool Paid { get; set; }
        public bool Presenter { get; set; }
        public string PaperTitle { get; set; }
        public string InstitutionTitle { get; set; }

        public Attendee()
        {
            this.Paid = false;
            this.Presenter = false;
        }

        public bool ValidateInstitution(string value)
        {
            return true;
            // TODO change it according to specs
        }

        public bool ValidateAttendeeRef(string value)
        {
            try
            {
                uint parsedValue = uint.Parse(value);
                return (parsedValue >= 40000 && parsedValue <= 60000);
            }
            catch
            {
                return false;
            }
        }

        public bool ValidatePaperTitle(string value)
        {
            return !this.Presenter || (value != "");
        }

        public bool ValidateRegistration(string value)
        {
            return value == "Full" || value == "Student" || value == "Organiser";
        }
    }
}