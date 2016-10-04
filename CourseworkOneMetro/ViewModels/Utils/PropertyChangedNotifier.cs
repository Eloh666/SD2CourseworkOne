using System.ComponentModel;

namespace CourseworkOneMetro.ViewModels.Utils
{
    public class PropertyChangedNotifier : INotifyPropertyChanged
    {
        // implements the INotifyPropertyChanged interface
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChangedEvent(string propertyName)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}