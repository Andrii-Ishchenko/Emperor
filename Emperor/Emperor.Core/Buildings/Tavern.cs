using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.Core.Buildings
{
    public class Tavern : Building
    {
        //passively increase happiness by 10 for citizens
        //each lvl decrease atck, def by 1
        //consume food 100
        //provide gold 200
        //increase human disaster chance
        public Tavern(Game game, int price, int startLevel) : base(game, "Tavern", price, startLevel)
        {
            Description = "Allow to greatly increase happiness, harming warrior capabilities, though.";
        }

        public override void Produce(YearlyBalance income)
        {
            
        }
    }
}
