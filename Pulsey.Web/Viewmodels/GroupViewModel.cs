using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pulsey.Core.Models;

namespace Pulsey.Web.Viewmodels
{
    public class GroupViewModel
    {
        public GroupViewModel(Group group, ICollection<User> currentUsers, ICollection<User> allUsers)
        {
            Group = group;
            CurrentUsers = currentUsers;
            AllUsers = allUsers;

            if (Group == null)
            {
                Group = new Group();
            }
        }

        public Group Group { get; set; }
        public ICollection<User> CurrentUsers { get; set; }
        public ICollection<User> AllUsers { get; set; }

        ICollection<SelectListItem> _users = null;
        public ICollection<SelectListItem> UserList
        {
            get
            {
                if (_users == null)
                {
                    _users = new List<SelectListItem>();

                    foreach (var user in AllUsers)
                    {
                        _users.Add(new SelectListItem() { Text = user.FullName, Value = user.Id.ToString() });
                    }
                }

                return _users;
            }
        }
    }
}