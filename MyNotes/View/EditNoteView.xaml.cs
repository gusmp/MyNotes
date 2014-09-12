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
    public partial class EditNoteView : BaseView
    {
        public EditNoteView()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string noteId = NavigationContext.QueryString["noteId"];
            var vm = this.DataContext as EditNoteViewModel;
            if (vm != null)
            {
                vm.InitializeCommand.Execute(noteId);
            }
        }

        private void ApplicationBarIconBackButton_Click(object sender, EventArgs e)
        {
            GoBack();
        }

        private void ApplicationBarIconSaveButton_Click(object sender, EventArgs e)
        {
            var vm = this.DataContext as EditNoteViewModel;
            if (vm != null)
            {
                Note n = new Note();
                n.Id = (int)this.TitleTb.Tag;
                n.Title = this.TitleTb.Text;
                n.Content = this.ContentTb.Text;
                vm.SaveNoteCommand.Execute(n);
            }
            GoBack();
        }
    }
}