using AuditBenchmarkModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditBenchmarkModule.Repository
{
    public class BenchmarkRepo : IBenchmarkRepo
    {
        private readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(BenchmarkRepo));
        private static List<AuditBenchmark> AuditBenchmarkList = new List<AuditBenchmark>()
        {
            new AuditBenchmark
            {
                auditType="Internal",
                benchmarkNoAnswers=3
            },
            new AuditBenchmark
            {
                auditType="SOX",
                benchmarkNoAnswers=1
            }
        };
        public List<AuditBenchmark> GetNolist()
        {
            _log4net.Info(" Http GET request " + nameof(BenchmarkRepo));
            List<AuditBenchmark> listOfCriteria = new List<AuditBenchmark>();
            try
            {
                listOfCriteria = AuditBenchmarkList;
                return listOfCriteria;
            }
            catch (Exception e)
            {
                _log4net.Error(" Exception here" + e.Message + " " + nameof(BenchmarkRepo));
                return null;
            }

        }
    }
}
