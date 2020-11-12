﻿using AuditManagementPortalClientMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditManagementPortalClientMVC.Repository
{
    public interface ISeverityRepo
    {
        public AuditResponse GetResponse(AuditRequest auditRequest);
        public void StoreResponse(StoreAuditResponse auditResponse);
    }
}
