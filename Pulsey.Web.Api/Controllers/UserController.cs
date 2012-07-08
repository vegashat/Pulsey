using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Pulsey.Core.Models;
using Pulsey.Core.Repositories;

namespace Pulsey.Web.Api.Controllers
{
    public class UserController : ApiController
    {
        [HttpPost]
        public User Login()
        {
            return null;
        }

        public User GetUserInfo(int userId)
        {
            return (new UserRepository()).GetUserInfo(userId);
        }

        //public IEnumerable<User> GetUserGroups(int userId)
        //{
        //    return (new UserRepository()).GetUserGroups(userId);
        //}
    }
}
