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
            var goldCoef = 1 + Math.Pow(_game.Gold / 1000.0, 0.3);
            var happyCoef = -0.5 + 2.5*(_game.Happiness/100.0);

            var coef = goldCoef + happyCoef;

            if (coef < 0)
            {
                balance.CitizensGrowth = 0;
                return;
            }
                                 
            balance.CitizensGrowth = Convert.ToInt64(coef * (_game.Citizens / 130.0)  + 1);
        }

        public void CalculateCitizensLost(YearlyBalance balance)
        {
            long foodNeeded = _game.Rates.GetNeededFood(_game.Citizens);
            long consumed =  (RateCalculator.GetNeededFood(_game.Citizens, _game.Rates.FoodRate) - balance.FoodConsumed);
            double coef = 0;
            if (consumed < foodNeeded)
            {
                coef = consumed/(double) foodNeeded;
                
            }

            balance.CitizensLost = (long)(coef*_game.Citizens);
        }
    }
}
