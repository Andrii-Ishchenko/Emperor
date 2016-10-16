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
        private RateCalculator calc = new RateCalculator();
        public CitizenManager(Game game)
        {
            _game = game;
        }

        public void CalculateCitizensGrowth(YearlyBalance balance)
        {
            var goldCoef = 1 + Math.Sqrt(_game.Gold / 1000.0);
            balance.CitizensGrowth = Convert.ToInt64(goldCoef * (_game.Citizens / 165.0)  + 1);
        }

        public void CalculateCitizensLost(YearlyBalance balance)
        {
            balance.CitizensLost = (calc.GetConsumedFood(_game.Citizens,_game.Rates.FoodRate) - balance.FoodConsumed);
        }
    }
}
