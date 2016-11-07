using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.Core.Buildings
{
    public class Stable : Building
    {
        //allow to hire lvl3 warriors
        //each lvl grant passively 5 more horses per year
        //each lvl +2 atck +1 def to lvl3 units
        public Stable(Game game, int price, int startLevel) : base(game, "Stable", price, startLevel)
        {
            Description = "Allow to hire cavalry warriors.";
        }

        public override void Produce(YearlyBalance income)
        {
            
        }
    }
}
