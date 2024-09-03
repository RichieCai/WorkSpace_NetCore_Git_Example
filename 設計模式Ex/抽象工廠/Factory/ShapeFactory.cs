using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 抽象工廠.Interface;
using 抽象工廠.Shape;

namespace 抽象工廠.Factory
{
    public class ShapeFactory : AbstractFactory
    {


   public override IShape getShape(String shapeType)
    {
        if (shapeType == null)
        {
            return null;
        }
        if (shapeType.Equals("CIRCLE"))
        {
            return new Circle();
        }
        else if (shapeType.Equals("RECTANGLE"))
        {
            return new Rectangle();
        }
        else if (shapeType.Equals("SQUARE"))
        {
            return new Square();
        }
        return null;
    }


   public override IColor getColor(String color)
    {
        return null;
    }
}
}
