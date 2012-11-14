using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hosting.AspNet;
using RawConnSample.Chat;

[assembly: PreApplicationStartMethod(typeof(RawConnSample.RegisterHubs), "Start")]

namespace RawConnSample
{
    public static class RegisterHubs
    {
        public static void Start()
        {
            // Register the default hubs route: ~/signalr/hubs
            RouteTable.Routes.MapConnection<ChatConnection>("Chat", "chat/{*operation}");
        }
    }
}