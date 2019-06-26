using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace TestyJednostkowe
{
    [TestClass]
    public class UnitTest1
    {
        public string connectionString { get; private set; }
        public object ConnectionState { get; private set; }

        [TestMethod]
        public void SprawdzenieBaza()
        {

            connectionString = "Data Source=(LocalDb)/MSSQLLocalDB;AttachDbFilename=|DataDirectory|\aspnet-ewidencja-20190511065939.mdf;Initial Catalog=bazaewidencja2;";
                    

            connectionString.Open();
            if (connectionString.State == ConnectionState.Open)
            {
                bool actual = true;
                bool expected = true;
                Assert.AreEqual(expected, actual);
            }

        }
    }
}
