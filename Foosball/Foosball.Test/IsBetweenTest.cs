using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Foosball.Test
{
    [TestClass]
    public class IsBetweenTest
    {
        [TestMethod]
        public void TestBetween()
        {
            bool expected = true;
            int coord = 65;
            int firstvalue = 50;
            int secondvalue = 102;

            bool actual = coord.Between(firstvalue, secondvalue);

            Assert.AreEqual(expected, actual);
        }
    }
}
