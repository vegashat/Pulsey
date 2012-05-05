using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulsey.Core.Repositories
{
    public class BaseRepository
    {
        static string _connectionString = null;
        public BaseRepository(string connectionString = "")
        {
            if (!string.IsNullOrEmpty(connectionString))
            {
                _connectionString = connectionString;
            }
        }

        public static PulseyContext GetContext()
        {
            return new PulseyContext(_connectionString);
        }
    }
}
