using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace Pulsey.Core.Repositories
{
    public abstract class BaseContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Configuration.ProxyCreationEnabled = false;
        }
    }
}
