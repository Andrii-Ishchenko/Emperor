using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.Core.States
{
    public class Count : TitleState
    {
        public Count()
        {
            _titleName = "Count";
        }

        public override void HandleState(Game game)
        {
           if(game.Gold > 5000)
                game.TitleState = new Duke();
        }
    }
}
