using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.FeatureManagement.Mvc;

namespace AzureAppConfigurationTest.Controllers
{
   [ApiController]
   [Route("[controller]")]
   public class FeatureConfigController : Controller
   {
      /// <summary>
      /// Feature gate to map to the feature flag in app config to decide if enable the feature or not
      /// </summary>
      [HttpGet]
      [FeatureGate("CHYAFeature")]
      public string Index()
      {
         return "This is the CHYAFeature";
      }
   }
}
