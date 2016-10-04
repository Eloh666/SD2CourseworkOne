using System;
using System.Collections;
using System.ComponentModel;
using CourseworkOneMetro.Models;

namespace CourseworkOneMetro.ViewModels
{
    public class AttendeeViewModel : Attendee, INotifyPropertyChanged
    {
        // implements the INotifyPropertyChanged interface
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChangedEvent(string propertyName)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Clear()
        {
            base.Clear();
            OnPropertyChangedEvent(null);
        }

        public object GetAttendeeSavedData()
        {
            return base.Clone();
        }

        public new string Name
        {
            get { return base.Name; }
            set
            {
                base.Name = value;
                OnPropertyChangedEvent("Name");
            }
        }
        public new string Surname
        {
            get { return base.Surname; }
            set
            {
                base.Surname = value;
                OnPropertyChangedEvent("Surname");
            }
        }

        public new uint AttendeeRef
        {
            get { return base.AttendeeRef; }
            set
            {
                base.AttendeeRef = value;
                OnPropertyChangedEvent("AttendeeRef");
            }
        }

        public new string ConferenceName
        {
            get { return base.ConferenceName; }
            set
            {
                base.ConferenceName = value;
                OnPropertyChangedEvent("ConferenceName");
            }
        }

        public new string RegistrationType
        {
            get { return base.RegistrationType; }
            set
            {
                base.RegistrationType = value;
                OnPropertyChangedEvent("RegistrationType");
            }
        }

        public new bool Paid
        {
            get { return base.Paid; }
            set
            {
                base.Paid = value;
                OnPropertyChangedEvent("Paid");
            }
        }

        public new bool Presenter
        {
            get { return base.Presenter; }
            set
            {
                base.Presenter = value;
                OnPropertyChangedEvent("Presenter");
            }
        }

        public new string PaperTitle
        {
            get { return base.PaperTitle; }
            set
            {
                base.PaperTitle = value;
                OnPropertyChangedEvent("PaperTitle");
            }
        }

        public new string InstitutionTitle
        {
            get { return base.InstitutionTitle; }
            set
            {
                base.InstitutionTitle = value;
                OnPropertyChangedEvent("Institution");
            }
        }
    }
}