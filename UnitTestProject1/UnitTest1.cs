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
        A a = new A();

        [TestMethod]
        public void various_ways_to_get_type()
        {
            //var a = new A();
            Type[] arr_type = new Type[3];
            arr_type[0] = typeof(A);
            arr_type[1] = a.GetType();
            arr_type[2] = Type.GetType("UnitTestProject1.UnitTest1");
            foreach (Type item in arr_type)
            {
                Console.WriteLine("Type: {0}, Namespace: {1}", item.Name, item.Namespace);
            } 

        }

        [TestMethod]
        public void get_fields()
        {
            Type aType = a.GetType();
            FieldInfo[] arrField = aType.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (FieldInfo item in arrField)
            {
                Console.WriteLine("Field: {0}||, " +
                    "Field Type1: {1}||, " +
                    "Field Type2: {2}||", item.Name, item.DeclaringType, item.FieldType);
            }
        }

        [TestMethod]
        public void get_property()
        {
            Type aType = a.GetType();
            PropertyInfo[] arrProp = aType.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (PropertyInfo item in arrProp)
            {
                Console.WriteLine("Property name: {0}||, " +
                    "Property Type1: {1}||, " +
                    "Property Type2: {2}||", item.Name, item.DeclaringType, item.PropertyType );
            }

        }

        [TestMethod]
        public void get_methods()
        {
            Type aType = a.GetType();
            MethodInfo[] arrMethod = aType.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            foreach (MethodInfo item in arrMethod)
            {
                Console.WriteLine("Method name: {0}, ", item.Name);
            }

            Console.WriteLine(new string('-', 20));

            arrMethod = aType.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (MethodInfo item in arrMethod)
            {
                Console.WriteLine("Method name: {0}, ", item.Name);
            }
        }

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
            MethodInfo divMethod = atype.GetMethod("Div", BindingFlags.NonPublic | BindingFlags.Instance);
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
