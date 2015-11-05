using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace VectorSharp.Tests
{
    [TestClass]
    public class GenericVector3
    {
        private readonly MethodInfo createMethod = typeof(Generic.Vector3).GetTypeInfo().GetDeclaredMethod("Create");

        private readonly Type[] numberTypes = new[]
        {
            typeof(byte), typeof(sbyte),
            typeof(short), typeof(ushort),
            typeof(int), typeof(uint),
            typeof(long), typeof(ulong),
            typeof(float), typeof(double)
        };

        [TestMethod]
        public void Creates()
        {
            foreach (var numberType in numberTypes)
            {
                createMethod.MakeGenericMethod(numberType)
                    .Invoke(null, new object[]
                    {
                        numberType.GetField("MinValue").GetValue(null),
                        numberType.GetField("MaxValue").GetValue(null),
                        numberType.GetField("MaxValue").GetValue(null)
                    });
            }
        }
    }
}