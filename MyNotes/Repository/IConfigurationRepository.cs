using MyNotes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotes.Repository
{
    public interface IConfigurationRepository
    {
        Configuration GetConfiguration();
        
        Configuration SaveConfiguration(Configuration configuration);
    }
}
