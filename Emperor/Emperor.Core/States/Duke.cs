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
            AddGoldRequirement(10000);
            AddCastleRequirement(4);
            AddCitizenRequirement(2000);
        }

        public override void Promote()
        {
            _game.TitleState = new Prince(_game);
        }
    }
}
