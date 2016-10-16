using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Emperor.Core.Buildings;
using Emperor.Core.Managers;
using Emperor.Core.States;
using Emperor.Core.Enums;

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

        public long Happiness { get; set; }

        public TitleState TitleState { get; set; }

        public List<Building> Buildings { get; private set; }
        public List<Product> Products { get; set; }

        public YearlyBalance Balance { get; set; }      
        public Dictionary<int,YearlyBalance> BalanceHistory { get; private set; }

        public Rates Rates { get;private set; }

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

            Products = new List<Product>()
            {
                new Product("Iron",0),
                new Product("Food",3800),
                new Product("Weapons",0)
            };

            Year = 0;
            MaxYear = 60;

            Gold = 2000;
            Food = 2500;
            Iron = 0;
            Weapons = 0;

            Citizens = 1000;
            Soldiers = 0;

            Happiness = 50;
            TitleState = new Count();
            Rates = new Rates();
            Rates.FoodRate = Rate.Average;
            Rates.ArmyRate = Rate.Average;
            Rates.SocialRate = Rate.None;
            Rates.TaxRate = Rate.Average;

            BalanceHistory = new Dictionary<int, YearlyBalance>();
            citizenManager = new CitizenManager(this);
            Balance = new YearlyBalance();
        }

        public YearlyBalance NextTurn()
        {
           
            Balance.Year = Year;

            foreach(var building in Buildings)
            {
                building.Produce(Balance);
            }

            CalculateLost(Balance);
            CalculateTaxes(Balance);
            ConsumeFood(Balance);
            citizenManager.CalculateCitizensGrowth(Balance);    
            citizenManager.CalculateCitizensLost(Balance);      
            CalculateDeltas(Balance);

            TitleState.HandleState(this);
            ApplyBalance(Balance);

            BalanceHistory.Add(Year, Balance);
            
            Year++;
            Balance = new YearlyBalance();
            return BalanceHistory.Last().Value; 
        }

        private void CalculateTaxes(YearlyBalance balance)
        {
            balance.GoldGrowth = Rates.GetPayedTaxes(Citizens);
        }

        private void CalculateLost(YearlyBalance balance)
        {
            balance.FoodLost = Utils.GetRandomInstance().Next(100);

            balance.SoldiersLost = (Soldiers>0) ? Math.Max(1, (int)(Soldiers * 0.02)) : 0;   
        }

        private void ConsumeFood(YearlyBalance balance)
        {
            long foodNeeded = Rates.GetConsumedFood(Citizens);
            balance.FoodConsumed = Math.Min(Food + balance.FoodGrowth - balance.FoodLost , foodNeeded);
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
