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
            AddGoldRequirement(20000);
            AddCastleRequirement(8);
            AddCitizenRequirement(7500);
        }

        public override void Promote()
        {
            _game.TitleState = new Emperor(_game);
        }
    }
}
