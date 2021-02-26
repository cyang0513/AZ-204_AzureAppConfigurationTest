using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureAppConfigurationTest
{
   public class Program
   {
      public static void Main(string[] args)
      {
         CreateHostBuilder(args).Build().Run();
      }

      public static IHostBuilder CreateHostBuilder(string[] args) =>
          Host.CreateDefaultBuilder(args)
              .ConfigureWebHostDefaults(webBuilder =>
                                        {
                                           webBuilder.ConfigureAppConfiguration(builder =>
                                                                                {
                                                                                   var config = builder.Build();
                                                                                   builder.AddAzureAppConfiguration(
                                                                                      az =>
                                                                                      {
                                                                                         az.Connect(
                                                                                            config.GetConnectionString(
                                                                                               "AppConfig"));
                                                                                         az.ConfigureRefresh(rf =>
                                                                                                             {
                                                                                                                rf.Register("CHYA:WebApp:Dynamic:Signal",true);
                                                                                                                rf.SetCacheExpiration(new TimeSpan(0, 5,0));
                                                                                                             });

                                                                                         //Setup feature
                                                                                         az.UseFeatureFlags();
                                                                                      });
                                                                                });
                                           webBuilder.UseStartup<Startup>();

                                        });
   }
}

