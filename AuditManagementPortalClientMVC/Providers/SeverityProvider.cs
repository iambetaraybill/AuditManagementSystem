using AuditManagementPortalClientMVC.Models;
using AuditManagementPortalClientMVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditManagementPortalClientMVC.Providers
{
    public class SeverityProvider : ISeverityProvider
    {
        private readonly ISeverityRepo _severityRepo;

        public SeverityProvider(ISeverityRepo severityRepo)
        {
            _severityRepo = severityRepo;
        }
        public AuditResponse GetResponse(AuditRequest auditRequest)
        {
            AuditResponse auditResponse = new AuditResponse();
            auditResponse = _severityRepo.GetResponse(auditRequest);
            return auditResponse;
            //throw new NotImplementedException();
        }
        public void StoreResponse(StoreAuditResponse auditResponse)
        {
            _severityRepo.StoreResponse(auditResponse);
        }


    }
}
