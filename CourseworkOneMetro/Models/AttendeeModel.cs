using System.ComponentModel;
using System.Windows.Controls;
using CourseworkOneMetro.Model;

namespace CourseworkOneMetro.Models
{
    public class AttendeeModel : Attendee, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public new string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
                OnPropertyChanged("Name");
            }
        }
        public new string Surname
        {
            get { return this.surname; }
            set
            {
               this.surname = value;
                OnPropertyChanged("Surname");
            }
        }

        public new uint AttendeeRef
        {
            get { return base.AttendeeRef; }
            set
            {
                base.AttendeeRef = value;
                OnPropertyChanged("AttendeeRef");
            }
        }

        public new string ConferenceName
        {
            get { return base.ConferenceName; }
            set
            {
                base.ConferenceName = value;
                OnPropertyChanged("ConferenceName");
            }
        }

        public new string RegistrationType
        {
            get { return base.RegistrationType; }
            set
            {
                base.RegistrationType = value;
                OnPropertyChanged("RegistrationType");
            }
        }

        public new bool Paid
        {
            get { return base.Paid; }
            set
            {
                base.Paid = value;
                OnPropertyChanged("Paid");
            }
        }

        public new bool Presenter
        {
            get { return base.Presenter; }
            set
            {
                base.Presenter = value;
                OnPropertyChanged("Presenter");
            }
        }

        public new string PaperTitle
        {
            get { return base.PaperTitle; }
            set
            {
                base.PaperTitle = value;
                OnPropertyChanged("PaperTitle");
            }
        }

        public new string InstitutionTitle
        {
            get { return base.InstitutionTitle; }
            set
            {
                base.InstitutionTitle = value;
                OnPropertyChanged("Institution");
            }
        }
    }
}