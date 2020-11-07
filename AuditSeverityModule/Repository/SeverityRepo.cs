using AuditSeverityModule.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AuditSeverityModule.Repository
{
    public class SeverityRepo : ISeverityRepo
    {
        Uri baseAddress;
        HttpClient client;
        //IConfiguration config;
        public readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(SeverityRepo));

        public SeverityRepo()//IConfiguration configuration
        {
            //config = configuration;
            //baseAddress = new Uri(config["Links:Benchmark"]);
            client = new HttpClient();
            //client.BaseAddress = "https://localhost:44397/api";//baseAddress;
        }

        public List<AuditBenchmark> Response()
        {
            _log4net.Info(" Response Method of SeverityRepo Called ");
            try 
            {
                
                List<AuditBenchmark> listFromAuditBenchmark = new List<AuditBenchmark>();
                HttpResponseMessage response = client.GetAsync("https://localhost:44397/api" + "/AuditBenchmark").Result; //client.BaseAddress
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    listFromAuditBenchmark = JsonConvert.DeserializeObject<List<AuditBenchmark>>(data);
                }
                return listFromAuditBenchmark;

            }
            catch(Exception ey)
            {
                _log4net.Error(ey.Message);
                return null;
            }
    
        }

        public static List<AuditResponse> ActionToTakeAndStatus = new List<AuditResponse>()
        {
            new AuditResponse
            {
                RemedialActionDuration="No Action Needed",
                ProjectExexutionStatus="GREEN"
            },
            new AuditResponse
            {
                RemedialActionDuration="Action to be taken in 2 weeks",
                ProjectExexutionStatus="RED"
            },
            new AuditResponse
            {
                RemedialActionDuration = "Action to be taken in 1 week",
                 ProjectExexutionStatus="RED"
            }
        };

    }
}
