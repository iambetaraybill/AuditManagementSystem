using AuditManagementPortalClientMVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AuditManagementPortalClientMVC.Repository
{
    public class ChecklistRepo : IChecklistRepo
    {
        public List<CQuestions> ProvideChecklist(string audittype)
        {

            HttpClient client = new HttpClient();
            var json = JsonConvert.SerializeObject(audittype);
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://localhost:44310/api/AuditChecklist"),

                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            List<CQuestions> listOfQuestions = new List<CQuestions>();
            var response = client.SendAsync(request).ConfigureAwait(false);

            var responseInfo = response.GetAwaiter().GetResult();
            if (responseInfo.IsSuccessStatusCode)
            {
                var questions = responseInfo.Content.ReadAsStringAsync().Result;
                listOfQuestions = JsonConvert.DeserializeObject<List<CQuestions>>(questions);
            }
            return listOfQuestions;
            //throw new NotImplementedException();
        }
    }
}
