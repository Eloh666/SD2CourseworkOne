using System.Runtime.CompilerServices;
using CourseworkOneMetro.Models;
using CourseworkOneMetro.ViewModels.Utils;

namespace CourseworkOneMetro.ViewModels
{
    public class InvoiceViewModel : PropertyChangedNotifier
    {
        private readonly Attendee _currentAttendee;
        private readonly string _heading;
        private readonly string _fullName;
        private readonly string _cost;

        public InvoiceViewModel(Attendee currentAttendee)
        {
            this._currentAttendee = currentAttendee;
        }
    }
}