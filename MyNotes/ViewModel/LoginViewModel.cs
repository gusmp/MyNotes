using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MyNotes.Exception;
using MyNotes.Message;
using MyNotes.Model;
using MyNotes.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyNotes.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {

        private Login _login;
        public Login Login
        {
            get
            {
                return _login;
            }
            set 
            {
                Set("Login", ref _login, value);
            }
        }

        private ILoginService LoginService;

        public LoginViewModel(ILoginService LoginService)
        {
            this.LoginService = LoginService;
            this.Login = new Login();
            ValidateLoginCommand = new RelayCommand(ValidateLogin);
        }

        public ICommand ValidateLoginCommand { get; private set; }

        private void ValidateLogin()
        {
            try
            {
                this.LoginService.ValidateLogin(this.Login);
                Messenger.Default.Send<LoginMessage>(new LoginMessage() { LoginSuccessful = true });
            }
            catch (LoginException)
            {
                Messenger.Default.Send<LoginMessage>(new LoginMessage() { LoginSuccessful = false });
            }
        }
    }
}
