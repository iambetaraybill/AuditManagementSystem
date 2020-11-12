using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditManagementPortalClientMVC.Repository
{
    public interface ILoginRepo
    {
        public  Task<string> GetToken();
    }
}
