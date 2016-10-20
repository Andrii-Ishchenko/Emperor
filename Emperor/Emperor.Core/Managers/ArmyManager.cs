using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.Core.Managers
{
    public class ArmyManager
    {
        private Game _game;

        public ArmyManager(Game game)
        {
            _game = game;
        }

        public long GetMaxRecruits()
        {
            return Math.Min(_game.Citizens - _game.Soldiers, _game.Weapons);
        }

        public void Recruit(long count)
        {
            if (count > GetMaxRecruits())
                return;

            _game.Soldiers += count;
            _game.Weapons -= count;
        }

        public bool CanRecruit(long count)
        {
            return count <= GetMaxRecruits();
        }
    }
}
