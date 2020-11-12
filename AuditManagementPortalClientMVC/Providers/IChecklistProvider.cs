using AuditManagementPortalClientMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditManagementPortalClientMVC.Providers
{
    public interface IChecklistProvider
    {
        public List<CQuestions> ProvideChecklist(string audittype);
    }
}
