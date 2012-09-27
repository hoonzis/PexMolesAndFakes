using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleBank.Tests
{
    [TestClass]
    public class UtilsManualTests
    {

        [TestMethod]
        public void TestFibonacci()
        {
            int result = Utils.Fibonacci(3);
            Assert.AreEqual(result,9);
        }


        [TestMethod]
        public void TestReadFooValue()
        {
            using (ShimsContext.Create())
            {
                System.IO.Fakes.ShimFile.ReadAllTextString = (x) =>
                {
                    return "Hello World";
                };

                System.IO.Fakes.ShimFile.ExistsString = (x) => true;

                string result = Utils.ReadFooValue();

                Assert.AreEqual(result, "Hello World");
            }
        }

        [TestMethod]
        public void SomeDumpMethod(int i, int j)
        {
            string result = Utils.SomeDumbMethod(i, j);
            Assert.AreEqual(result, "test");

        }
        
        [TestMethod]
        public void Capitalize()
        {
            using (ShimsContext.Create())
            {
                System.IO.Fakes.ShimFile.ReadAllTextString = (x) =>
                {
                    return "some text";
                };

                System.IO.Fakes.ShimFile.ExistsString = (x) => true;

                string result = Utils.Capitalize();
                Assert.AreEqual(result, "SomeText");
            }
        }

        [TestMethod]
        public void GetMessage()
        {

            using (ShimsContext.Create())
            {
                System.Fakes.ShimDateTime.NowGet =
                    () =>
                    {
                        return new DateTime(1, 1, 1);   
                    };
            }

            string result = Utils.GetMessage();
            Assert.AreEqual(result, "Happy New Year");   
        }
    }
}
