using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace new工廠模式.裝備
{
    /**
     * 武器介面(Product)
     */
    public abstract class Weapon
    {
        protected int atk { get; set; }      // 攻擊力
        protected int range { get; set; }   // 攻擊範圍

        /**
         * 展示武器
         */
        public string display()
        {
            return "武器介面";
        }

        // 以下省略getter setter
    }
}
