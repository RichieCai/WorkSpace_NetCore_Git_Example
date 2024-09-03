using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyEx.s1
{
    public class MyServiceImpl : IMyService
    {
        public void DoSomething()
        {
            Console.WriteLine("Doing something...");
        }
    }
}
