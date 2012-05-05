using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Pulsey.Core.Models;

namespace Pulsey.Core.Repositories
{
    public class PulseyContext : DbContext
    {
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }


    }
}
