using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using Serilog;
using System.Diagnostics.CodeAnalysis;

namespace BookCartAPI
{
    [ExcludeFromCodeCoverage]
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                  .Enrich.FromLogContext()
                   .WriteTo.Console(Serilog.Events.LogEventLevel.Information)
                  .WriteTo.Debug(Serilog.Events.LogEventLevel.Information)
                  .WriteTo.File("Log.txt",rollingInterval:RollingInterval.Day)
                  .CreateLogger();
            try
            {
                Log.Information("Starting Web Host");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal("Host terminated unexpectedly");
                throw ex;
            }
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
          .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {

                    webBuilder.UseStartup<Startup>();
                });

    }
}
