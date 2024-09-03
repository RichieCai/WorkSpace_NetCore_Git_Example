using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace new工廠模式.角色
{
    /**
     * 鬥士
     */
    public class Warrior : Adventurer
    {
        public override string display()
        {
            return "我是弓箭手，裝備:";
            weapon.display();
            clothes.display();
        }
    }
}
