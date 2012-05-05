using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulsey.Core.Models
{
    public class GroupUser
    {
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public bool IsAdmin { get; set; }

        public virtual Group Group { get; set; }
    }
}
