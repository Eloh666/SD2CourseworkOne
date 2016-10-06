using System;
using System.Collections;
using System.ComponentModel;
using CourseworkOneMetro.Models;
using CourseworkOneMetro.ViewModels.Utils;

namespace CourseworkOneMetro.ViewModels
{
    public class AttendeeViewModel : PropertyChangedNotifier
    {
        private Attendee _attendee;
        public AttendeeViewModel()
        {
           _attendee =  new Attendee();
        }
        public void Clear()
        {
            this._attendee.Clear();
            OnPropertyChangedEvent(null);
        }

        public Attendee GetAttendeeSavedData()
        {
            return (Attendee) _attendee.Clone();
        }

        public void LoadSavedAttendee(Attendee savedAttendee)
        {
            this._attendee = new Attendee(savedAttendee);
            OnPropertyChangedEvent(null);
        }

        public string Name
        {
            get { return _attendee.Name; }
            set
            {
                _attendee.Name = value;
                OnPropertyChangedEvent("Name");
            }
        }
        public string Surname
        {
            get { return _attendee.Surname; }
            set
            {
                _attendee.Surname = value;
                OnPropertyChangedEvent("Surname");
            }
        }

        public uint AttendeeRef
        {
            get { return _attendee.AttendeeRef; }
            set
            {
                _attendee.AttendeeRef = value;
                OnPropertyChangedEvent("AttendeeRef");
            }
        }

        public string ConferenceName
        {
            get { return _attendee.ConferenceName; }
            set
            {
                _attendee.ConferenceName = value;
                OnPropertyChangedEvent("ConferenceName");
            }
        }

        public string RegistrationType
        {
            get { return _attendee.RegistrationType; }
            set
            {
                _attendee.RegistrationType = value;
                OnPropertyChangedEvent("RegistrationType");
            }
        }

        public ArrayList RegistrationTypes
        {
            get { return _attendee.RegistrationTypes; }

        }

        public bool Paid
        {
            get { return _attendee.Paid; }
            set
            {
                _attendee.Paid = value;
                OnPropertyChangedEvent("Paid");
            }
        }

        public bool Presenter
        {
            get { return _attendee.Presenter; }
            set
            {
                _attendee.Presenter = value;
                OnPropertyChangedEvent("Presenter");
            }
        }

        public string PaperTitle
        {
            get { return _attendee.PaperTitle; }
            set
            {
                _attendee.PaperTitle = value;
                OnPropertyChangedEvent("PaperTitle");
            }
        }

        public string InstitutionTitle
        {
            get { return _attendee.InstitutionTitle; }
            set
            {
                _attendee.InstitutionTitle = value;
                OnPropertyChangedEvent("Institution");
            }
        }
    }
}