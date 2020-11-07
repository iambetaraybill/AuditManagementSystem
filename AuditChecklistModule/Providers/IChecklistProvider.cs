using AuditChecklistModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditChecklistModule.Providers
{
    public interface IChecklistProvider
    {
        public List<Questions> QuestionsProvider(string auditType);
    }
}
