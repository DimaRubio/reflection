using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Course;
using System.Reflection;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Divizion_on_b_correcrt_value()
        {
            var a = new A();
            var expectedResult = 0.5;
            //double actualResult = a.Div(1, 1);
            //рефлексия т.к метод Div сделали private
            var atype = a.GetType();
            //var methods = atype.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            //var divMethod = methods.Where(t => t.Name == "Div").Single();
            //var actualResult = divMethod.Invoke(a, new object [] {1,1} );

            //2-й способ рефлексии
            var divMethod = atype.GetMethod("Div", BindingFlags.NonPublic | BindingFlags.Instance);
            var actualResult = divMethod.Invoke(a, new object[] { 1, 1 });


            Assert.AreEqual(actualResult, expectedResult);
        }

        [TestMethod] [ExpectedException(typeof (DivideByZeroException))]

        public void TestMethod2()
        {
            var a = new A();
            //var expectedResult;
            //try
            //{
            //    var actualResult = a.Div(1, 0);
            //}
            //catch
            //{
            //    expectedResult = 1;
            //}
            //var actualResult = a.Div(1, 0);
        }
    }
}
