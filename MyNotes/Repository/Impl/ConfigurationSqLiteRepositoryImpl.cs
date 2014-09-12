
using MyNotes.Model;
using MyNotes.Utils;
using System.Linq;

namespace MyNotes.Repository.Impl
{
    public class ConfigurationSqLiteRepositoryImpl : SqLiteBaseRepository, IConfigurationRepository
    {

        public Configuration GetConfiguration()
        {
            Configuration configuration = GetConnection().Table<Configuration>().OrderBy(x => x.Id).SingleOrDefault();
            if (configuration == null)
            { 
                Configuration c = new Configuration();
                c.SetPassword("1234");
                configuration = SaveConfiguration(c);
            }
            return configuration;
        }

        public Configuration SaveConfiguration(Configuration configuration)
        {
            configuration.Password = CryptoUtils.GetSha1(configuration.Password);
            return (Configuration)this.SaveOrUpdate(configuration);
        }
    }
}
