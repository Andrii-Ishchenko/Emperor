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
    public class Game
    {
        public int Year { get; set; }
        public int MaxYear { get; set; }

        public long Gold { get; set; }

        public long Food
        {
            get
            {
                return GetProductByName("Food").Count;
            }
            set
            {
                GetProductByName("Food").Count = value;
            }
        }
        public long Iron
        {
            get
            {
                return GetProductByName("Iron").Count;
            }
            set
            {
                GetProductByName("Iron").Count = value;
            }
        }
        public long Weapons
        {
            get
            {
                return GetProductByName("Weapons").Count;
            }
            set
            {
                GetProductByName("Weapons").Count = value;
            }
        }

        public long Citizens { get; set; }
        public long Soldiers { get; set; }

        public long Happiness { get; set; }

        public TitleState TitleState { get; set; }

        public List<Building> Buildings { get; private set; }
        public List<Product> Products { get; private set; }

        public YearlyBalance Balance { get; set; }      
        public Dictionary<int,YearlyBalance> BalanceHistory { get; private set; }
        public Dictionary<int,Stats> StatsHistory { get; private set; } 
        public Rates Rates { get;private set; }

        public CitizenManager CitizenManager { get; private set; }
        public TradeManager TradeManager { get; private set; }
        public ArmyManager ArmyManager { get; private set; }

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
                
                new Product("Food", 3000, 2),
                new Product("Iron", 0, 80),
                new Product("Weapons", 0, 180)
            };

            Year = 0;
            MaxYear = 60;

            Gold = 20000;
         
            Citizens = 1000;
            Soldiers = 0;

            Happiness = 50;
            TitleState = new Count(this);
            Rates = new Rates
            {
                FoodRate = Rate.Average,
                ArmyRate = Rate.Average,
                SocialRate = Rate.None,
                TaxRate = Rate.Average
            };

            BalanceHistory = new Dictionary<int, YearlyBalance>();
            CitizenManager = new CitizenManager(this);
            TradeManager = new TradeManager(this);
            ArmyManager = new ArmyManager(this);
            Balance = new YearlyBalance();
            StatsHistory = new Dictionary<int, Stats>();

            SaveStats();
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
            CitizenManager.CalculateCitizensGrowth(Balance);    
            CitizenManager.CalculateCitizensLost(Balance);      
            CalculateDeltas(Balance);

            TitleState.HandleState();
            ApplyBalance(Balance);

            BalanceHistory.Add(Year, Balance);
            
            Year++;
            Balance = new YearlyBalance();

            //save stats here
            SaveStats();
            //
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
            balance.WeaponsDelta = balance.WeaponsGrowth - balance.WeaponsLost;
            balance.SoldiersDelta = balance.SoldiersGrowth - balance.SoldiersLost;
        }

        private void ApplyBalance(YearlyBalance balance)
        {
            Citizens += balance.CitizensDelta;
            Gold += balance.GoldDelta;
            Food += balance.FoodDelta;
            Iron += balance.IronDelta;
            Weapons += balance.WeaponsDelta;
            Soldiers += balance.SoldiersDelta;
        }

        private Product GetProductByName(string name)
        {
            return Products.FirstOrDefault(p => p.Name == name);
        }

        private void SaveStats()
        {
            Stats stats = new Stats();
            stats.Year = Year;
            stats.Gold = Gold;
            stats.Food = Food;
            stats.Iron = Iron;
            stats.Weapons = Weapons;
            stats.Citizens = Citizens;
            stats.Soldiers = Soldiers;
            stats.Happiness = Happiness;
            stats.TitleState = TitleState.Clone() as TitleState;

            StatsHistory.Add(Year, stats);
        }
    }
}
