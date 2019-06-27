using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ewidencja;
using ewidencja.Controllers;
using System.Data;

namespace ewidencja.Tests.Controllers
{
    [TestClass]
    public class ObywatelControllerTest
    {
        [TestMethod]
        public void Obywatel()
        {
            
            ObywatelController controller = new ObywatelController();
            ViewResult result = controller.Index() as ViewResult;

            
            Assert.IsNotNull(result);
        }
    }
}
