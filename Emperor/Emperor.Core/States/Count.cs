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
            AddGoldRequirement(5000);
            AddCastleRequirement(2);
            AddCitizenRequirement(1500);
        }

        public override void Promote()
        {
            _game.TitleState = new Duke(_game);
        }
    }
}
