using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Minesweeper;

namespace Minesweeper.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MinesCount()
        {
            var minesCount = 10;
            var field = new Field(10, 10, minesCount);
            Assert.AreEqual(minesCount, field.Mines.Count);
        }

        [TestMethod]
        public void MinesCountBig()
        {
            var minesCount = 900;
            var field = new Field(70, 90, minesCount);
            Assert.AreEqual(minesCount, field.Mines.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PlaygroundSizeException()
        {
            var field = new Field(1, 1, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PlaygroundDimensionException()
        {
            var field = new Field(-1, -10, 2);
        }
    }
}
