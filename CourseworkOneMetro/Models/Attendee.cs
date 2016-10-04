using System;
using System.Collections;
using System.ComponentModel;

namespace CourseworkOneMetro.Models
{
    // attende model, extends Person and implements the ICloneable interface
    public class Attendee : Person, ICloneable
    {

        private uint _attendeeRef;
        private string _conferenceName;
        private string _registrationType;
        private bool _paid;
        private bool _presenter = true;
        private string _paperTitle;
        private string _institutionTitle;

        private ArrayList _registrationTypes = new ArrayList();

        // zero parameters constructor, initialises the type of registrations only
        public Attendee()
        {
            this.RegistrationType = "Student";
            this._registrationTypes.Add("Student");
            this._registrationTypes.Add("Full");
            this._registrationTypes.Add("Organiser");
        }

        // creates an attendee from another attendee
        public Attendee(Attendee oldAttendee) : this()
        {
            this.Paid = oldAttendee.Paid;
            this.Presenter = oldAttendee.Presenter;
            this.RegistrationType = oldAttendee.RegistrationType;
            this.Name = oldAttendee.Name;
            this.Surname = oldAttendee.Surname;
            this.PaperTitle = this.Presenter
                ? oldAttendee.PaperTitle
                : "";
            this.AttendeeRef = oldAttendee.AttendeeRef;
            this.ConferenceName = oldAttendee.ConferenceName;
            this.InstitutionTitle = oldAttendee.InstitutionTitle;
        }

        // implements the ICloneable interface, simply clones the object
        public object Clone()
        {
            return new Attendee(this);
        }

        // clears all the property of the current object and resets them all to default
        public void Clear()
        {
            this.Paid = false;
            this.Presenter = false;
            this.RegistrationType = "Student";
            this.Name = "";
            this.Surname = "";
            this.PaperTitle = "";
            this.AttendeeRef = 0;
            this.ConferenceName = "";
            this.InstitutionTitle = "";
        }

        public uint AttendeeRef
        {
            get { return _attendeeRef; }
            set { _attendeeRef = value; }
        }

        public string ConferenceName
        {
            get { return _conferenceName; }
            set { _conferenceName = value; }
        }

        public string RegistrationType
        {
            get { return _registrationType; }
            set { _registrationType = value; }
        }

        public bool Paid
        {
            get { return _paid; }
            set { _paid = value; }
        }

        public bool Presenter
        {
            get { return _presenter; }
            set { _presenter = value; }
        }

        public string PaperTitle
        {
            get { return _paperTitle; }
            set { _paperTitle = value; }
        }

        public string InstitutionTitle
        {
            get { return _institutionTitle; }
            set { _institutionTitle = value; }
        }

        public ArrayList RegistrationTypes
        {
            get { return _registrationTypes; }
            set { _registrationTypes = value; }
        }


        // validation for the institution field
        public bool ValidateInstitution(string value)
        {
            return true;
            // TODO change it according to specs
        }

        // validation for the attendee reference number
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

        // validation for the attendee paper title
        public bool ValidatePaperTitle(string value)
        {
            return !this.Presenter || (value != "");
        }

        // validation/test for the registration type
        public bool ValidateRegistration(string value)
        {
            return value == "Full" || value == "Student" || value == "Organiser";
        }
    }
}