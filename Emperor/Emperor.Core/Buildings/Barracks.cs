using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.Core.Buildings
{
    public class Barracks : Building
    {
        //allow to hire lvl2 warriors
        //each lvl allow to hire +5 warriors
        //each lvl +2 atck +1 def

        public Barracks(Game game, int price, int startLevel) : base(game, "Barracks", price, startLevel)
        {
            Description = "Allow to hire warriors.";
        }

        public override void Produce(YearlyBalance income)
        {
          
        }
    }
}
