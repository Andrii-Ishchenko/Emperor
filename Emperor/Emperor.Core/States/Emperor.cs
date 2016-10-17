using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.Core.States
{
    public class Emperor : TitleState
    {
        public Emperor(Game game) : base(game)
        {
            _titleName = "Emperor";
        }

        public override void Promote()
        {
            //check end game
        }
    }
}
