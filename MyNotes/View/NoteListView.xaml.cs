using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MyNotes.ViewModel;

namespace MyNotes.View
{
    public partial class NoteListView : BaseView
    {

        public NoteListView()
        {
            InitializeComponent();
        }

        private void ApplicationBarIconAddNoteButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/AddNoteView.xaml",UriKind.Relative));
        }

        private void ApplicationBarIconConfigurationButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/ConfigurationView.xaml", UriKind.Relative));
        }

        private void EditNoteTextBlock_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            string uri = String.Format("/View/EditNoteView.xaml?noteId={0}", ((TextBlock) sender).Tag);
            NavigationService.Navigate(new Uri(uri, UriKind.Relative));
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Terminate();
        }
    }
}