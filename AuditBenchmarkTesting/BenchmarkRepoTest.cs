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
    public class TestsRepo
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
        public void GetBenchmark_ValidInput_OkRequest()
        {
            Mock<IBenchmarkRepo> mock = new Mock<IBenchmarkRepo>();
            mock.Setup(p => p.GetNolist()).Returns(l1);
            BenchmarkRepo cp = new BenchmarkRepo();
            List<AuditBenchmark> result = cp.GetNolist();
            Assert.AreEqual(l1.Count, result.Count);
        }

        [Test]
        public void GetBenchmark_InvalidInput_ReturnBadRequest()
        {
            Mock<IBenchmarkRepo> mock = new Mock<IBenchmarkRepo>();
            mock.Setup(p => p.GetNolist()).Returns(l2);
            BenchmarkRepo cp = new BenchmarkRepo();
            List<AuditBenchmark> result = cp.GetNolist();
            Assert.AreNotEqual(l1.Count, result.Count);
        }

        
    }
}