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
    public class SeverityProviderTest
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

        List<AuditBenchmark> l2 = new List<AuditBenchmark>()
        {
            new AuditBenchmark()
            {
                auditType="Internal",
                benchmarkNoAnswers=1
            },
            new AuditBenchmark()
            {
                auditType="SOX",
                benchmarkNoAnswers=0
            }
        };





        [Test]
        public void Internal_SeverityResponse_ValidOutput_OkRequest()
        {
            Mock<ISeverityRepo> mock = new Mock<ISeverityRepo>();
            mock.Setup(p => p.Response()).Returns(l1);
            SeverityProvider cp = new SeverityProvider(mock.Object);
            AuditRequest req = new AuditRequest()
            {
                Auditdetails = new AuditDetail()
                {
                    Type = "Internal",
                    questions = new Questions()
                    {
                        Question1 = true,
                        Question2 = true,
                        Question3 = false,
                        Question4 = false,
                        Question5 = true
                    }
                }
            };
            AuditResponse result = cp.SeverityResponse(req);
            Assert.AreEqual("GREEN", result.ProjectExexutionStatus);
        }
        [Test]
        public void SOX_SeverityResponse_ValidOutput_OkRequest()
        {
            Mock<ISeverityRepo> mock = new Mock<ISeverityRepo>();
            mock.Setup(p => p.Response()).Returns(l1);
            SeverityProvider cp = new SeverityProvider(mock.Object);
            AuditRequest req = new AuditRequest()
            {
                Auditdetails = new AuditDetail()
                {
                    Type = "Internal",
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
            AuditResponse result = cp.SeverityResponse(req);
            Assert.AreEqual("RED", result.ProjectExexutionStatus);
        }

        [Test]
        public void Internal_SeverityResponse_InalidOutput_BadRequest()
        {
            Mock<ISeverityRepo> mock = new Mock<ISeverityRepo>();
            mock.Setup(p => p.Response()).Returns(l2);
            SeverityProvider cp = new SeverityProvider(mock.Object);
            AuditRequest req = new AuditRequest()
            {
                Auditdetails = new AuditDetail()
                {
                    Type = "Internal",
                    questions = new Questions()
                    {
                        Question1 = true,
                        Question2 = true,
                        Question3 = false,
                        Question4 = false,
                        Question5 = true
                    }
                }
            };
            AuditResponse result = cp.SeverityResponse(req);
            Assert.AreNotEqual("GREEN", result.ProjectExexutionStatus);
        }
        [Test]
        public void SOX_SeverityResponse_InvalidOutput_BadRequest()
        {
            Mock<ISeverityRepo> mock = new Mock<ISeverityRepo>();
            mock.Setup(p => p.Response()).Returns(l2);
            SeverityProvider cp = new SeverityProvider(mock.Object);
            AuditRequest req = new AuditRequest()
            {
                Auditdetails = new AuditDetail()
                {
                    Type = "Internal",
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
            AuditResponse result = cp.SeverityResponse(req);
            Assert.AreNotEqual("Red", result.ProjectExexutionStatus);
        }


    }
}