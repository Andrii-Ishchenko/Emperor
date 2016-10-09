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

        public int CitizensGrowth { get; set; }
        public int CitizensLost { get; set; }
        public int CitizensDelta { get; set; }

        public int SoldiersGrowth { get; set; }
        public int SoldiersLost { get; set; }
        public int SoldiersDelta { get; set; }

        public int GoldGrowth { get; set; }
        public int GoldLost { get; set; }
        public int GoldDelta { get; set; }

        public int FoodGrowth { get; set; }
        public int FoodConsumed { get; set; }
        public int FoodLost { get; set; }
        public int FoodDelta { get; set; }

        public int IronGrowth { get; set; }
        public int IronConsumed { get; set; }
        public int IronLost { get; set; }
        public int IronDelta { get; set; }

        public int WeaponGrowth { get; set; }
        public int WeaponLost { get; set; }
        public int WeaponDelta { get; set; }

    }
}
