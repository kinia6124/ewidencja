using System;
using System.Data.SqlClient;
using System.Web.Mvc;
using BOB.DO.Response;
using ewidencja.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ewidencjaTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            ObywatelController controller = new ObywatelController();

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        
    }
    
}
