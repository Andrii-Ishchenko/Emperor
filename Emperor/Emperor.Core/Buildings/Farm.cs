using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.Core.Buildings
{
    public class Farm : Building
    {
        public Farm(Game game, string name, int price) : base(game, name, price)
        {
        }

        public override void Produce()
        {
            throw new NotImplementedException();
        }

        public override bool Build(int count)
        {
            if (!CanBuildQuantity(count))
                return false;

            _game.Gold -= (count*Price);
            _count += count;

            return true;
        }
    }
}
