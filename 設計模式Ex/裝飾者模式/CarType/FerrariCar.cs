using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 裝飾者模式.CarType
{
    public class FerrariCar: Car
    {
        public FerrariCar()
        { 
        
        }
        public override void Renovation()
        {
            Console.WriteLine("法拉利裝修");
        }
    }
}
