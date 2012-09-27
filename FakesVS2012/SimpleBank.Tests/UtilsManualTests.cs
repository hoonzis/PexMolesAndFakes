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
        public int Fibonacci(int x)
        {
            int result = Utils.Fibonacci(x);
            return result;
            // TODO: add assertions to method UtilsTest.Fibonacci(Int32)
        }


         [TestMethod]
        public string ReadFooValue()
        {
            using (ShimsContext.Create())
            {
                System.IO.Fakes.ShimFile.ReadAllTextString = (x) =>
                {
                    return "Hello World";
                };

                System.IO.Fakes.ShimFile.ExistsString = (x) => true;

                string result = Utils.ReadFooValue();

                return result;
            }
        }

         [TestMethod]
        public string SomeDumpMethod(int i, int j)
        {
            string result = Utils.SomeDumbMethod(i, j);
            return result;

        }
         [TestMethod]
        public string Capitalize(string parametr)
        {
            using (ShimsContext.Create())
            {
                System.IO.Fakes.ShimFile.ReadAllTextString = (x) =>
                {
                    return parametr;
                };

                System.IO.Fakes.ShimFile.ExistsString = (x) => true;

                string result = Utils.Capitalize();
                return result;
                // TODO: add assertions to method UtilsTest.Capitalize()
            }
        }

        [TestMethod]
        public string GetMessage(bool newyear)
        {

            using (ShimsContext.Create())
            {
                System.Fakes.ShimDateTime.NowGet =
                    () =>
                    {
                        if (newyear)
                        {
                            return new DateTime(1, 1, 1);
                        }
                        return new DateTime(2, 2, 2);
                    };
            }

            string result = Utils.GetMessage();
            return result;
        }
    }
}
