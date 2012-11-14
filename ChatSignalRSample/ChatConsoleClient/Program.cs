using Microsoft.AspNet.SignalR.Client.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatConsoleClient {

    class Program {

        static void Main(string[] args) {

            RunAsync().Wait();
        }

        private static async Task RunAsync() {

            var url = "http://localhost:63670/";
            var connection = new HubConnection(url);
            IHubProxy chat = connection.CreateHubProxy("ChatHub");

            chat.On<string>("received", msg => Console.WriteLine(msg));

            await connection.Start();

            string line = null;
            while ((line = Console.ReadLine()) != null) {
                await chat.Invoke("send", "Console: " + line);
            }
        }
    }
}