using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.Core.Buildings
{
    public class Farm : Building
    {
       
        public Farm(Game game, int price, int level) : base(game, "Farm", price, level)
        {
            Description = "Farm allows you to get food as well as horses.";
            Horses = 0;
        }

        private int _foodPerHorse = 25;
        private int _horses;

        public int FoodPerHorse
        {
            get { return _foodPerHorse; }
            set { _foodPerHorse = value; }
        }

        public int MaxHorses
        {
            get { return (int) Math.Min((double) MeanGrowth/_foodPerHorse,5*Level); }
        }

        public int Horses
        {
            get { return _horses; }
            set { _horses = value; }
        }

        public int MeanGrowth
        {
            get { return 400*Level; }
        }

        public int GrowthFluctuation
        {
            get { return 100 * Level; }
        }

        public int FoodGrowth
        {
            get { return MeanGrowth - Horses*(_foodPerHorse); }
        }

        public override void Produce(YearlyBalance balance)
        {          
            var delta = -GrowthFluctuation + Utils.GetRandomInstance().Next(2*GrowthFluctuation);
            var growth = MeanGrowth + delta;

            int horseCount = Math.Min((int) ((double) growth/_foodPerHorse), Horses);
            int horseFoodConsumed = horseCount*_foodPerHorse;

            var food = growth - horseFoodConsumed;

            balance.FoodGrowth += food;
            balance.HorsesGrowth += horseCount;
        }

    }
}
