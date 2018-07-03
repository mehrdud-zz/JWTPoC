using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace JWTPoCUnitTest
{
    [TestClass]
    public class JWTControllerTest
    {
        // private readonly ILogger<JWTControllerTest> _logger;

        [TestMethod]
        public void TestTokenGeneration()
        {
            var jwtController = new TestJWT.JWT.JWTController();
            var token = jwtController.GenerateJwtSecurityToken("Test123", "CallerId", "CorrelationId");
            Assert.IsNotNull(token, "JWT token: " + token.ToString());

            Console.WriteLine("JWT token: " + token.ToString());
           // _logger.LogInformation("JWT Token: " + token.ToString());
        }
    }
}
