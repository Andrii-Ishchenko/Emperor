using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.Core.States
{
    public class Prince : TitleState
    {
        public Prince(Game game) : base(game)
        {
            _titleName = "Prince";
            PromotionRequirements.Add("Gold", (g) => { return (g.Gold > 15000); });
        }

        public override void Promote()
        {
            _game.TitleState = new King(_game);
        }
    }
}
