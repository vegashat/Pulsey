using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

using Pulsey.Core.Models;

namespace Pulsey.Core.Repositories
{
    public class PulseyContext : DbContext
    {
        public PulseyContext() : base(ConfigurationManager.ConnectionStrings["Pulsey"].ConnectionString)
        {
        }

        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupUser> UserGroups { get; set; }
        public DbSet<AffectedCounty> AffectedCounties { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new GroupUserMap());
        }

        public class GroupUserMap : EntityTypeConfiguration<GroupUser>
        {
            public GroupUserMap()
            {
                HasKey(g => g.UserId).Property(g => g.UserId).HasColumnOrder(0);
                HasKey(g => g.GroupId).Property(g => g.GroupId).HasColumnName("GroupId").HasColumnOrder(1);

            }
        }
    }
}
