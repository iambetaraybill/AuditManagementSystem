using AuditBenchmarkModule.Models;
using AuditBenchmarkModule.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditBenchmarkModule.Providers
{
    public class BenchmarkProvider : IBenchmarkProvider
    {
        private readonly IBenchmarkRepo objBenchmarkRepo;
        private readonly log4net.ILog _log4net;
        public BenchmarkProvider(IBenchmarkRepo _objBenchmarkRepo)
        {
            _log4net = log4net.LogManager.GetLogger(typeof(BenchmarkProvider));
            objBenchmarkRepo = _objBenchmarkRepo;
        }

        public List<AuditBenchmark> GetBenchmark()
        {
            _log4net.Info(" Http GET request " + nameof(BenchmarkProvider));

            List<AuditBenchmark> listOfRepository = new List<AuditBenchmark>();
            try
            {
                listOfRepository = objBenchmarkRepo.GetNolist();
                return listOfRepository;
            }
            catch (Exception e)
            {
                _log4net.Error(" Exception here" + e.Message + " " + nameof(BenchmarkProvider));
                return null;
            }

        }

    }
}
