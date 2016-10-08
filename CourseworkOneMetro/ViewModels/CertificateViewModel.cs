using System.Windows;
using CourseworkOneMetro.Models;
using CourseworkOneMetro.ViewModels.Commands;
using CourseworkOneMetro.ViewModels.Utils;


// view model for the certificate window

namespace CourseworkOneMetro.ViewModels
{
    public class CertificateViewModel : PropertyChangedNotifier
    {
        private readonly Attendee _currentAttendee;
        public string CertificateLabel { get; set; }
        public RelayCommand<Window> CloseWindowCommand { get; private set; }

        public CertificateViewModel(Attendee currentAttendee)
        {
            this._currentAttendee = currentAttendee;
            this.CertificateLabel = "This is to certify that "
                                    + this._currentAttendee.Name + " "
                                    + this._currentAttendee.Surname
                                    + " attended "
                                    + this._currentAttendee.ConferenceName
                                    +
                                    (!this._currentAttendee.Presenter
                                        ? "."
                                        : " and presented a paper entitled " + this._currentAttendee.PaperTitle);
            this.CloseWindowCommand = new CloseWindowCommand().CloseWindow;
        }





    }
}