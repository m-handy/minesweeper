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
            var field = new Playground(10, 10, minesCount);
            Assert.AreEqual(minesCount, field.OnlyMines.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PlaygroundSizeException()
        {
            var field = new Playground(1, 1, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PlaygroundDimensionException()
        {
            var field = new Playground(-1, -10, 2);
        }
    }
}
