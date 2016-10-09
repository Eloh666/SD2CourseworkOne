using System;
using CourseworkOneMetro.Models;
using CourseworkOneMetro.View;
using CourseworkOneMetro.ViewModels.Utils;
using MahApps.Metro.Controls.Dialogs;


// view model for the main windopw
namespace CourseworkOneMetro.ViewModels
{
    /// <summary>
    /// extends the PropertyChangedNotifier class which implements INotifyPropertyChanged interface
    /// extending an implementation of the interface instead of implementing said interface everytime
    /// saves some repetition and keeps the code a bit more DRY when possible
    /// </summary>
    public class RegistrationWindowViewModel : PropertyChangedNotifier
    {
        private readonly AttendeeViewModel _attendeeViewModel;
        private Attendee _savedAttendee;
        private readonly IDialogCoordinator _dialogCoordinator;

        public LightRelayCommand SaveAttendeeCommand { get; private set; }
        public LightRelayCommand LoadAttendeeCommand { get; private set; }
        public LightRelayCommand ClearFieldsCommand { get; private set; }
        public LightRelayCommand ShowInvoiceCommand { get; private set; }
        public LightRelayCommand ShowCerrtificateCommand { get; private set; }

        // zero args constructors, creates an attendeeViewmodel and initialises the metro dialog coordinator
        public RegistrationWindowViewModel()
        {
            this._dialogCoordinator = DialogCoordinator.Instance;
            this._attendeeViewModel = new AttendeeViewModel();
            // command to handle saving an attendee
            this.SaveAttendeeCommand = new LightRelayCommand(this.SaveAttendee);
            // command to handle clearing an attendee
            this.ClearFieldsCommand = new LightRelayCommand(() => _attendeeViewModel.Clear());
            // command to handle showing invoices
            this.ShowInvoiceCommand = new LightRelayCommand(this.ShowInvoice);
            // command to handle showing certificates
            this.ShowCerrtificateCommand = new LightRelayCommand(this.ShowCertificate);
            // command to handle loading saved attendee data
            this.LoadAttendeeCommand = new LightRelayCommand(this.LoadAttendee);
            OnPropertyChangedEvent(null);
        }


        // saves an attendee
        private void SaveAttendee()
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
        }

        // pops up the invoice window
        private void ShowInvoice()
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
        }

        // handles showing the certificate
        private void ShowCertificate()
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
        }

        // handles loading a saved attendee
        private void LoadAttendee()
        {
            if (this._savedAttendee == null)
            {
                _dialogCoordinator.ShowMessageAsync(this, "Loading error", "You cannot load an attendee now. Save one first before attempting to load saved data.");
            }
            else
            {
                _attendeeViewModel.LoadSavedAttendee(this._savedAttendee);
            }
        }


        // accessor for the attendee
        public AttendeeViewModel AttendeeViewModel => this._attendeeViewModel;


        // helper to display full validation warning
        private void FormInvalidWarning()
        {
            _dialogCoordinator.ShowMessageAsync(this, "Form is invalid",
                            "Some of the details you have entered are missing or invalid. Please amend them before proceeding.");
            OnPropertyChangedEvent(null);
        }
    }
}