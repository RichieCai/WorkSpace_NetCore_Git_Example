using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 裝飾者模式.Fun
{
    //自動駕駛
    public class Autopilot : Decorator
    {

        public Autopilot(Car car1) : base(car1)
        {

        }
        public override void Renovation()
        {
            base.Renovation();
            Console.WriteLine("增加自動駕駛");
        }
    }
}
