using AuditSeverityModule.Models;
using AuditSeverityModule.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AuditSeverityModule.Providers
{
    public class SeverityProvider : ISeverityProvider
    {
        private readonly ISeverityRepo _severityRepo;
        public readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(SeverityProvider));
        public SeverityProvider(ISeverityRepo severityRepo)
        {
            _severityRepo = severityRepo;
        }
        public AuditResponse SeverityResponse(AuditRequest Req)
        {
            _log4net.Info(" SeverityResponse Method of SeverityProvider Called ");
            try
            {
                List<AuditBenchmark> listfromRepository = _severityRepo.Response();

                int count = 0;
                int acceptableNo = 0;

                if (Req.Auditdetails.questions.Question1 == false)
                    count++;
                if (Req.Auditdetails.questions.Question2 == false)
                    count++;
                if (Req.Auditdetails.questions.Question3 == false)
                    count++;
                if (Req.Auditdetails.questions.Question4 == false)
                    count++;
                if (Req.Auditdetails.questions.Question5 == false)
                    count++;

                if (Req.Auditdetails.Type == listfromRepository[0].auditType)
                    acceptableNo = listfromRepository[0].benchmarkNoAnswers;
                else if (Req.Auditdetails.Type == listfromRepository[1].auditType)
                    acceptableNo = listfromRepository[1].benchmarkNoAnswers;


                Random randomNumber = new Random();


                AuditResponse auditResponse = new AuditResponse();
                if (Req.Auditdetails.Type == "Internal" && count <= acceptableNo)
                {
                    auditResponse.AuditId = randomNumber.Next();
                    auditResponse.ProjectExexutionStatus = SeverityRepo.ActionToTakeAndStatus[0].ProjectExexutionStatus;
                    auditResponse.RemedialActionDuration = SeverityRepo.ActionToTakeAndStatus[0].RemedialActionDuration;
                }
                else if (Req.Auditdetails.Type == "Internal" && count > acceptableNo)
                {
                    auditResponse.AuditId = randomNumber.Next();
                    auditResponse.ProjectExexutionStatus = SeverityRepo.ActionToTakeAndStatus[1].ProjectExexutionStatus;
                    auditResponse.RemedialActionDuration = SeverityRepo.ActionToTakeAndStatus[1].RemedialActionDuration;
                }
                else if (Req.Auditdetails.Type == "SOX" && count <= acceptableNo)
                {
                    auditResponse.AuditId = randomNumber.Next();
                    auditResponse.ProjectExexutionStatus = SeverityRepo.ActionToTakeAndStatus[0].ProjectExexutionStatus;
                    auditResponse.RemedialActionDuration = SeverityRepo.ActionToTakeAndStatus[0].RemedialActionDuration;
                }
                else if (Req.Auditdetails.Type == "SOX" && count > acceptableNo)
                {
                    auditResponse.AuditId = randomNumber.Next();
                    auditResponse.ProjectExexutionStatus = SeverityRepo.ActionToTakeAndStatus[2].ProjectExexutionStatus;
                    auditResponse.RemedialActionDuration = SeverityRepo.ActionToTakeAndStatus[2].RemedialActionDuration;
                }


                return auditResponse;
            }
            catch(Exception ex)
            {
                _log4net.Error(ex.Message);
                return null;
            }

            
        }
    }
}
