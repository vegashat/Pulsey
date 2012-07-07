using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignalR.Hubs;
using System.Threading.Tasks;
namespace Pulsey.Web.SignalR
{
    public class PulseyHub : Hub, IConnected, IDisconnect
    {





        public Task Connect()
        {
            return Clients.notifyClient("new connection established for " + Context.ConnectionId);
        }

        public Task Reconnect(IEnumerable<string> groups)
        {
            return Clients.notifyClient("connection re-established for " + Context.ConnectionId);
        }

        public Task Disconnect()
        {
            // Tell everyone this connection is gone
            return Clients.notifyLeave(Context.ConnectionId);
        }

        public void Send(string message)
        {

            Clients.addMessage(message);

        }


    }
}