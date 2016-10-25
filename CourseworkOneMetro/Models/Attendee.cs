using System;
using System.Collections.Generic;
using System.Linq;
using CourseworkOneMetro.Models.Utils;

namespace CourseworkOneMetro.Models
{
    /// <summary>
    /// Created by Davide Morello
    /// Last Modified October 
    /// attende model, extends Person and implements the ICloneable interface
    /// </summary>
    public class Attendee : Person, ICloneable
    {
        // needs capital letter for naming convention being a constant
        private const uint Minrefnum = 40000;
        private const uint Maxrefnum = 60000;

        private bool _presenter;
        private readonly Instutution _institution; 

        public uint AttendeeRef { get; set; }
        public string ConferenceName { get; set; }
        public string RegistrationType { get; set; }
        public bool Paid { get; set; }
        public string PaperTitle { get; set; }

        // zero parameters constructor, initialises the type of registrations only
        public Attendee()
        {
            this._institution = new Instutution();
            this.RegistrationTypes.Add("Student");
            this.RegistrationTypes.Add("Full");
            this.RegistrationTypes.Add("Organiser");
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
            this.Name = null;
            this.Surname = null;
            this.PaperTitle = null;
            this.AttendeeRef = 0;
            this.ConferenceName = null;
            this.InstitutionTitle = null;
            this.RegistrationType = null;
        }


        // Accessors
        public uint MaxRefNumber => Minrefnum;
        public uint MinRefNumber => Maxrefnum;

        public bool Presenter
        {
            get { return _presenter; }
            set
            {
                this.PaperTitle = value ? this.PaperTitle : null;
                _presenter = value;
            }
        }

        // would have made this one an accessor as well, but the specs wanted a method
        public ushort GetCost()
        {
            switch (RegistrationType)
            {
                case "Student":
                    return 300;
                case "Full":
                    return 500;
                case "Organiser":
                    // falls through
                default:
                    return 0;
            }
        }

        // accessors for institution properties and contents of the registration combo box
        public string InstitutionTitle
        {
            get { return this._institution.InstitutionTitle; }
            set { this._institution.InstitutionTitle = value; }
        }
        public string InstitutionAddress
        {
            get { return this._institution.InstitutionAddress; }
            set { this._institution.InstitutionAddress = value; }
        }

        public List<string> RegistrationTypes { get; } = new List<string>();


        // validation for the paper title
        public string ValidatePaperTitle()
        {
            if (!this.Presenter)
            {
                // with the current error handling managed by the view model and the model itself, the second scenario
                // cannot happen, however I am adding the check due to the requirements of the coursework
                return this.PaperTitle == null ? null : "The title of the paper must be null if you are not presenting";
            }
            else
            {
                return ValidationUtilities.ValidateNonEmpty("Paper Title", this.PaperTitle);
            }
        }


        // validation for the conference name
        public string ValidateConferenceName()
        {
            return ValidationUtilities.ValidateNonEmpty("Conference Name", this.ConferenceName);
        }

        // validation for the attendee reference number
        public string ValidateAttendeeRef()
        {
            if (this.AttendeeRef >= 40000 && this.AttendeeRef <= 60000)
            {
                return null;
            }
            else
            {
                return
                    "The attendee reference number is invalid. The reference nuber interval is between 40000 and 60000";
            }
        }

        public string ValidateRegistrationType()
        {
            if (this.RegistrationTypes.Count(item => item == this.RegistrationType) != 0)
            {
                return null;
            }
            else
            {
                return "Please select a value";
            }
        }

        // passes on the validation for the institution title and address
        public string ValidateInstitutionTitle()
        {
            return this._institution.ValidateInstitutionTitle();
        }

        public string ValidateInstitutionAddress()
        {
            return this._institution.ValidateInstitutionAddress();
        }
    }
}
