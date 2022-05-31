using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace FlighBooking
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHostBuilder builder = new WebHostBuilder();
            builder.ConfigureServices(s =>
            {
                s.AddSingleton(builder);
            });
            builder.UseKestrel()
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseStartup<Startup>()
                    .UseUrls("http://localhost:7000");
            var host = builder.Build();
            host.Run();
        }
    }
}
