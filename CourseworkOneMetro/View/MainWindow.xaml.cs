using System;
using System.Windows.Input;
using MahApps.Metro.Controls;

namespace CourseworkOneMetro
{
    /// <summary>
    /// Created by Davide Morello
    /// Last Modified October 
    /// view for the main window
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }


        // handles the event if the key is NOT containing a number and therefore:
        // Between D0 and D9 (a standard number button
        // Between numpad0 and numpad 9
        // Filtering the view input itself, in MVVM must be handled by the view itself
        private void HandleKeydownEvent(object sender, System.Windows.Input.KeyEventArgs e)
        {
            e.Handled = !(
                (e.Key >= Key.D0 && e.Key <= Key.D9)
                ||
                (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                );
        }
    }
}
