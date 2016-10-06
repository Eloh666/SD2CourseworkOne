using System.Linq.Expressions;
using System.Windows.Input;
using CourseworkOneMetro.Models;
using CourseworkOneMetro.ViewModels.Utils;

namespace CourseworkOneMetro.ViewModels
{
    public class RegistrationWindowViewModel
    {
        private AttendeeViewModel _attendeeViewModel;
        private Attendee _savedAttendee;

        public RegistrationWindowViewModel()
        {
            this._attendeeViewModel = new AttendeeViewModel();
        }

        public AttendeeViewModel AttendeeViewModel
        {
            get { return _attendeeViewModel; }
            set { _attendeeViewModel = value; }
        }

        public ICommand SaveCurrentAttendee
        {
            get { return new ICommandDelegate(() => this._savedAttendee = this._attendeeViewModel.GetAttendeeSavedData()); }
        }

        public ICommand ClearViewCommand
        {
            get { return new ICommandDelegate(() => _attendeeViewModel.Clear()); }
        }

        public ICommand LoadSavedAttendee
        {
            get
            {
                if (this._savedAttendee == null)
                {
                    return new ICommandDelegate(() => {});
                }
                else
                {
                    return new ICommandDelegate(() => _attendeeViewModel.LoadSavedAttendee(this._savedAttendee));
                }
            }
        }
    }
}