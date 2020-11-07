using AuditSeverityModule.Controllers;
using AuditSeverityModule.Models;
using AuditSeverityModule.Providers;
using AuditSeverityModule.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AuditSeverityTesting
{
    public class SeverityControllerTest
    {
        List<AuditBenchmark> l1 = new List<AuditBenchmark>()
        {
            new AuditBenchmark()
            {
                auditType="Internal",
                benchmarkNoAnswers=3
            },
            new AuditBenchmark()
            {
                auditType="SOX",
                benchmarkNoAnswers=1
            }
        };



        

        [TestCase("Internal")]
        [TestCase("SOX")]
        public void ProjectExecutionStatus_ValidOutput_OkRequest(string type)
        {
            Mock<ISeverityProvider> mock = new Mock<ISeverityProvider>();
            AuditResponse rp = new AuditResponse();
            AuditRequest req = new AuditRequest()
            {
                Auditdetails = new AuditDetail()
                {
                    Type = type,
                    questions = new Questions()
                    {
                        Question1 = true,
                        Question2 = false,
                        Question3 = false,
                        Question4 = false,
                        Question5 = false
                    }
                }
            };
            mock.Setup(p => p.SeverityResponse(req)).Returns(rp);
            AuditSeverityController cp = new AuditSeverityController(mock.Object);

            OkObjectResult result = cp.ProjectExecutionStatus(req) as OkObjectResult;
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestCase("Internal123")]
        [TestCase("SOX123")]
        public void ProjectExecutionStatus_InvalidOutput_ReturnBadRequest(string type)
        {
            try
            {
                Mock<ISeverityProvider> mock = new Mock<ISeverityProvider>();
                AuditResponse rp = new AuditResponse();
                AuditRequest req = new AuditRequest()
                {
                    Auditdetails = new AuditDetail()
                    {
                        Type = type,
                        questions = new Questions()
                        {
                            Question1 = true,
                            Question2 = false,
                            Question3 = false,
                            Question4 = false,
                            Question5 = false
                        }
                    }
                };
                mock.Setup(p => p.SeverityResponse(req)).Returns(rp);
                AuditSeverityController cp = new AuditSeverityController(mock.Object);

                OkObjectResult result = cp.ProjectExecutionStatus(req) as OkObjectResult;
                Assert.AreEqual(400, result.StatusCode);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
            }

        }
    }
}