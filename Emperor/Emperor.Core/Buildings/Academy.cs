using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.Core.Buildings
{
    public class Academy : Building
    {
        //allow to learn new technologies
        //each lvl allow to learn new technology

        public Academy(Game game, int price, int startLevel) : base(game, "Academy", price, startLevel)
        {
        }

        public override void Produce(YearlyBalance income)
        {
           
        }
    }
}
