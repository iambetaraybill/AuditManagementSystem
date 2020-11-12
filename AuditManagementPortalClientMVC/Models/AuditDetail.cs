using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditManagementPortalClientMVC.Models
{
    public class AuditDetail
    {
        public string Type { get; set; }
     
        public string Date { get; set; }
        public Questions questions { get; set; }

    }
}
