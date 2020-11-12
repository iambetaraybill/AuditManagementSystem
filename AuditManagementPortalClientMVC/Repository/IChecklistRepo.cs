using AuditManagementPortalClientMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditManagementPortalClientMVC.Repository
{
    public interface IChecklistRepo
    {
        public List<CQuestions> ProvideChecklist(string audittype);
    }
}
