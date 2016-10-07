using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using CourseworkOneMetro.Models;
using CourseworkOneMetro.View;
using CourseworkOneMetro.ViewModels.Utils;
using MahApps.Metro.Controls.Dialogs;


namespace CourseworkOneMetro.ViewModels
{
    public class RegistrationWindowViewModel : PropertyChangedNotifier
    {
        private AttendeeViewModel _attendeeViewModel;
        private Attendee _savedAttendee;
        private readonly IDialogCoordinator _dialogCoordinator;

        delegate void basicDelegate();

        public RegistrationWindowViewModel()
        {
            this._dialogCoordinator = DialogCoordinator.Instance;
            this._attendeeViewModel = new AttendeeViewModel();
            OnPropertyChangedEvent(null);
        }


        public AttendeeViewModel AttendeeViewModel
        {
            get { return _attendeeViewModel; }
        }

        public ICommand SaveCurrentAttendee
        {
            get { return new ICommandDelegate(() => this._savedAttendee = this._attendeeViewModel.GetAttendeeSavedData()); }
        }

        public ICommand ClearViewCommand
        {
            get { return new ICommandDelegate(() => _attendeeViewModel.Clear()); }
        }

        public ICommand ShowInvoiceDialog
        {
            get
            {
                basicDelegate showInvoice = () =>
                {
                    InvoiceDialog invoiceDialog = new InvoiceDialog();
                    invoiceDialog.ShowDialog();
                };

                return new ICommandDelegate(() => showInvoice());
            }
        }

        public ICommand ShowCertificateDialog
        {
            get
            {
                return new ICommandDelegate(() =>
                {
                    CertificateDialog certificateDialog = new CertificateDialog();
                    certificateDialog.ShowDialog();
                });
            }
        }

        public ICommand LoadSavedAttendee
        {
            get
            {

                return new ICommandDelegate((() =>
                {
                    if (this._savedAttendee == null)
                    {
                        _dialogCoordinator.ShowMessageAsync(this, "Loading error", "You cannot load an attendee now. Save one first before attempting to load saved data.");
                    }
                    else
                    {
                        _attendeeViewModel.LoadSavedAttendee(this._savedAttendee);
                    }
                }));
            }
        }
    }
}