using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 抽象工廠.Interface;

namespace 抽象工廠.Shape
{
    public class Rectangle : IShape
    {

        public void draw()
        {
            Console.WriteLine("Inside Rectangle::draw() method.");
        }
    }
}
