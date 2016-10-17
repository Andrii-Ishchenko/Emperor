using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.Core.States
{
    public class King : TitleState
    {
        public King(Game game) : base(game)
        {
            _titleName = "King";
            PromotionRequirements.Add("Gold", (g) => { return (g.Gold > 30000); });
        }

        public override void Promote()
        {
            _game.TitleState = new Emperor(_game);
        }
    }
}
