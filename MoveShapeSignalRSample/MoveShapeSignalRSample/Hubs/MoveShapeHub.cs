using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoveShapeSignalRSample.Hubs {
    
    [HubName("moveShape")]
    public class MoveShapeHub : Hub {

        public void MoveShape(int x, int y) {

            Clients.Others.shapeMoved(x, y);
        }
    }
}