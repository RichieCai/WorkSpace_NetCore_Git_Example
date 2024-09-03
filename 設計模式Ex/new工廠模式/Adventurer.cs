using new工廠模式.裝備;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace new工廠模式
{
    /**
     * 冒險者
     */
    public abstract class Adventurer
    {
        protected Weapon weapon;    //武器
        protected Clothes clothes;  //衣服
        /**
         * 看冒險者的狀態
         */
        public abstract string display();
        // getter & setter 省略
    }
}
