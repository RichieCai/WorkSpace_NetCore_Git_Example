using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 抽象工廠.Color;
using 抽象工廠.Interface;

namespace 抽象工廠.Factory
{
    public class ColorFactory : AbstractFactory
    {
        public override IShape getShape(String shapeType)
        {
            return null;
        }
        public override IColor getColor(String color)
        {
            if (color == null)
            {
                return null;
            }
            if (color.Equals("RED"))
            {
                return new Red();
            }
            else if (color.Equals("GREEN"))
            {
                return new Green();
            }
            else if (color.Equals("BLUE"))
            {
                return new Blue();
            }
            return null;
        }
    }
}
