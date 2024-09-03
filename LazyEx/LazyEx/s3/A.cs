using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyEx.s3
{
    public class A
    {
        private Lazy<B> _b;
        public A(Lazy<B> b)
        {
            _b = b;
            Console.WriteLine(" init a");
        }

        public void MethodOne()
        {
            _b.Value.ClassBMethod();
        }

        public void MethodTwo()
        {
            Console.WriteLine(" MethodTwo process");
        }
        public void MethodThree()
        {
            Console.WriteLine("MethodThree process");
        }
    }
}
