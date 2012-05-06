using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pulsey.Core.Models;

namespace Pulsey.Web.Viewmodels
{
    public class GroupViewModel
    {
        public GroupViewModel(Group group, ICollection<GroupUser> userList)
        {
            Group = group;
            UserList = userList;

            if (Group == null)
            {
                Group = new Group();
            }
        }

        public Group Group { get; set; }
        public ICollection<GroupUser> UserList { get; set; }
    }
}