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
        public Church(Game game, int price, int startLevel) : base(game, "Church", price, startLevel)
        {
        }

        public override void Produce(YearlyBalance income)
        {
            throw new NotImplementedException();
        }
    }
}
