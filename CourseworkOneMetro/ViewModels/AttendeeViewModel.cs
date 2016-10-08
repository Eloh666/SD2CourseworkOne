using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using CourseworkOneMetro.Models;
using CourseworkOneMetro.ViewModels.Utils;


// view mondel for the attendee, it encapsulates the attendee model

namespace CourseworkOneMetro.ViewModels
{
    public class AttendeeViewModel : PropertyChangedNotifier, IDataErrorInfo
    {
        private Attendee _attendee;
        private Dictionary<string, bool> _fieldsUseDictionary;

        public AttendeeViewModel()
        {
            _attendee = new Attendee();
            _fieldsUseDictionary = new Dictionary<string, bool>();
            this._fieldsUseDictionary.Add("Name", false);
            this._fieldsUseDictionary.Add("Surname", false);
            this._fieldsUseDictionary.Add("AttendeeRef", false);
            this._fieldsUseDictionary.Add("ConferenceName", false);
            this._fieldsUseDictionary.Add("PaperTitle", false);
            this._fieldsUseDictionary.Add("InstitutionTitle", false);
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
                this._fieldsUseDictionary["Name"] = true;
                OnPropertyChangedEvent("Name");
            }
        }

        public string Surname
        {
            get { return _attendee.Surname; }
            set
            {
                _attendee.Surname = value;
                this._fieldsUseDictionary["Surname"] = true;
                OnPropertyChangedEvent("Surname");
            }
        }

        public uint AttendeeRef
        {
            get { return _attendee.AttendeeRef; }
            set
            {
                _attendee.AttendeeRef = value;
                this._fieldsUseDictionary["AttendeeRef"] = true;
                OnPropertyChangedEvent("AttendeeRef");
            }
        }

        public string ConferenceName
        {
            get { return _attendee.ConferenceName; }
            set
            {
                _attendee.ConferenceName = value;
                this._fieldsUseDictionary["ConferenceName"] = true;
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
                this._fieldsUseDictionary["PaperTitle"] = true;
                OnPropertyChangedEvent("PaperTitle");
            }
        }

        public string InstitutionTitle
        {
            get { return _attendee.InstitutionTitle; }
            set
            {
                _attendee.InstitutionTitle = value;
                this._fieldsUseDictionary["InstitutionTitle"] = true;
                OnPropertyChangedEvent("InstitutionTitle");
            }
        }


        public ArrayList RegistrationTypes
        {
            get { return _attendee.RegistrationTypes; }

        }

        public uint MinRefNumber
        {
            get { return _attendee.MinRefNumber; }

        }

        public uint MaxRefNumber
        {
            get { return _attendee.MaxRefNumber; }

        }

        // Interface IDataError Implementation & validation logic


        string IDataErrorInfo.Error
        {
            get { return null; }
        }

        string IDataErrorInfo.this[string fieldName]
        {
            get
            {
                return GetValidationError(fieldName);
            }
        }

        private static readonly string[] ValidationFields =
        {
            "Name",
            "Surname",
            "ConferenceName",
            "PaperTitle",
            "InstitutionTitle"
        };

        public bool IsAttendeeValid
        {
            get
            {
                this._fieldsUseDictionary["Name"] = true;
                this._fieldsUseDictionary["Surname"] = true;
                this._fieldsUseDictionary["AttendeeRef"] = true;
                this._fieldsUseDictionary["ConferenceName"] = true;
                this._fieldsUseDictionary["PaperTitle"] = true;
                this._fieldsUseDictionary["InstitutionTitle"] = true;


                foreach (string field in ValidationFields)
                {
                    if (GetValidationError(field) != null)
                    {
                        return false;
                    }
                }
                return true;
            }
        }


        private string GetValidationError(String fieldName)
        {
            string error = null;
            if (this._fieldsUseDictionary[fieldName])
            {
                switch (fieldName)
                {
                    case "Name":
                        error = this._attendee.ValidateName();
                        break;
                    case "Surname":
                        error = this._attendee.ValidateSurname();
                        break;
                    case "ConferenceName":
                        error = this._attendee.ValidateConferenceName();
                        break;
                    case "PaperTitle":
                        error = this._attendee.ValidatePaperTitle();
                        break;
                    case "InstitutionTitle":
                        error = this._attendee.ValidateInstitutionTitle();
                        break;
                }
            }
            return error;
        }

    }
}