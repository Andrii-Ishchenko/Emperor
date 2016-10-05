using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.Core.Buildings
{
    public class Market : Building
    {

        public Market(Game game, int price, int count) :base(game, "Market", price, count)
        {
                
        } 

        public override bool Build(int count)
        {
            throw new NotImplementedException();
        }

        public override void Produce(YearlyBalance balance)
        {
            int goldIncome = Count * 200;
            balance.GoldDelta += goldIncome;
        }
    }
}
