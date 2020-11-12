using AuditBenchmarkModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditBenchmarkModule.Providers
{
        public interface IBenchmarkProvider
        {
            public List<AuditBenchmark> GetBenchmark();
        }
    
}
