using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuditBenchmarkModule.Models;
using AuditBenchmarkModule.Providers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuditBenchmarkModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditBenchmarkController : ControllerBase
    {
        private readonly log4net.ILog _log4net;
        private readonly IBenchmarkProvider objProvider;
        public AuditBenchmarkController(IBenchmarkProvider _objProvider)
        {
            _log4net = log4net.LogManager.GetLogger(typeof(AuditBenchmarkController));
            objProvider = _objProvider;
        }


        [HttpGet]
        public IActionResult AuditBenchmark()
        {
            List<AuditBenchmark> listOfProvider = new List<AuditBenchmark>();
            _log4net.Info(" Http GET request " + nameof(AuditBenchmarkController));
            try
            {
                listOfProvider = objProvider.GetBenchmark();
                return Ok(listOfProvider);
            }
            catch (Exception e)
            {
                _log4net.Error(" Exception here" + e.Message + " " + nameof(AuditBenchmarkController));
                return StatusCode(500);
            }
        }
    }
}
