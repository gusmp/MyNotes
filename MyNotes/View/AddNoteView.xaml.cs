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
using MyNotes.Model;

namespace MyNotes.View
{
    public partial class AddNoteView : BaseView
    {
        public AddNoteView()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var vm = this.DataContext as AddNoteViewModel;
            if (vm != null)
            {
                vm.InitializeCommand.Execute(null);
            }
        }

        private void ApplicationBarIconBackButton_Click(object sender, EventArgs e)
        {
            GoBack();
        }

        private void ApplicationBarIconSaveButton_Click(object sender, EventArgs e)
        {
            var vm = DataContext as AddNoteViewModel;
            if (vm != null)
            {
                Note n = new Note();
                n.Title = this.TitleTb.Text;
                n.Content = this.ContentTb.Text;
                vm.AddNoteCommand.Execute(n);
            }
            GoBack();
        }
    }
}