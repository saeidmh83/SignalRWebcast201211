using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace RawConnSample.Chat {
    
    public class ChatConnection : PersistentConnection {

        protected override Task OnReceivedAsync(
            IRequest request, string connectionId, string data) {

            return Connection.Broadcast(data);
        }
    }
}