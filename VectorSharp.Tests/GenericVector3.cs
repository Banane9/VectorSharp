using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace VectorSharp.Tests
{
    [TestClass]
    public class GenericVector3
    {
        [TestMethod]
        public void Creates()
        {
            var vec3 = Generic.Vector3.Create<double>(1, 1, 1);
            Assert.IsTrue(true);
        }
    }
}