using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pulsey.Core.Models;

namespace Pulsey.Core.Repositories
{
    public class UserRepository : BaseRepository
    {
        public User GetUserInfo(int userId)
        {
            using (var context = GetContext())
            {
                return context.Users.FirstOrDefault(a => a.Id == userId);
            }
        }

        public IEnumerable<GroupUser> GetUserGroups(int userId)
        {
            using (var context = GetContext())
            {
                return context.UserGroups.Include("Group").Where(a => a.UserId == userId).ToList();
            }
        }
    }
}
