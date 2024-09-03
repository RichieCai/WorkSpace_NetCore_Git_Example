using new工廠模式.裝備;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace new工廠模式.Interface
{
    /**
     * 裝備工廠介面(Factory)-定義每一間工廠應該生產哪些東西
     */
    public interface IEquipFactory
    {
        /**
         * 製造武器
         */
        Weapon productWeapon();
        /**
         * 製造衣服
         */
        Clothes productArmor();
    }
}
