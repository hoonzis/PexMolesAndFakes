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
using Microsoft.QualityTools.Testing.Fakes;

//[assembly: MoledType(typeof(System.IO.File))]
namespace SimpleBank
{
    /// <summary>
    /// Parametrized tests for Utils class. The test compile, but because Pex is not available for VS2012,
    /// there is no way to test
    /// </summary>
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

   
        [PexMethod]
        public string ReadFooValue()
        {
            using(ShimsContext.Create()){
            System.IO.Fakes.ShimFile.ReadAllTextString = (x) =>
            {
                return "Hello World";
            };

            System.IO.Fakes.ShimFile.ExistsString = (x) => true;

            string result = Utils.ReadFooValue();
            
            return result;
            }
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

        [PexMethod]
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
