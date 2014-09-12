using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotes.Model
{
    public class Login : BaseModel
    {
        private string _password;

        public string Password 
        {
            get
            {
                return _password;
            }
            set
            {
                Set("Password", ref _password, value);
            }
        }
    }
}
