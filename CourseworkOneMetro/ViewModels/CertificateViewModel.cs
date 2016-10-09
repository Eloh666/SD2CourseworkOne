using System.Windows;
using CourseworkOneMetro.Models;
using CourseworkOneMetro.ViewModels.Commands;
using CourseworkOneMetro.ViewModels.Utils;


namespace CourseworkOneMetro.ViewModels
{
    /// <summary>
    /// view model for the certificate window
    /// </summary>
    public class CertificateViewModel : PropertyChangedNotifier
    {
        private readonly Attendee _currentAttendee;
        public string CertificateLabel { get;}
        public RelayCommand<Window> CloseWindowCommand { get; private set; }

        // builds the certificate string and instanciates a proper close window command handler
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