using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.IO.Moles;
using System.Moles;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleBank.Tests
{
    [TestClass]
    public class UtilsManualTest
    {   
        [TestMethod]
        public void TestFibonacci()
        {
            int result = Utils.Fibonacci(4);
            Assert.AreEqual(result, 5);
        }


        [TestMethod]
        [HostType("Moles")]
        public void TestReadFooValue()
        {
            
            MFile.ReadAllTextString = (x) =>
            {
                return "Hello World";
            };

            MFile.ExistsString = (x) => true;

            string result = Utils.ReadFooValue();

            Assert.AreEqual(result, "Hello World");
            
        }

        [TestMethod]
        public void SomeDumpMethod()
        {
            string result = Utils.SomeDumbMethod(1,2);
            Assert.AreEqual(result, "output3");
        }

        [TestMethod]
        [HostType("Moles")]
        public void Capitalize()
        {
            
            MFile.ReadAllTextString = (x) =>
            {
                return "some text";
            };

            MFile.ExistsString = (x) => true;

            string result = Utils.Capitalize();
            Assert.AreEqual(result, "SomeText");
        }

        [TestMethod]
        [HostType("Moles")]
        public void GetMessage()
        {
            MDateTime.NowGet =
                () =>
                {
                    return new DateTime(1, 1, 1);
                };


            string result = Utils.GetMessage();
            Assert.AreEqual(result, "Happy New Year!");
            
        }
    }
}
