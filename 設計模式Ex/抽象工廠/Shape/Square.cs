using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 抽象工廠.Interface;

namespace 抽象工廠.Shape
{
    public class Square : IShape
    {

        public void draw()
        {
            Console.WriteLine("Inside Square::draw() method.");
        }
    }
}
