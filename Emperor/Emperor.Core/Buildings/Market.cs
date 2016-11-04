using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.Core.Buildings
{
    public class Market : Building
    {
        //each lvl grants passively 200gold per year
        //each 2 lvls allow trade goods
        //1 - food
        //3 - tools
        //5 - horses, limitted to last year increase
        //7 - wood & stone
        //9 - weapons, limitted to last year increase
        //10 - limit +25%
        //15 - limit +50%

        //GOLD <-> PRICE DIFFERENCE

        public Market(Game game, int price, int level) :base(game, "Market", price, level)
        {
            Description = "Allow you to trade goods as well as recieve gold as trade fare.";
            
        } 


        public override void Produce(YearlyBalance balance)
        {
            int goldIncome = Level * 500;
            balance.GoldGrowth += goldIncome;
        }
    }
}
