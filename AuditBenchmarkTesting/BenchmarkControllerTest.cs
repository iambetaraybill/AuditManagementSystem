using AuditBenchmarkModule.Controllers;
using AuditBenchmarkModule.Models;
using AuditBenchmarkModule.Providers;
using AuditBenchmarkModule.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AuditBenchmarkTesting
{
    public class TestsController
    {
        List<AuditBenchmark> l2 = new List<AuditBenchmark>();
        List<AuditBenchmark> l1 = new List<AuditBenchmark>();
        [SetUp]
        public void Setup()
        {

            l1 = new List<AuditBenchmark>()
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
            l2 = new List<AuditBenchmark>()
            {
                new AuditBenchmark
                {
                    auditType="ABC",
                    benchmarkNoAnswers=4
                }
            };

        
        }


        [Test]
        public void AuditBenchmark_ValidInput_OkRequest()
        {
            Mock<IBenchmarkProvider> mock = new Mock<IBenchmarkProvider>();
            mock.Setup(p => p.GetBenchmark()).Returns(l1);
            AuditBenchmarkController cp = new AuditBenchmarkController(mock.Object);
            OkObjectResult result = cp.AuditBenchmark() as OkObjectResult;
            Assert.AreEqual(200, result.StatusCode);

        }

        

        [Test]
        public void AuditBenchmark_InvalidInput_ReturnBadRequest()
        {
            try
            {
                Mock<IBenchmarkProvider> mock = new Mock<IBenchmarkProvider>();
                mock.Setup(p => p.GetBenchmark()).Returns(l2);
                AuditBenchmarkController cp = new AuditBenchmarkController(mock.Object);
                var result = cp.AuditBenchmark() as BadRequestResult;
                Assert.AreEqual(400, result.StatusCode);
            }

            catch (Exception e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
            }
        }
    }
}