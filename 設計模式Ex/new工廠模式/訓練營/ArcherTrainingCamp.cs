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
     * 實體工廠-弓箭手訓練營
     */
    public class ArcherTrainingCamp : ITrainingCamp
    {
        private static IEquipFactory factory = new ArcherEquipFactory();


        public override Adventurer trainAdventurer()
        {
           // System.out.println("訓練一個弓箭手");
            Archer archer = new Archer();
            // ...進行基本訓練
            // ...弓箭手訓練課程
            // 訓練完成配發裝備
            archer.setWeapon(factory.productWeapon());
            archer.setClothes(factory.productArmor());
            return archer;
        }

    }
}
