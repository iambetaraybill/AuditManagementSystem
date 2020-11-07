using AuditSeverityModule.Controllers;
using AuditSeverityModule.Models;
using AuditSeverityModule.Providers;
using AuditSeverityModule.Repository;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AuditSeverityTesting
{
    public class SeverityRepoTest
    {
        
        List<AuditBenchmark> l1 = new List<AuditBenchmark>();
        List<AuditBenchmark> l2 = null;
        [SetUp]
        public void setup()
        {

            l1 = new List<AuditBenchmark>()
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
        }
        






       [Test]
        public void SeverityResponse_ValidOutput_OkRequest()
        {
            Mock<ISeverityRepo> mock = new Mock<ISeverityRepo>();
            mock.Setup(p => p.Response()).Returns(l1);
            
            SeverityRepo cp = new SeverityRepo();
            
            List<AuditBenchmark> result = cp.Response();
            Assert.AreEqual(l2,result);

            
        }

        [Test]
        public void SeverityResponse_NoOutput_BadRequestRequest()
        {
            Mock<ISeverityRepo> mock = new Mock<ISeverityRepo>();
            mock.Setup(p => p.Response()).Returns(l2);

            SeverityRepo cp = new SeverityRepo();

            List<AuditBenchmark> result = cp.Response();
            Assert.IsNull(result);
        }
        

    }
}