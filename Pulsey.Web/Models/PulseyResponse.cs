using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pulsey.Web.Models
{
    public class PulseyResponse
    {
        public bool Success { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
    }
}