using GalaSoft.MvvmLight;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotes.Model
{
    public abstract class BaseModel : ObservableObject
    {
        //public int? Id { get; set; }

        private int? _id;

        [PrimaryKey, AutoIncrement]
        public int? Id
        {
            get 
            {
                return _id;
            }
            set
            {
                Set("Id", ref _id, value);
            }
        }
    }
}
