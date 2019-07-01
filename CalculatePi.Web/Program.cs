using System;
using System.Net;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography.X509Certificates;

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
            var config = new ConfigurationBuilder()
                .SetBasePath("/home/www-user/calculatepi/")
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile($"appsettings.{environment}.json", optional: false)
                .AddEnvironmentVariables()
                .Build();

            System.Console.WriteLine($"Environment = {environment}");

            var webHost = WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseKestrel()
                //.UseKestrel(options =>
                //{
                //    options.Listen(IPAddress.Loopback, 5001, listenOptions =>
                //    {
                //        var certificateSettings = config.GetSection("certificate");
                //        var certificateFileName = certificateSettings.GetValue<string>("filename");
                //        var certificatePassword = certificateSettings.GetValue<string>("password");
                //        var cert = new X509Certificate2(certificateFileName, certificatePassword);

                //        listenOptions.UseHttps(cert);

                //    });
                //})
                .PreferHostingUrls(true)
                .Build();
            return webHost;
        }
    }
}
