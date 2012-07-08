using System.Data.Entity.Migrations;

using Pulsey.Core.Repositories;

namespace Pulsey.Core.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<PulseyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PulseyContext context)
        {
            //  This method will be called after migrating to the latest version.
        }
    }
}
