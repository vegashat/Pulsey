  using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Pulsey.Core.Models;

namespace Pulsey.Core.Repositories
{
    public class PulseyContext : BaseContext
    {
        public PulseyContext(string connectionString = "") : base(connectionString)
        {
        }

        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Event> Events { get; set; }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<AffectedCounty> AffectedCounties { get; set; }
    }
}
