using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.Core
{
    public class YearlyBalance
    {
        public int Year { get; set; }

        public long CitizensGrowth { get; set; }
        public long CitizensLost { get; set; }
        public long CitizensDelta { get; set; }

        public long SoldiersGrowth { get; set; }
        public long SoldiersLost { get; set; }
        public long SoldiersDelta { get; set; }

        public long GoldGrowth { get; set; }
        public long GoldLost { get; set; }
        public long GoldDelta { get; set; }

        public long FoodGrowth { get; set; }
        public long FoodConsumed { get; set; }
        public long FoodLost { get; set; }
        public long FoodDelta { get; set; }

        public long IronGrowth { get; set; }
        public long IronConsumed { get; set; }
        public long IronLost { get; set; }
        public long IronDelta { get; set; }

        public long WeaponsGrowth { get; set; }
        public long WeaponsLost { get; set; }
        public long WeaponsDelta { get; set; }

        public double HappinessDelta { get; set; }
    }
}
