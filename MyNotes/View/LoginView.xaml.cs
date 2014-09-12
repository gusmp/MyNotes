using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using GalaSoft.MvvmLight.Messaging;
using MyNotes.Message;

namespace MyNotes.View
{
    public partial class LoginView : BaseView
    {
        public LoginView()
        {
            InitializeComponent();
            Messenger.Default.Register<LoginMessage>(this,Navigation);
        }

        private void Navigation(LoginMessage loginMessage)
        {
            if (loginMessage.LoginSuccessful == true)
            {

                NavigationService.Navigate(new Uri("/View/NoteListView.xaml", UriKind.Relative));
            }
            else
            {
                MessageBox.Show("Password no valid!");
            }
        }
    }
}