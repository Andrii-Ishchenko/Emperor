using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.Core.Buildings
{
    public class Farm : Building
    {
        public Farm(Game game, int price, int level) : base(game, "Farm", price, level)
        {
        }

        public override void Produce(YearlyBalance balance)
        {          
            var delta = -100*Level + Utils.GetRandomInstance().Next(2*100*Level);
            var growth = 300 * Level + delta;
            balance.FoodGrowth += growth;
        }

        public override bool Build(int count)
        {
            var res = base.Build(count);
            Price = (int)(Price*1.1);
            return res;

        }
    }
}
