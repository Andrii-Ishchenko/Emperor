using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.Core.Buildings
{
    public class Smith : Building
    {
        //TODO: produce tools as well

        public Smith(Game game,int price, int level) : base(game,"Smith", price, level)
        {
            Description = "Required to produce weapons and tools";
        }

        public override void Produce(YearlyBalance balance)
        {
            var maxProduceCount = 10 * Level;
            var takenIron = Math.Min(_game.Iron , maxProduceCount);
            balance.WeaponsGrowth = takenIron;// 1<->1
            balance.IronConsumed = takenIron;
        }
    }
}
