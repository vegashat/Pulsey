using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pulsey.Core.Models;

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
    }
}
  