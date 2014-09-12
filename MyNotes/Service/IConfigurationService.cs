using MyNotes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotes.Service
{
    public interface IConfigurationService
    {
        Configuration GetConfiguration();
        void SaveConfiguration(Configuration configuration);

        void UpdatePassword(string newPassword);

    }
}
