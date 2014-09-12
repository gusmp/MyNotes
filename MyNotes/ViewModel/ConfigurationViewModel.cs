using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MyNotes.Model;
using MyNotes.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyNotes.ViewModel
{
    public class ConfigurationViewModel : ViewModelBase
    {
        private IConfigurationService ConfigurationService;

        public ConfigurationViewModel(IConfigurationService ConfigurationService)
        {
            this.ConfigurationService = ConfigurationService;
            UpdatePasswordCommand = new RelayCommand<string>(UpdatePassword);
        }

        public ICommand UpdatePasswordCommand { get; private set; }

        private void UpdatePassword(string newPassword)
        {
            this.ConfigurationService.UpdatePassword(newPassword);
        }

    }
}
