using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonalTests;

namespace PersonalTestsTests
{
    [TestClass]
    public class KataTest
    {
        [TestMethod]
        public void CountBits()
        {
            Assert.AreEqual(0, PersonalTests.Kata.CountBits(0));
            Assert.AreEqual(1, PersonalTests.Kata.CountBits(4));
            Assert.AreEqual(3, PersonalTests.Kata.CountBits(7));
            Assert.AreEqual(2, PersonalTests.Kata.CountBits(9));
            Assert.AreEqual(2, PersonalTests.Kata.CountBits(10));
        }
    }
}