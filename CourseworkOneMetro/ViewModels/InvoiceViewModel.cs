using System;
using System.Runtime.CompilerServices;
using System.Windows;
using CourseworkOneMetro.Models;
using CourseworkOneMetro.ViewModels.Commands;
using CourseworkOneMetro.ViewModels.Utils;


namespace CourseworkOneMetro.ViewModels
{
    /// <summary>
    /// view model for the Invoice Window
    /// </summary>
    public class InvoiceViewModel : PropertyChangedNotifier
    {
        private readonly Attendee _currentAttendee;
        public RelayCommand<Window> CloseWindowCommand { get; private set; }

        public string CurrentDate { get; }

        public string Conference { get; }

        public string FullName { get; }

        public string TotalDue { get; }

        public string Institution { get; }

        // sets up the visible fields of the invoice and the command to close the window
        public InvoiceViewModel(Attendee currentAttendee)
        {
            this._currentAttendee = currentAttendee;
            this.FullName = this._currentAttendee.Name +
                ' ' +
                this._currentAttendee.Surname;
            this.Conference = "Conference booked: " + this._currentAttendee.ConferenceName;
            this.TotalDue = "£" + this._currentAttendee.GetCost();
            this.Institution = this._currentAttendee.InstitutionTitle;
            this.CurrentDate = "Released on date: " + DateTime.Now;
            this.CloseWindowCommand = new CloseWindowCommand().CloseWindow;
        }

    }
}