﻿using Emperor.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.Core
{
    public class Rates
    {
        private Rate _foodRate;
        private Rate _taxRate;
        private Rate _socialRate;
        private Rate _armyRate;

        private RateCalculator calc = new RateCalculator();

        public Rate FoodRate
        {
            get
            {
                return _foodRate;
            }

            set
            {
                _foodRate = value;
            }
        }

        public Rate TaxRate
        {
            get
            {
                return _taxRate;
            }

            set
            {
                _taxRate = value;
            }
        }

        public Rate SocialRate
        {
            get
            {
                return _socialRate;
            }

            set
            {
                _socialRate = value;
            }
        }

        public Rate ArmyRate
        {
            get
            {
                return _armyRate;
            }

            set
            {
                _armyRate = value;
            }
        }

        public long GetConsumedFood(long citizens)
        {
            return calc.GetConsumedFood(citizens,FoodRate);
        }

        public long GetPayedTaxes (long citizens)
        {
            return calc.GetTaxes(citizens, TaxRate);
        }
    }
}