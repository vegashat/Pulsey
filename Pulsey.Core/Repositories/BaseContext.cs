using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Configuration;

namespace Pulsey.Core.Repositories
{
    public abstract class BaseContext : DbContext
    {
        string _connectionString;

        public BaseContext(string connectionString = "")
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = ConfigurationManager.ConnectionStrings["pulsey"].ConnectionString;
            }
            else
            {
                Database.Connection.ConnectionString = connectionString;
            }

            _connectionString = connectionString;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Configuration.ProxyCreationEnabled = false;
        }
    }
}
