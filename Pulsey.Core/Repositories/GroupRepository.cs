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
    }
}
