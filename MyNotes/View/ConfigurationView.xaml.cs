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
    public partial class ConfigurationView : BaseView
    {
        public ConfigurationView()
        {
            InitializeComponent();
        }

        private void ApplicationBarIconBackButton_Click(object sender, EventArgs e)
        {
            GoBack();
        }

        private void ApplicationBarIconSaveButton_Click(object sender, EventArgs e)
        {
            var vm = DataContext as ConfigurationViewModel;
            if (vm != null)
            {
                vm.UpdatePasswordCommand.Execute(this.PasswordTb.Password);
            }
            GoBack();
        }
    }
}