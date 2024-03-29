﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using CourseworkOneMetro.Models;
using CourseworkOneMetro.ViewModels.Utils;

namespace CourseworkOneMetro.ViewModels
{
    /// <summary>
    /// Created by Davide Morello
    /// Last Modified October 
    /// view mondel for the attendee, it encapsulates the attendee model
    /// </summary>
    public class AttendeeViewModel : PropertyChangedNotifier, IDataErrorInfo
    {
        private Attendee _attendee;
        private readonly Dictionary<string, bool> _fieldsUseDictionary;

        // 0 args constructor for the viewModel that wraps the attendee, the dictionary is used
        // to avoid displaying the validation errors until a field has actually been used
        // at least once or the user has tried to save/open an extra window
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
            this._fieldsUseDictionary.Add("InstitutionAddress", false);
            this._fieldsUseDictionary.Add("RegistrationType", false);
        }

        // wrapper that clears the instancied attendee model and notifies the view
        public void Clear()
        {
            this._attendee.Clear();
            this._fieldsUseDictionary["Name"] = false;
            this._fieldsUseDictionary["Surname"] = false;
            this._fieldsUseDictionary["AttendeeRef"] = false;
            this._fieldsUseDictionary["ConferenceName"] = false;
            this._fieldsUseDictionary["PaperTitle"] = false;
            this._fieldsUseDictionary["InstitutionTitle"] = false;
            this._fieldsUseDictionary["InstitutionAddress"] = false;
            this._fieldsUseDictionary["RegistrationType"] = false;
            OnPropertyChangedEvent(null);
        }

        // extracts the model to be saved when necessary
        public Attendee GetAttendeeSavedData()
        {
            return (Attendee) _attendee.Clone();
        }

        // loads a saved attendee model
        public void LoadSavedAttendee(Attendee savedAttendee)
        {
            this._attendee = new Attendee(savedAttendee);
            OnPropertyChangedEvent(null);
        }


        // Accessor/Wrrapers for the attendee properties,
        // they all refresh the view through the INotify interface

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
                this._fieldsUseDictionary["RegistrationType"] = true;
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
                if (!value)
                {
                    this._fieldsUseDictionary["PaperTitle"] = false;
                }
                OnPropertyChangedEvent("Presenter");
                OnPropertyChangedEvent("PaperTitle");
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
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _attendee.InstitutionAddress = null;
                    this._fieldsUseDictionary["InstitutionAddress"] = false;
                }
                OnPropertyChangedEvent(null);
            }
        }
        public string InstitutionAddress
        {
            get { return _attendee.InstitutionAddress; }
            set
            {
                _attendee.InstitutionAddress = value;
                this._fieldsUseDictionary["InstitutionAddress"] = true;
                OnPropertyChangedEvent("InstitutionAddress");
            }
        }

        public bool InstitutioNameProvided => !string.IsNullOrWhiteSpace(this.InstitutionTitle);


        // simple getters for the constants
        public List<string> RegistrationTypes => _attendee.RegistrationTypes;
        public uint MinRefNumber => _attendee.MinRefNumber;
        public uint MaxRefNumber => _attendee.MaxRefNumber;

        // Simple version of the Interface IDataError implementation & general validation logic
        string IDataErrorInfo.Error => null;
        string IDataErrorInfo.this[string fieldName] => GetValidationError(fieldName);

        // fields that require validation
        private static readonly string[] ValidationFields =
        {
            "Name",
            "Surname",
            "ConferenceName",
            "PaperTitle",
            "InstitutionTitle",
            "InstitutionAddress",
            "AttendeeRef",
            "RegistrationType"
        };

        // check the whole attendee for being valid, the dictionary is used
        // to avoid displaying the validation errors until a field has actually been used
        // at least once or the user has tried to save/open an extra window
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
                this._fieldsUseDictionary["InstitutionAddress"] = true;
                this._fieldsUseDictionary["RegistrationType"] = true;


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

        // validates fields based on the requirements of the model
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
                    case "InstitutionAddress":
                        error = this._attendee.ValidateInstitutionAddress();
                        break;
                    case "AttendeeRef":
                        error = this._attendee.ValidateAttendeeRef();
                        break;
                    case "RegistrationType":
                        error = this._attendee.ValidateRegistrationType();
                        break;
                }
            }
            return error;
        }

    }
}