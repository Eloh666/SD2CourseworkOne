using CourseworkOneMetro.Models;
using CourseworkOneMetro.ViewModels.Utils;


// view model for the certificate window
namespace CourseworkOneMetro.ViewModels
{
    public class CertificateViewModel : PropertyChangedNotifier
    {
        private readonly Attendee _currentAttendee;
        public CertificateViewModel(Attendee currentAttendee)
        {
            this._currentAttendee = currentAttendee;
        }
    }
}