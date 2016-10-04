using CourseworkOneMetro.Models;

namespace CourseworkOneMetro.ViewModels
{
    public class RegistrationWindowViewModel
    {
        private AttendeeViewModel _attendeeViewModel;
        private Attendee savedAttendee;

        public RegistrationWindowViewModel()
        {
            this._attendeeViewModel = new AttendeeViewModel();
        }

        public AttendeeViewModel AttendeeViewModel
        {
            get { return _attendeeViewModel; }
            set { _attendeeViewModel = value; }
        }
    }
}