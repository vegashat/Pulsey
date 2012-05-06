using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Pulsey.Web.Api.Models
{
    public class PulseyIdentity : IIdentity
    {
        private System.Web.Security.FormsAuthenticationTicket ticket;

        public PulseyIdentity(System.Web.Security.FormsAuthenticationTicket ticket)
        {
            this.ticket = ticket;
        }

        public string AuthenticationType
        {
            get { return "Pulsey"; }
        }

        public bool IsAuthenticated
        {
            get { return true; }
        }

        public string Name
        {
            get
            {
                return ticket.Name;
            }
        }

        public int Id
        {
            get
            {
                return Convert.ToInt32(ticket.UserData.Split(';')[0]);
            }
        }
        public string FriendlyName
        {
            get
            {
                return ticket.UserData.Split(';')[1];
            }
        }
        public string EmailAddress
        {
            get
            {
                return ticket.UserData.Split(';')[2];
            }
        }

        public static PulseyIdentity Current
        {
            get
            {
                return HttpContext.Current.User.Identity as PulseyIdentity;
            }
        }
    }
}