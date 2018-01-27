using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using minesweeper;

namespace minesweeper.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MinesCount()
        {
            var minesCount = 10;
            var field = new Playground(5, 10, minesCount);
            Assert.AreEqual(minesCount, field.OnlyMinesCount);
        }
    }
}
