using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.Core.Managers
{
    public class BalanceManager
    {
        private Game _game;
       
        public BalanceManager(Game game)
        {
            _game = game;
        }

        private void CalculateTaxes(YearlyBalance balance)
        {
            balance.GoldGrowth = _game.Rates.GetPayedTaxes(_game.Citizens);
            
        }

        private void CalculateLost(YearlyBalance balance)
        {
            balance.FoodLost = Utils.GetRandomInstance().Next(100);

            balance.SoldiersLost = (_game.Soldiers > 0) ? Math.Max(1, (int)(_game.Soldiers * 0.02)) : 0;
        }

        private void ConsumeFood(YearlyBalance balance)
        {
            long foodNeeded = _game.Rates.GetConsumedFood(_game.Citizens);
            balance.FoodConsumed = Math.Min(_game.Food + balance.FoodGrowth - balance.FoodLost, foodNeeded);
        }

        private void CalculateDeltas(YearlyBalance balance)
        {
            balance.CitizensDelta = balance.CitizensGrowth - balance.CitizensLost;
            balance.GoldDelta = balance.GoldGrowth - balance.GoldLost;
            balance.FoodDelta = balance.FoodGrowth - balance.FoodLost - balance.FoodConsumed;
            balance.IronDelta = balance.IronGrowth - balance.IronLost - balance.IronConsumed;
            balance.WeaponsDelta = balance.WeaponsGrowth - balance.WeaponsLost;
            balance.SoldiersDelta = balance.SoldiersGrowth - balance.SoldiersLost;
        }

        private void CalculateHappinessDelta(YearlyBalance balance)
        {
            double delta = 0;

            delta += RateCalculator.GetTaxesHappinessDelta(_game.Rates.TaxRate);
            delta += RateCalculator.GetFoodHappinessDelta(_game.Rates.FoodRate);

            balance.HappinessDelta = delta;
        }

        public YearlyBalance CalculateBalance()
        {
            var balance = new YearlyBalance();

            balance.Year = _game.Year;

            foreach (var building in _game.Buildings)
            {
                building.Produce(balance);
            }

            CalculateLost(balance);
            CalculateTaxes(balance);
            ConsumeFood(balance);

            //TODO: pull reference from _game
            _game.CitizenManager.CalculateCitizensGrowth(balance);
            _game.CitizenManager.CalculateCitizensLost(balance);
            CalculateHappinessDelta(balance);
            CalculateDeltas(balance);

            return balance;
        }


    }
}
