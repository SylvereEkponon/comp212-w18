using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RectangleLib;

namespace UnitTestRectangle
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CanCreateRectangle()
        {
            var rectangle = new Rectangle(1,3);
            Assert.IsNotNull(rectangle);
        }

        [TestMethod]
        public void CheckConstructor()
        {
            int len = 5, wid = 3;
            var r = new Rectangle(len, wid);
            Assert.AreEqual(len, r.Length, "Lenghts do not match");
            Assert.AreEqual(wid, r.Width, "Widths do not match");
        }

        [TestMethod]
        public void CheckToString()
        {
            int len = 5, wid = 3;
            var r = new Rectangle(len, wid);
            string expected = $"{len} X {wid}";
            string actual = r.ToString();
            Assert.AreEqual(expected, actual, "To string do not match");
        }
    }
}
