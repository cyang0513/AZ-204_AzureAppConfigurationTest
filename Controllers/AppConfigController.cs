using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.FeatureManagement.Mvc;

namespace AzureAppConfigurationTest.Controllers
{
   [ApiController]
   [Route("[controller]")]
   public class AppConfigController : Controller
   {
      readonly ILogger<string> m_Logger;
      readonly Dynamic m_DynamicConfig;

      /// <summary>
      /// Option pattern to inject mapped config option, using IOptionsSnapshot or IOptionsMonitor
      /// IOption only return static data, wont refresh
      /// </summary>
      public AppConfigController(ILogger<string> logger, IOptionsSnapshot<Dynamic> option)
      {
         m_Logger = logger;
         m_DynamicConfig = option.Value;
         m_Logger.Log(LogLevel.Information, m_DynamicConfig.Msg);
      }

      [HttpGet]
      public string GetResult()
      {
         return m_DynamicConfig.Msg;
      }
   }
}
