using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatSignalRSample.Chat {

    public class ChatHub : Hub {

        public void Send(string message) {

            Clients.All.received(string.Format("{0} (from {1})", message, Environment.MachineName));
        }

        public void Echo(string message) {

            Clients.Caller.received(string.Format("{0} (from {1})", message, Environment.MachineName));
        }
    }
}