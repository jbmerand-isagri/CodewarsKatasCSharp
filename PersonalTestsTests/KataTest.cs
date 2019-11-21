using Microsoft.VisualStudio.TestTools.UnitTesting;
using KatasSolutions;

namespace KatasSolutionsTests
{
    [TestClass]
    public class KataTest
    {
        [TestMethod]
        public void CountBits()
        {
            Assert.AreEqual(0, KatasSolutions.Kata.CountBits(0));
            Assert.AreEqual(1, KatasSolutions.Kata.CountBits(4));
            Assert.AreEqual(3, KatasSolutions.Kata.CountBits(7));
            Assert.AreEqual(2, KatasSolutions.Kata.CountBits(9));
            Assert.AreEqual(2, KatasSolutions.Kata.CountBits(10));
        }
    }
}