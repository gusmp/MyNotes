using MyNotes.Model;
using MyNotes.Repository;
using MyNotes.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotes.Service.Impl
{
    public class ConfigurationServiceImpl : IConfigurationService
    {
        private IConfigurationRepository ConfigurationRepository;

        public ConfigurationServiceImpl(IConfigurationRepository configurationRepository)
        {
            this.ConfigurationRepository = configurationRepository;
        }

        public Configuration GetConfiguration()
        {
            return this.ConfigurationRepository.GetConfiguration();
        }

        public void SaveConfiguration(Configuration configuration)
        {
            this.ConfigurationRepository.SaveConfiguration(configuration);
        }


        public void UpdatePassword(string newPassword)
        {
            Configuration c = this.ConfigurationRepository.GetConfiguration();
            c.SetPassword(newPassword);
            this.ConfigurationRepository.SaveConfiguration(c);
        }
    }
}
