using MyNotes.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace MyNotes.Repository.Impl
{
    public abstract class SqLiteBaseRepository : IDisposable
    {
        private SQLiteConnection Connection = null;
        private static string DB_PATH = Path.Combine(Path.Combine(ApplicationData.Current.LocalFolder.Path, "MyNotes.db"));

        public SqLiteBaseRepository()
        {
            GetConnection();
        }

        protected virtual SQLiteConnection GetConnection()
        { 
            if (this.Connection == null)
            {
                this.Connection = new SQLiteConnection(SqLiteBaseRepository.DB_PATH);
                this.Connection.CreateTable<Configuration>();
            }

            return this.Connection;
        }

        protected virtual BaseModel SaveOrUpdate(BaseModel model)
        {
            if (model.Id == null)
            {
                GetConnection().Insert(model);
            }
            else 
            {
                GetConnection().Update(model);
            }

            return model;
        }

        public void Dispose()
        {
            this.Connection.Close();
        }
    }
}
