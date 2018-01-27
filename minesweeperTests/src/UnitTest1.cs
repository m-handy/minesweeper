using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace minesweeperTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FailingMethod()
        {
            Assert.AreEqual(1,2);
        }
    }
}
