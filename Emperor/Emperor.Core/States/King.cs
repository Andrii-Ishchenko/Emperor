using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.Core.States
{
    public class King : TitleState
    {
        public King()
        {
            _titleName = "King";
        }

        public override void HandleState(Game game)
        {
            if (game.Gold > 25000)
                game.TitleState = new Emperor();
        }
    }
}
