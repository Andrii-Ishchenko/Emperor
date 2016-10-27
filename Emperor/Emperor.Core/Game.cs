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

        public Dictionary<int,YearlyBalance> BalanceHistory { get; private set; }
        public Dictionary<int,Stats> StatsHistory { get; private set; } 
        public Rates Rates { get;private set; }

        public CitizenManager CitizenManager { get; private set; }
        public TradeManager TradeManager { get; private set; }
        public ArmyManager ArmyManager { get; private set; }
        public BalanceManager BalanceManager { get; private set; }

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

            Year = 1;
            MaxYear = 60;

            Gold = 2000;
         
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
            BalanceManager = new BalanceManager(this);
            StatsHistory = new Dictionary<int, Stats>();

            SaveStats();
        }

        public YearlyBalance NextTurn()
        {
           
            TitleState.HandleState();

            var balance = BalanceManager.CalculateBalance();

            ApplyBalance(balance);

            BalanceHistory.Add(Year, balance);
            
            Year++;

            SaveStats();

            OnGameChanged();

            return BalanceHistory.Last().Value; 
        }

        private void ApplyBalance(YearlyBalance balance)
        {
            Citizens += balance.CitizensDelta;
            Gold += balance.GoldDelta;
            Food += balance.FoodDelta;
            Iron += balance.IronDelta;
            Weapons += balance.WeaponsDelta;
            Soldiers += balance.SoldiersDelta;
            Happiness = (long)Math.Max(Math.Min(100, Happiness + balance.HappinessDelta),0);
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

        public event EventHandler GameChanged;

        protected void OnGameChanged()
        {
            if (GameChanged != null)
                GameChanged(this,new EventArgs());
        }
    }
}
