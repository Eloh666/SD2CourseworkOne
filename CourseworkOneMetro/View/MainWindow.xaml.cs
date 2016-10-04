using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using System.Text.RegularExpressions;
using CourseworkOneMetro.Models;
using CourseworkOneMetro.ViewModels;

namespace CourseworkOneMetro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private AttendeeModel viewAttendee = new AttendeeModel();
        private Attendee savedAttendee = new Attendee();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = viewAttendee;
        }

        private void HandleChangeText(object sender, TextChangedEventArgs e)
        {
        //    TextBox eventSender = ((TextBox)sender);
        //    string name = eventSender.Name;
        //    string text = eventSender.Text;
        //    bool isValid = InputValidator.Validator.ValidateInput(name, text);
        //    if (isValid)
        //    {
        //        eventSender.BorderBrush = System.Windows.Media.Brushes.Green;
        //    }
        //    else
        //    {
        //        eventSender.BorderBrush = System.Windows.Media.Brushes.Red;
        //        if(text == "")
        //        {
        //        }
        //    }
        }
        private void SetButton_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
