using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace CalculatePi.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHost(args).Run();
        }

        public static IWebHost CreateWebHost(string[] args)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var webHost = WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseKestrel()
                .PreferHostingUrls(true)
                .Build();
            return webHost;
        }
    }
}
