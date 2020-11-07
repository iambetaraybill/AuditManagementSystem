using AuditChecklistModule.Controllers;
using AuditChecklistModule.Models;
using AuditChecklistModule.Providers;
using AuditChecklistModule.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AuditChecklistTesting
{
    public class TestsController
    {
        List<Questions> l1 = new List<Questions>();
        List<Questions> l2 = null;
        [SetUp]
        public void setup()
        {

            l1 = new List<Questions>()
            {
                new Questions
                {
                    QuestionNo=1,
                    Question="Have all Change requests followed SDLC before PROD move?"
                },
                new Questions
                {
                    QuestionNo=2,
                    Question="Have all Change requests been approved by the application owner?"
                },
                new Questions
                {
                    QuestionNo=3,
                    Question="Is data deletion from the system done with application owner approval?"
                }

                
            };
        }


        [TestCase("Internal")]
        [TestCase("SOX")]
        public void AuditCheckListQuestions_ValidInput_OkRequest(string type)
        {
            Mock<IChecklistProvider> mock = new Mock<IChecklistProvider>();
            mock.Setup(p => p.QuestionsProvider(type)).Returns(l1);
            AuditChecklistController cp = new AuditChecklistController(mock.Object);
            OkObjectResult result = cp.AuditCheckListQuestions(type) as OkObjectResult;
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestCase("Internalab")]
        [TestCase("SOXab")]
        public void AuditCheckListQuestions_InvalidInput_ReturnBadRequest(string a)
        {
            try
            {
                string type = null;
                Mock<IChecklistProvider> mock = new Mock<IChecklistProvider>();
                mock.Setup(p => p.QuestionsProvider(type)).Returns(l2);
                AuditChecklistController cp = new AuditChecklistController(mock.Object);
                OkObjectResult result = cp.AuditCheckListQuestions(type) as OkObjectResult;
                Assert.AreEqual(400, result.StatusCode);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
            }

        }


    }
}