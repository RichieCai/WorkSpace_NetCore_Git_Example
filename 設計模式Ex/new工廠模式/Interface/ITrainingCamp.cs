using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace new工廠模式.Interface
{
    public interface ITrainingCamp
    {
    /**
 * 訓練冒險者的過程，訓練後請給我一個冒險者
 */
    public Adventurer trainAdventurer();
}
}
