using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Pulsey.Core.Models
{
    public class GroupUser
    {
        [Key, Column(Order=0)]
        public int UserId { get; set; }
        [Key, Column(Order = 1)]
        public int GroupId { get; set; }
        public bool IsAdmin { get; set; }

        public virtual User User { get; set; }
        public virtual Group Group { get; set; }
    }
}
