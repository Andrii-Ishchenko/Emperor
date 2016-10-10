using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Emperor.Core.Managers
{
    public class CitizenManager
    {
        private Game _game;

        public CitizenManager(Game game)
        {
            _game = game;
        }

        public void CalculateCitizensGrowth(YearlyBalance balance)
        {
            var goldCoef = 1 + Math.Sqrt(_game.Gold / 1000.0);
            balance.CitizensGrowth = Convert.ToInt64(goldCoef * (_game.Citizens / 2500 + (_game.Citizens) * (_game.Citizens) / 125000) + 1);
        }

        public void CalculateCitizensLost(YearlyBalance balance)
        {
            balance.CitizensLost = ((_game.Citizens + 2 * _game.Soldiers) - balance.FoodConsumed);
        }
    }
}
