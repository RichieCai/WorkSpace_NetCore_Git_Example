using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 裝飾者模式.CarType
{
    public class LamborghiniCar: Car
    {
        public LamborghiniCar()
        { 

        }
        public override void Renovation()
        {
            Console.WriteLine("藍寶堅尼裝修");
        }
    }
}
