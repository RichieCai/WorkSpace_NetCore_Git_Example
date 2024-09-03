using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  抽象類別基本用法

{
    public class Teacher : Person
    {
        public override string Area { get; set; }

        public Teacher(string Name, int Age) : base()
        {
            base._Name = Name;
            base._Age = Age;
        }
        public override void eat()
        {
            Console.WriteLine("我是Teacher eat");
        }
        public override string Jump()
        {
            string sResult = "";
            Console.WriteLine("我是Teacher Jump");
            return sResult;
        }

        public override string Skill()
        {
            string sResult = "";
            Console.WriteLine("我是Teacher Skill");
            return sResult;
        }
        public void 上課()
        {
            Console.WriteLine("my teacher 私有 showPrint 上課");
        }
    }
}
