using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.Core.Buildings
{
    public class Bank : Building
    {
        private double _percentDeltaPerLevel;
        private double _startPercent;
        public double Percent { get; private set; }

        public Bank(Game game, int price, int startLevel) : base(game, "Bank", price, startLevel)
        {
            Description = "Allow to get percent on remaining gold.";
            _startPercent = 0.05;
            _percentDeltaPerLevel = 0.02;

        }

        public override void Produce(YearlyBalance income)
        {
            //TODO : REFACTOR, SET ONCE
            if (Level == 0)
                return;

            Percent = _startPercent + _percentDeltaPerLevel * (Level-1);

            income.GoldGrowth += (int)(_game.Gold * Percent);

        }

    }
}
