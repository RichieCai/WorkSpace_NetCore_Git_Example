using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 工廠模式2.Interface;

namespace 工廠模式2
{
    public class Rectangle:IShape
    {

   public void draw()
    {
       Console.WriteLine("Inside Rectangle::draw() method.");
    }
}
}
