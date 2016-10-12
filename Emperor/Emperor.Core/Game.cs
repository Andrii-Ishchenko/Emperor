using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Emperor.Core.Buildings;
using Emperor.Core.Managers;
using Emperor.Core.States;

namespace Emperor.Core
{
    public class Game : IGame
    {
        public int Year { get; set; }
        public int MaxYear { get; set; }

        public long Gold { get; set; }
        public long Food { get; set; }
        public long Iron { get; set; }
        public long Weapons { get; set; }

        public long Citizens { get; set; }
        public long Soldiers { get; set; }

        public TitleState TitleState { get; set; }

        public List<Building> Buildings { get; private set; }
        public Dictionary<int,YearlyBalance> balanceHistory { get; private set; }

        private CitizenManager citizenManager;

        public Game()
        {
            Buildings = new List<Building>()
            {
                new Farm(this, 1000,1),
                new Market(this,2000,0),
                new Mine(this, 3000,0),
                new Smith(this,4000,0),
                new Castle(this,5000,0)
            };

            Year = 0;
            MaxYear = 60;

            Gold = 2000;
            Food = 2500;
            Iron = 0;
            Weapons = 0;

            Citizens = 1000;
            Soldiers = 0;

            TitleState = new Count();

            balanceHistory = new Dictionary<int, YearlyBalance>();
            citizenManager = new CitizenManager(this);
        }

        public YearlyBalance CalculateNextTurn()
        {
            YearlyBalance balance = new YearlyBalance();

            balance.Year = Year;

            foreach(var building in Buildings)
            {
                building.Produce(balance);
            }

            CalculateLost(balance);
            CalculateTaxes(balance);
            ConsumeFood(balance);
            citizenManager.CalculateCitizensGrowth(balance);    
            citizenManager.CalculateCitizensLost(balance);      
            CalculateDeltas(balance);

            TitleState.HandleState(this);
            ApplyBalance(balance);

            balanceHistory.Add(Year, balance);

            Year++;
            return balance; 
        }

        private void CalculateTaxes(YearlyBalance balance)
        {
            balance.GoldGrowth = Citizens;
        }

        private void CalculateLost(YearlyBalance balance)
        {
            balance.FoodLost = Utils.GetRandomInstance().Next(100);

            balance.SoldiersLost = (Soldiers>0) ? Math.Max(1, (int)(Soldiers * 0.02)) : 0;   
        }

        private void ConsumeFood(YearlyBalance balance)
        {
            balance.FoodConsumed = Math.Min(Food + balance.FoodGrowth - balance.FoodLost ,(Citizens+2*Soldiers));
        }



        private void CalculateDeltas(YearlyBalance balance)
        {
            balance.CitizensDelta = balance.CitizensGrowth - balance.CitizensLost;
            balance.GoldDelta = balance.GoldGrowth - balance.GoldLost;
            balance.FoodDelta = balance.FoodGrowth - balance.FoodLost - balance.FoodConsumed;
            balance.IronDelta = balance.IronGrowth - balance.IronLost - balance.IronConsumed;
            balance.WeaponDelta = balance.WeaponGrowth - balance.WeaponLost;
            balance.SoldiersDelta = balance.SoldiersGrowth - balance.SoldiersLost;
        }

        private void ApplyBalance(YearlyBalance balance)
        {
            Citizens += balance.CitizensDelta;
            Gold += balance.GoldDelta;
            Food += balance.FoodDelta;
            Iron += balance.IronDelta;
            Weapons += balance.WeaponDelta;
            Soldiers += balance.SoldiersDelta;
        }

    }
}
