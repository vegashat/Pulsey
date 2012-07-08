using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pulsey.Core.Models;

namespace Pulsey.Web.Repository
{
    public interface IUserRepository
    {
        User GetUserByEmail(string email);
    }
}
