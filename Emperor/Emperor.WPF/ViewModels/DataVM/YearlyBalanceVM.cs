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

        public int CitizensGrowth
        {
            get { return _balance.CitizensGrowth; }
        }

        public int CitizensLost
        {
            get { return _balance.CitizensLost; }
        }

        public int CitizensDelta
        {
            get { return _balance.CitizensDelta; }
        }

        public int SoldiersGrowth
        {
            get { return _balance.SoldiersGrowth; }
        }

        public int SoldiersLost
        {
            get { return _balance.SoldiersLost; }
        }

        public int SoldiersDelta
        {
            get { return _balance.SoldiersDelta; }
        }

        public int GoldGrowth
        {
            get { return _balance.GoldGrowth; }
        }

        public int GoldLost
        {
            get { return _balance.GoldLost; }
        }

        public int GoldDelta
        {
            get { return _balance.GoldDelta; }
        }

        public int FoodGrowth
        {
            get { return _balance.FoodGrowth; }
        }

        public int FoodConsumed
        {
            get { return _balance.FoodConsumed; }
        }

        public int FoodLost
        {
            get { return _balance.FoodLost; }
        }

        public int FoodDelta
        {
            get { return _balance.FoodDelta; }
        }

        public int IronGrowth
        {
            get { return _balance.IronGrowth; }
        }

        public int IronConsumed
        {
            get { return _balance.IronConsumed; }
        }

        public int IronLost
        {
            get { return _balance.IronLost; }
        }

        public int IronDelta
        {
            get { return _balance.IronDelta; }
        }

        public int WeaponGrowth
        {
            get { return _balance.WeaponGrowth; }
        }

        public int WeaponLost
        {
            get { return _balance.WeaponLost; }
        }

        public int WeaponDelta
        {
            get { return _balance.WeaponDelta; }
        }

    }
}
