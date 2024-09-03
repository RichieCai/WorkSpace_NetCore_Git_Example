using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 抽象類別基本用法
{
    public class doctor : Person
    {
        public override string Area { get; set; }
        public doctor(string Name, int Age) :base()
        {
            base._Name = Name;
            base._Age = Age;
        }
        public override void eat()
        {
            Console.WriteLine("我是doctor eat");
        }
        public override string Jump()
        {
            string sResult = "";
            Console.WriteLine("我是doctor Jump");
            return sResult;
        }

        public override string Skill()
        {
            string sResult = "";
            Console.WriteLine("我是doctor Skill");
            return sResult;
        }

        public void 開刀()
        {
            Console.WriteLine("my doctor 私有 showPrint 開刀");
        }

        public void action()
        {
            Console.WriteLine("我是新的action");
        }
    }
}
