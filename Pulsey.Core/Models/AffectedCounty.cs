using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulsey.Core.Models
{
    public class AffectedCounty
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public DateTime OnsetTime { get; set; }
        public DateTime ExpiresTime { get; set; }
        public string County { get; set; }
    }
}
