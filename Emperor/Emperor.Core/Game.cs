using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Emperor.Core.Buildings;
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

        public int Citizens { get; set; }
        public int Soldiers { get; set; }

        public TitleState TitleState { get; set; }

        public List<Building> Buildings { get; private set; }

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

            Gold = 100000;
            Food = 1000;
            Iron = 0;
            Weapons = 1000;

            Citizens = 1000;
            Soldiers = 0;

        }

        public void CalculateNextTurn()
        {
            YearlyBalance balance = new YearlyBalance();

            foreach(var building in Buildings)
            {
                building.Produce(balance);
            }

            CalculateLost(balance);         
        }

        private void CalculateLost(YearlyBalance balance)
        {
            balance.FoodLost = 50;
        }

    }
}
