using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pulsey.Core.Models;
using System.Data.Entity;

namespace Pulsey.Core.Repositories
{
    public class GroupRepository : BaseRepository
    {
        public ICollection<Group> Get()
        {
            using (var context = GetContext())
            {
                return context.Groups.ToList();
            }
        }

        public Group Get(int groupId)
        {
            using (var context = GetContext())
            {
                return context.Groups.FirstOrDefault(g => g.Id == groupId);
            }
        }
          
        public Group Save(Group group)
        {
            using (var context = GetContext())
            {
                if (group.Id == 0)
                {
                    context.Entry<Group>(group).State = System.Data.EntityState.Added;
                }
                else
                {
                    context.Entry<Group>(group).State = System.Data.EntityState.Modified;
                }

                context.SaveChanges();

                return group;
            }

        }

        public ICollection<GroupUser> GetGroupUsers(int groupId)
        {
            using (var context = GetContext())
            {
                return context.UserGroups
                    .Include(g =>g.Group)
                    .Include(g =>g.User)
                    .Where(ug => ug.GroupId == groupId).ToList();
            }

            
        }

        public GroupUser SaveGroupUser(GroupUser groupUser)
        {
            using (var context = GetContext())
            {
                context.Entry<GroupUser>(groupUser).State = System.Data.EntityState.Added;
                
                context.SaveChanges();

                return groupUser;
            }
        }
    }
}
  