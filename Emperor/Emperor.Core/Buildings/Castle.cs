using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.Core.Buildings
{
    public class Castle : Building
    {
        public Castle(Game game, int price, int startCount) : base(game, "Castle", price, startCount)
        {

        }

        public override void Produce(YearlyBalance income)
        {
            throw new NotImplementedException();
        }

        public override bool Build(int count)
        {
            throw new NotImplementedException();
        }
    }
}
