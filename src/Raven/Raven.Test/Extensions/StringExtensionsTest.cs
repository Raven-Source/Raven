using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Raven.Extensions;

namespace Raven.Test.Extensions
{
    [TestClass]
    public class StringExtensionsTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            string str = null;
            bool res;
            res = str.IsNullOrEmpty();
            Assert.AreEqual(true, res);

            res = str.IsNullOrWhiteSpace();
            Assert.AreEqual(true, res);
        }
    }
}
