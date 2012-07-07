using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pulsey.Core.Models;

namespace Pulsey.Core.Repositories
{
    public class UserRepository : BaseRepository
    {
        public ICollection<User> Get()
        {
            using (var context = GetContext())
            {
                return context.Users.ToList();
            }
        }

        public User GetUserInfo(int userId)
        {
            using (var context = GetContext())
            {
                return context.Users.Include("GroupUser").Include("Group").FirstOrDefault(a => a.Id == userId);
            }
        }

        public IEnumerable<GroupUser> GetUserGroups(int userId)
        {
            try
            {
                using (var context = GetContext())
                {
                    return context.UserGroups.Include("Group").Where(a => a.UserId == userId).ToList();
                }
            }
            catch (Exception ex)
            {
                var mess = ex.Message;
                return null;
            }
        }

        public User GetUserByEmail(string email)
        {
            using (var context = new PulseyContext())
            {
                return context.Users.FirstOrDefault(a => a.Email == email);
            }
        }

        public bool InsertUserProfile(User objUser)
        {
            using (var context = new PulseyContext())
            {
                context.Users.Add(objUser);
                context.SaveChanges();
            }
            return true;
        }
        public bool UpdateUserProfile(User objUser)
        {
            using (var context = new PulseyContext())
            {
                context.Entry<User>(objUser).State = EntityState.Modified;
                context.SaveChanges();
            }
            return true;
        }
    }
}
