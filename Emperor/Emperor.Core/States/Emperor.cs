using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.Core.States
{
    public class Emperor : TitleState
    {
        public Emperor()
        {
            _titleName = "Emperor";
        }

        public override void HandleState(Game game)
        {
           
        }
    }
}
