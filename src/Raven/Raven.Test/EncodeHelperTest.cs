using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Raven.Util;

namespace Raven.Test
{
    [TestClass]
    public class EncodeHelperTest
    {
        [TestMethod]
        public void Parse64Encode()
        {
            Assert.AreEqual("_", EncodeHelper.Parse64Encode(63));
            Assert.AreEqual("10", EncodeHelper.Parse64Encode(64));//10

            long dc = 10005; string ec;

            System.Diagnostics.Debug.WriteLine($"{dc}:{EncodeHelper.Parse64Encode(dc)}");
            ec = EncodeHelper.Parse64Encode(dc);
            dc = EncodeHelper.Parse64Decode(ec);
            Assert.AreEqual(10005, dc);

            dc = 1000352;
            System.Diagnostics.Debug.WriteLine($"{dc}:{EncodeHelper.Parse64Encode(dc)}");
            ec = EncodeHelper.Parse64Encode(dc);
            dc = EncodeHelper.Parse64Decode(ec);
            Assert.AreEqual(1000352, dc);

            dc = 2657595862531542;
            System.Diagnostics.Debug.WriteLine($"{dc}:{EncodeHelper.Parse64Encode(dc)}");
            ec = EncodeHelper.Parse64Encode(dc);
            dc = EncodeHelper.Parse64Decode(ec);
            Assert.AreEqual(2657595862531542, dc);

            dc = 20170602135410;
            System.Diagnostics.Debug.WriteLine($"{dc}:{EncodeHelper.Parse64Encode(dc)}");
            ec = EncodeHelper.Parse64Encode(dc);
            dc = EncodeHelper.Parse64Decode(ec);
            Assert.AreEqual(20170602135410, dc);

            dc = 1565895475265879;
            System.Diagnostics.Debug.WriteLine($"{dc}:{EncodeHelper.Parse64Encode(dc)}");
            ec = EncodeHelper.Parse64Encode(dc);
            dc = EncodeHelper.Parse64Decode(ec);
            Assert.AreEqual(1565895475265879, dc);


        }
    }
}
