using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.Core.States
{
    public class Duke :TitleState
    {
        public Duke(Game game) : base(game)
        {
            _titleName = "Duke";
            PromotionRequirements.Add("Gold", (g) => { return (g.Gold > 10000); });
        }

        public override void Promote()
        {
            _game.TitleState = new Prince(_game);
        }
    }
}
