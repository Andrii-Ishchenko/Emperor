using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.Core.States
{
    public class Duke :TitleState
    {
        public Duke()
        {
            _titleName = "Duke";
        }

        public override void HandleState(Game game)
        {
            if (game.Gold > 10000)
                game.TitleState = new Prince();
        }
    }
}
