using AuditManagementPortalClientMVC.Models;
using AuditManagementPortalClientMVC.Models.Context;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AuditManagementPortalClientMVC.Repository
{
    public class SeverityRepo : ISeverityRepo
    {
        private readonly AuditDbContext _auditDbContext;

        public SeverityRepo(AuditDbContext auditDbContext)
        {
            _auditDbContext = auditDbContext;
        }
        public AuditResponse GetResponse(AuditRequest auditRequest)
        {
            AuditResponse auditResponse = new AuditResponse();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(auditRequest), Encoding.UTF8, "application/json");

                HttpResponseMessage response = httpClient.PostAsync("https://localhost:44303/api/AuditSeverity", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    auditResponse = JsonConvert.DeserializeObject<AuditResponse>(result);
                }

            }
            return auditResponse;
            //throw new NotImplementedException();
        }

        public void StoreResponse(StoreAuditResponse auditResponse) 
        {
            _auditDbContext.storeAuditResponses.Add(auditResponse);
            _auditDbContext.SaveChanges();

        }

    }
}
