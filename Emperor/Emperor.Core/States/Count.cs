using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.Core.States
{
    public class Count : TitleState
    {
        public Count(Game game) : base(game)
        {
            _titleName = "Count";
            PromotionRequirements.Add("Gold", (g) => { return (g.Gold > 5000); });
        }

        public override void Promote()
        {
            _game.TitleState = new Duke(_game);
        }
    }
}
