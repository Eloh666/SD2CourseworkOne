using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using CourseworkOneMetro.Models;
using CourseworkOneMetro.View;
using CourseworkOneMetro.ViewModels.Utils;
using MahApps.Metro.Controls.Dialogs;


// view model for the main windopw
namespace CourseworkOneMetro.ViewModels
{   
    /*
    * extends the PropertyChangedNotifier class which implements INotifyPropertyChanged interface
    * extending an implementation of the interface instead of implementing said interface everytime
    * saves some repetition and keeps the code a bit more DRY when possible
    */
    public class RegistrationWindowViewModel : PropertyChangedNotifier
    {
        private AttendeeViewModel _attendeeViewModel;
        private Attendee _savedAttendee;
        private readonly IDialogCoordinator _dialogCoordinator;
        private CertificateViewModel _certificateViewModel;

        delegate void basicDelegate();

        // zero args constructors, creates an attendeeViewmodel and initialises the metro dialog coordinator
        public RegistrationWindowViewModel()
        {
            this._dialogCoordinator = DialogCoordinator.Instance;
            this._attendeeViewModel = new AttendeeViewModel();
            OnPropertyChangedEvent(null);
        }


        public AttendeeViewModel AttendeeViewModel
        {
            get { return this._attendeeViewModel; }
        }

        private void FormInvalidWarning()
        {
            _dialogCoordinator.ShowMessageAsync(this, "Form is invalid",
                            "Some of the details you have entered are missing or invalid. Please amend them before proceeding.");
            OnPropertyChangedEvent(null);
        }

        // handles saving an attendee
        public ICommand SaveCurrentAttendee
        {
            get { return new ICommandDelegate(() =>
            {
                if (this._attendeeViewModel.IsAttendeeValid)
                {
                    this._savedAttendee = this._attendeeViewModel.GetAttendeeSavedData();
                    _dialogCoordinator.ShowMessageAsync(this, "Saved",
                            "Your details have been saved.");
                }
                else
                {
                    this.FormInvalidWarning();
                }
            }); }
        }

        // handles clearing the various fields of the form
        public ICommand ClearViewCommand
        {
            get { return new ICommandDelegate(() => _attendeeViewModel.Clear()); }
        }

        // handles showing an invoice
        public ICommand ShowInvoiceDialog
        {
            get
            {
                basicDelegate showInvoice = () =>
                {
                    if (!this._attendeeViewModel.IsAttendeeValid)
                    {
                        this.FormInvalidWarning();
                    }
                    else
                    {
                        InvoiceDialog invoiceDialog = new InvoiceDialog();
                        invoiceDialog.DataContext = new InvoiceViewModel(this._attendeeViewModel.GetAttendeeSavedData());
                        invoiceDialog.ShowDialog();
                    }
                };

                return new ICommandDelegate(() => showInvoice());
            }
        }
        
        // handles showing the certificate
        public ICommand ShowCertificateDialog
        {
            get
            {
                basicDelegate showCertificate = () =>
                {
                    if (!this._attendeeViewModel.IsAttendeeValid)
                    {
                        this.FormInvalidWarning();
                    }
                    else
                    {
                        CertificateDialog certificateDialog = new CertificateDialog();
                        certificateDialog.DataContext = new CertificateViewModel(this._attendeeViewModel.GetAttendeeSavedData());
                        certificateDialog.ShowDialog();
                    }
                };

                return new ICommandDelegate(() => showCertificate());
            }
        }

        // handles loading a saved attendee
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