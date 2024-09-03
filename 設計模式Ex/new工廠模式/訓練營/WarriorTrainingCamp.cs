using new工廠模式.Factory;
using new工廠模式.Interface;
using new工廠模式.角色;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace new工廠模式.訓練營
{
    /**
     * 實體工廠-鬥士訓練營
     */
    public class WarriorTrainingCamp : ITrainingCamp
    {
        private static IEquipFactory factory = new WarriorEquipFactory();


        public override Adventurer trainAdventurer()
        {
            // System.out.println("訓練一個鬥士");
            Warrior warrior = new Warrior();
            // ...進行基本訓練
            // ...鬥士訓練課程

            // 訓練完成配發裝備
            warrior.setWeapon(factory.productWeapon());
            warrior.setClothes(factory.productArmor());
            return warrior;
        }
    }
}
