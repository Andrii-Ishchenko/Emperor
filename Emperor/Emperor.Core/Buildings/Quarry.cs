using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.Core.Buildings
{
    public class Quarry : Building
    {
        //provide stone
        //if we have tools provide x4
        //if we have horse provide +x2
        public Quarry(Game game, int price, int startLevel) : base(game, "Quarry", price, startLevel)
        {
            Description = "Allow to get stone";
        }

        public override void Produce(YearlyBalance income)
        {

        }
    }
}
