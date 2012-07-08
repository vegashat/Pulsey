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
        public DbSet<AffectedCounty> AffectedCounties { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GroupMap());
            
            base.OnModelCreating(modelBuilder);
        }

        public class GroupMap : EntityTypeConfiguration<Group>
        {
            public GroupMap()
            {
                HasMany<User>(g => g.Members).WithMany(u => u.Groups).Map(m => m.MapLeftKey("GroupId").MapRightKey("UserId").ToTable("GroupUsers"));
                //HasMany<User>(g => g.Administrators).WithMany(u => u.Groups).Map(m => m.MapLeftKey("GroupId").MapRightKey("UserId").ToTable("GroupAdmins"));

            }
        }

        public class UserMap : EntityTypeConfiguration<User>
        {
            public UserMap()
            {
                HasMany<Group>(u => u.Groups).WithMany(g => g.Members);

            }
        }

    }
}
