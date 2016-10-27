using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.Core.Buildings
{
    public class Mine : Building
    {
        
        public Mine(Game game, int price, int count) : base(game,"Mine",price, count)
        {

        }

        public override void Produce(YearlyBalance balance)
        {
            balance.IronGrowth += Count * 8;
        }
    }
}