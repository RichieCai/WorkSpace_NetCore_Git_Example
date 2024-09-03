using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 裝飾者模式.Fun
{
    //噴火引擎
    public  class FireEngine: Decorator
    {
        public FireEngine(Car car1) : base(car1)
        {

        }
        public override void Renovation()
        {
            base.Renovation();
            Console.WriteLine("增加噴火引擎");
        }
    }
}
