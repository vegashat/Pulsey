using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pulsey.Core.Models;

namespace Pulsey.Web.Repository
{
    public class UserRepository
    {
        public User GetUserByEmail(string email)
        {
            using (var context = new PulseyContext())
            {
                return context.Users.FirstOrDefault(a => a.Email == email);
            }
        }
    }
}