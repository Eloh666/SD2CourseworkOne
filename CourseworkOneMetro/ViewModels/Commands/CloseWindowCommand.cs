using System.Windows;
using CourseworkOneMetro.ViewModels.Utils;

namespace CourseworkOneMetro.ViewModels.Commands
{
    public class CloseWindowCommand
    {
        public RelayCommand<Window> CloseWindow { get; private set; }

        public CloseWindowCommand()
        {
            this.CloseWindow = new RelayCommand<Window>(this.CloseWindowRequest);
        }

        private void CloseWindowRequest(Window window)
        {
            window?.Close();
        }
    }
}