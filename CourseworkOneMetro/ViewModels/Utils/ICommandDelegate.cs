using System;
using System.Windows.Input;

namespace CourseworkOneMetro.ViewModels.Utils
{
    public class ICommandDelegate : ICommand
    {

        private readonly Action _actionToExecute;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _actionToExecute();
        }

        public event EventHandler CanExecuteChanged;
    }
}