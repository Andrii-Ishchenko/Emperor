using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.Core.Buildings
{
    public class Castle : Building
    {

        //TODO: each lvl opens different policies

        public Castle(Game game, int price, int startLevel) : base(game, "Castle", price, startLevel)
        {
            Description = "Required to get promoted. Opens policies when leveling up.";
        }

        public override void Produce(YearlyBalance income)
        {
            
        }


    }
}
