using Emperor.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.WPF.ViewModels.DataVM
{
    public class YearlyBalanceVM 
    {
        private YearlyBalance _balance;

        public YearlyBalanceVM(YearlyBalance balance)
        {
            _balance = balance;
        }

        public int Year
        {
            get { return _balance.Year; }
        }

        public long CitizensGrowth
        {
            get { return _balance.CitizensGrowth; }
        }

        public long CitizensLost
        {
            get { return _balance.CitizensLost; }
        }

        public long CitizensDelta
        {
            get { return _balance.CitizensDelta; }
        }

        public long SoldiersGrowth
        {
            get { return _balance.SoldiersGrowth; }
        }

        public long SoldiersLost
        {
            get { return _balance.SoldiersLost; }
        }

        public long SoldiersDelta
        {
            get { return _balance.SoldiersDelta; }
        }

        public long GoldGrowth
        {
            get { return _balance.GoldGrowth; }
        }

        public long GoldLost
        {
            get { return _balance.GoldLost; }
        }

        public long GoldDelta
        {
            get { return _balance.GoldDelta; }
        }

        public long FoodGrowth
        {
            get { return _balance.FoodGrowth; }
        }

        public long FoodConsumed
        {
            get { return _balance.FoodConsumed; }
        }

        public long FoodLost
        {
            get { return _balance.FoodLost; }
        }

        public long FoodDelta
        {
            get { return _balance.FoodDelta; }
        }

        public long IronGrowth
        {
            get { return _balance.IronGrowth; }
        }

        public long IronConsumed
        {
            get { return _balance.IronConsumed; }
        }

        public long IronLost
        {
            get { return _balance.IronLost; }
        }

        public long IronDelta
        {
            get { return _balance.IronDelta; }
        }

        public long WeaponGrowth
        {
            get { return _balance.WeaponGrowth; }
        }

        public long WeaponLost
        {
            get { return _balance.WeaponLost; }
        }

        public long WeaponDelta
        {
            get { return _balance.WeaponDelta; }
        }

    }
}
