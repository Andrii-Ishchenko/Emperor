using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.Core.Buildings
{
    public class Farm : Building
    {
        public Farm(Game game, int price, int count) : base(game, "Farm", price, count)
        {
        }

        public override void Produce(YearlyBalance balance)
        {
            var growth = Utils.GetRandomInstance().Next(2 * 500 * Count);
            balance.FoodGrowth += growth;
        }

    }
}
