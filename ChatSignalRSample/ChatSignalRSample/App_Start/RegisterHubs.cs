using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hosting.AspNet;
using Microsoft.AspNet.SignalR.Redis;
using System.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[assembly: PreApplicationStartMethod(typeof(ChatSignalRSample.RegisterHubs), "Start")]

namespace ChatSignalRSample
{
    public static class RegisterHubs
    {
        public static void Start()
        {
            // Register the default hubs route: ~/signalr/hubs
            RouteTable.Routes.MapHubs();

            // Hook up redis
            string server = ConfigurationManager.AppSettings["redis.server"];
            string port = ConfigurationManager.AppSettings["redis.port"];
            string password = ConfigurationManager.AppSettings["redis.password"];

            GlobalHost.DependencyResolver.UseRedis(server, Int32.Parse(port), password, new[] { "ChatSignalRSample" });
        }
    }
}