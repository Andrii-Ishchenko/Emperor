using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.Core.Buildings
{
    public class Bank : Building
    {
        public Bank(Game game, int price, int startLevel) : base(game, "Bank", price, startLevel)
        {
            Description = "Allow to get percent on remaining gold.";
        }

        public override void Produce(YearlyBalance income)
        {
            
        }
    }
}
