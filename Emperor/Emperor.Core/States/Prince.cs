using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.Core.States
{
    public class Prince : TitleState
    {
        public Prince()
        {
            _titleName = "Prince";
        }

        public override void HandleState(Game game)
        {
            if (game.Gold > 15000)
                game.TitleState = new King();
        }
    }
}
