using MyNotes.Exception;
using MyNotes.Model;
using MyNotes.Utils;
using System.Linq;

namespace MyNotes.Service.Impl
{
    public class LoginServiceImpl : ILoginService
    {
        private IConfigurationService ConfigurationService;

        public LoginServiceImpl(IConfigurationService configurationService)
        {
            this.ConfigurationService = configurationService;
        }

        public bool ValidateLogin(Login login)
        {
            byte[] shaPassword = CryptoUtils.GetSha1(login.Password);

            if (shaPassword.SequenceEqual(this.ConfigurationService.GetConfiguration().Password) == false)
            {
                throw new LoginException();
            }

            return true;
        }
    }
}
