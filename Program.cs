using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy.Hosting.Self;

namespace CoreNancySelfHostedNet
{
    class Program
    {
        static void Main(string[] args)
        {
            var hostConfigs = new HostConfiguration
            {
                UrlReservations = new UrlReservations()
                {
                    CreateAutomatically = true
                }
            };

            Uri uri = new Uri("http://localhost:1234");

            using (var host = new NancyHost(hostConfigs, uri))
            {
                host.Start();
                Console.WriteLine("Running on http://localhost:1234");
                Console.ReadLine();
            }
        }
    }
}
