using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsey.Core.Models
{
    public class Event
    {
        public int Id { get; set; }
        public EventType Type { get; set; }
        public DateTime EffectiveDateTime { get; set; }
        public string Alias { get; set; }
        public string DefaultMessage { get; set; }
    }
}
