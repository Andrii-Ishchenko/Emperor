using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.Core.States
{
    public abstract class TitleState
    {

        public abstract void HandleState(Game game);
    }
}
