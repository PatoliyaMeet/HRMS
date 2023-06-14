using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IJWTRepository
    {
        Tokens Authenticate(string email,string password);
    }
}
