using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace new工廠模式.裝備
{
    /**
     * 上衣介面(Product)
     */
    public abstract class Clothes
    {
        protected int def;    // 防禦力
        /**
         * 展示這件衣服
         */
        public string display()
        {
            return "上衣";
        }
        // 以下省略getter setter
    }
}
