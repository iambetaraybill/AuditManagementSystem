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
    public class TestsProvider
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
        public void QuestionsProvider_ValidInput_OkRequest(string type)
        {
            Mock<IChecklistRepo> mock = new Mock<IChecklistRepo>();
            mock.Setup(p => p.GetQuestions(type)).Returns(l1);
            ChecklistProvider cp = new ChecklistProvider(mock.Object);
            List<Questions> result = cp.QuestionsProvider(type);
            Assert.AreEqual(3, result.Count);
        }

        [TestCase("Internalab")]
        [TestCase("SOXab")]
        public void GetQuestions_InvalidInput_ReturnBadRequest(string a)
        {
            try
            {
                string type = null;
                Mock<IChecklistRepo> mock = new Mock<IChecklistRepo>();
                mock.Setup(p => p.GetQuestions(type)).Returns(l2);
                ChecklistProvider cp = new ChecklistProvider(mock.Object);
                List<Questions> result = cp.QuestionsProvider(type);
                Assert.AreEqual(0, result.Count);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
            }

        }

        


    }
}