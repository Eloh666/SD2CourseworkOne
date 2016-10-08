using System.Windows;
using System.Windows.Input;
using CourseworkOneMetro.Models;
using CourseworkOneMetro.ViewModels.Utils;


// view model for the certificate window

namespace CourseworkOneMetro.ViewModels
{
    public class CertificateViewModel : PropertyChangedNotifier
    {
        private readonly Attendee _currentAttendee;
        public string CertificateLabel { get; set; }

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
        }

        private void CloseWindow(Window window) => window.Close();

        //public ICommand SaveCurrentAttendee
        //{
        //    get { return new ICommandDelegate((Window stuff) => this.CloseWindow()); }
        //}


    }
}