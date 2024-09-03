using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 裝飾者模式.Fun
{
    public class SatellitePositioning:Decorator
    {
        public SatellitePositioning(Car car1) : base(car1)
        {

        }
        public override void Renovation()
        {
            base.Renovation();
            Console.WriteLine("增加衛星定位");
        }
    }
}
