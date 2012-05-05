using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulsey.Core.Repositories
{
    public class BaseRepository
    {
        public static PulseyContext GetContext()
        {
            return new PulseyContext();
        }
    }
}
