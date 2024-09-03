using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace new工廠模式.角色
{
    /**
     * 弓箭手
     */
    public class Archer : Adventurer
    {


        public override string display()
        {
            return "我是弓箭手，裝備:";
            weapon.display();
            // System.out.println();
            clothes.display();
            //   System.out.println();
        }
    }
}
