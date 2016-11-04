using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.Core.Buildings
{
    public class Church : Building
    {
        //increase happiness level rise and decrease falls
        //provide gold = taxes / 10
        //each lvl +1 def
        //decrease probability of disaster
        public Church(Game game, int price, int startLevel) : base(game, "Church", price, startLevel)
        {
            Description = "Required to sustain citizen happiness and warrior defence capabilities";
        }

        public override void Produce(YearlyBalance income)
        {
           
        }
    }
}
