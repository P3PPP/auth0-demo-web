using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace SampleMvcApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var builder = WebHost.CreateDefaultBuilder(args);

            builder.ConfigureAppConfiguration((hostingContext, config) =>
            {
                var settings = config.Build();
                
                var connection = settings.GetConnectionString("AppConfig");
                if (!string.IsNullOrEmpty(connection))
                {
                    config.AddAzureAppConfiguration(connection);
                }
            });
            
            return builder.UseStartup<Startup>();
        }
    }
}
