using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuditSeverityModule.Models;
using AuditSeverityModule.Providers;
using AuditSeverityModule.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuditSeverityModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditSeverityController : ControllerBase
    {
        private readonly ISeverityProvider _severityProvider;
        public readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AuditSeverityController));
        public AuditSeverityController(ISeverityProvider severityProvider)
        {
            _severityProvider = severityProvider;
        }

        [HttpGet]
        public IActionResult ProjectExecutionStatus()
        {
            _log4net.Info(" Http GET Request From: " + nameof(AuditSeverityController));
            return Ok("SUCCESS");
        }



        [HttpPost]
        public IActionResult ProjectExecutionStatus([FromBody] AuditRequest req)
        {
            _log4net.Info(" Http POST Request From: " + nameof(AuditSeverityController));

            if (req == null)
                return BadRequest();

            if (req.Auditdetails.Type != "Internal" && req.Auditdetails.Type != "SOX")
                return BadRequest("Wrong Audit Type");

            try
            {
                AuditResponse response = _severityProvider.SeverityResponse(req);
                return Ok(response);
            }
            catch (Exception e)
            {
                _log4net.Error(e.Message);  
                return StatusCode(500);
            }

        }


    }
}
//For Postman test
//{
//    "ProjectName": "Audit Management",
//    "ProjectManagerName": "Sayan",
//    "ApplicationOwnerName": "Arpan",
//    "Auditdetails": 
//    {
//        "Type": "Internal",
//        "Date": "12/11/2005",
//        "questions": 
//        {
//            "Question1": true,
//            "Question2": true,
//            "Question3": false,
//            "Question4": false,
//            "Question5": false
//        }
//    }
//}