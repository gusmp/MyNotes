using MyNotes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotes.Service
{
    public interface ILoginService
    {
        bool ValidateLogin(Login login);
    }
}
