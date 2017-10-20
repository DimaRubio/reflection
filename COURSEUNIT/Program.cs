using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class A : ICar
    {
        public string publicValue = "public";
        string privateValue = "private";

        public int PublicAutoProperty{ get; set;}
        int PrivateAutoProperty { get; set; }

        public string PublicProperty
        {
            get { return publicValue; }
            set { publicValue = value; }
        }

        public string GetPrivateField
        {
            get { return privateValue; }
        }

        string PrivateProperty
        {
            get { return privateValue; }
        }
        
        private double Div(int a, int b)
        {
            //return a / b; 
            return (double)a / (b + a);
        }

        public void Drive() { }
        void ICar.Access() { }
    }



    interface ICar
    {
        void Drive();
        void Access();
    }

}
