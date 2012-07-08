﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulsey.Core.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<GroupUser> Members { get; set; }
    }
}