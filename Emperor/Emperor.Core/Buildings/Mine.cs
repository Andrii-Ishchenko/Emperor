using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.Core.Buildings
{
    public class Mine : Building
    {
        
        public Mine(Game game, int price, int level) : base(game,"Mine",price, level)
        {
            Description = "Allows to get iron.";
        }

        public override void Produce(YearlyBalance balance)
        {
            balance.IronGrowth += Level * 8;
        }
    }
}