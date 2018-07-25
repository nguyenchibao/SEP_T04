using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SEPApplication.Tests
{
    [TestClass]
    public class APITest

    {
        [TestMethod]
        public void TestLogin()
        {
            var api = new API();
            var result0 = api.Login("phamngocduy", "tradristel");
            var result1 = api.Login("phamngocduy", "1234567890");
            Assert.AreEqual(0, result0.Code);
            Assert.AreEqual(1, result1.Code);
        }
        [TestMethod]
        public void TestGetCourse()
        {
            var api = new API();
            var result = api.GetCourse("ND");
            Assert.AreEqual(3, result.Code);
        }
    }
}
