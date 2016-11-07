using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.Core.Buildings
{
    public class Sawmill : Building
    {
        //produce wood
        //if we have tools produce wood x4 per tool
        //if we have free horse increase productivity +x2
        public Sawmill(Game game, int price, int startLevel) : base(game, "Sawmill", price, startLevel)
        {
            Description = "Allow to get wood";
        }

        public override void Produce(YearlyBalance income)
        {

        }
    }
}
