using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NATA.Data;

namespace NATA
{
    public class Program
    {
        public static async Task  Main(string[] args)
        {
            var host=CreateHostBuilder(args).Build();
           // using var scope=host.Services.CreateScope();
           try
           {
              using  var context=host.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>();
                await context.Database.MigrateAsync();
                await Seed.SeedUsers(context);
                
           }
           catch(Exception ex)
           {
               var logger=host.Services.GetRequiredService<Logger<Program>>();
               logger.LogError(ex,"An error occurred during migration");
           }
                 await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
