using NUnit.Framework;
using System;
using Moq;
using AuthorizationService.Repository;
using AuthorizationService.Providers;
using AuthorizationService.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace NUnitTestAuthorizationService
{
    public class AuthRepo_GenerateJWT_Test
    {
        public string token_null;
        [SetUp]
        public void Setup()
        {
            token_null = null;

        }

        [Test]
        public void GenerateJWT_correctInput_tokenNotnull()
        {
            try
            {
                var mock = new Mock<IConfiguration>();
                mock.SetupGet(x => x[It.IsAny<string>()]);
                var res = new AuthRepo(mock.Object);
                var data = res.GenerateJWT();
                Assert.IsNotNull(data);
            }

            catch (Exception e)
            {
                Assert.AreEqual("String reference not set to an instance of a String. (Parameter 's')", e.Message);
            }

        }

        [Test]
        public void generateJWT_invalidInput_tokenNotnull()
        {

            try
            {
                var mock = new Mock<IConfiguration>();
                mock.SetupGet(x => x[It.IsAny<string>()]).Returns(token_null);
                var res = new AuthRepo(mock.Object);
                var data = res.GenerateJWT();
                Assert.IsNull(data);

            }
            catch (Exception e) {
                Assert.AreEqual("String reference not set to an instance of a String. (Parameter 's')", e.Message);
            }
        }  
    }
}