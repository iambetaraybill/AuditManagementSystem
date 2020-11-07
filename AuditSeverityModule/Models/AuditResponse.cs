using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditSeverityModule.Models
{
    public class AuditResponse
    {
        public int AuditId { get; set; }
        public string ProjectExexutionStatus { get; set; }
        public string RemedialActionDuration { get; set; }
    }
}
