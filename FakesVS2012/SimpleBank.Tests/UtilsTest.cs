// <copyright file="UtilsTest.cs">Copyright ©  2011</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleBank;
//using System.IO.Moles;
//using Microsoft.Moles.Framework;
using Microsoft.Pex.Framework.Generated;
//using System.Moles;
using System.Fakes;

//[assembly: MoledType(typeof(System.IO.File))]
namespace SimpleBank
{
    [PexClass(typeof(Utils))]
    [TestClass]
    public partial class UtilsTest
    {
        [PexMethod]
        public int Fibonacci(int x)
        {
            int result = Utils.Fibonacci(x);
            return result;
            // TODO: add assertions to method UtilsTest.Fibonacci(Int32)
        }

        /// <summary>Test stub for ReadFooValue()</summary>
        [PexMethod]
        public string ReadFooValue()
        {
            /*
            MFile.ReadAllTextString = (x) =>
            {
                return "Hello World";
            };

            MFile.ExistsString = (x) => true;

            string result = Utils.ReadFooValue();
            PexAssert.AreEqual(result, "Hello World");
            return result;*/

            return null;
        }

        [PexMethod]
        public string SomeDumpMethod(int i, int j)
        {
            string result = Utils.SomeDumbMethod(i, j);
            return result;
            
        }
        [PexMethod]
        public string Capitalize(string parametr)
        {
            /*
            MFile.ReadAllTextString = (x) =>
            {
                return parametr;
            };

            MFile.ExistsString = (x) => true;

            string result = Utils.Capitalize();
            return result;*/
            // TODO: add assertions to method UtilsTest.Capitalize()
            return null;
        }

        [PexMethod]
        public string GetMessage(bool newyear)
        {
            /*
            using (ShimContext.Create())
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
            }*/
            
            string result = Utils.GetMessage();
            return result;
        }
    }
}
