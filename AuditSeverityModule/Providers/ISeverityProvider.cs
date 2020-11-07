using AuditSeverityModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditSeverityModule.Providers
{
    public interface ISeverityProvider
    {
        public AuditResponse SeverityResponse(AuditRequest Req);

    }
}
