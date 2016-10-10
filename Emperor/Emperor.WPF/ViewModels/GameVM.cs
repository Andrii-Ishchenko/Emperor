﻿using Emperor.Core;
using Emperor.WPF.ViewModels.DataVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emperor.Core.States;

namespace Emperor.WPF.ViewModels
{
    public class GameVM :BaseVM
    {
       
        public GameVM()
        {
            Game = new Game();
            Buildings = Game.Buildings.Select(x => new BuildingVM(x)).ToList();
        }

        private Game Game { get; set; }
        public List<BuildingVM> Buildings { get; private set; }

        public long Citizens
        {
            get
            {
                return Game.Citizens;
            }

            set
            {
                Game.Citizens = value;
                OnPropertyChanged("Citizens");
            }
        }

        public long Food
        {
            get
            {
                return Game.Food;
            }

            set
            {
                Game.Food = value;
                OnPropertyChanged("Food");
            }
        }

        public long Gold
        {
            get
            {
                return Game.Gold;
            }

            set
            {
                Game.Gold = value;
                OnPropertyChanged("Gold");
            }
        }

        public long Iron
        {
            get
            {
                return Game.Iron;
            }

            set
            {
                Game.Iron = value;
                OnPropertyChanged("Iron");
            }
        }

        public int MaxYear
        {
            get
            {
                return Game.MaxYear;
            }

            set
            {
                Game.MaxYear = value;
                OnPropertyChanged("MaxYear");
            }
        }

        public long Soldiers
        {
            get
            {
                return Game.Soldiers;
            }

            set
            {
                Game.Soldiers = value;
                OnPropertyChanged("Soldiers");
            }
        }

        public TitleState TitleState
        {
            get
            {
                return Game.TitleState;
            }

            set
            {
                Game.TitleState = value;
                OnPropertyChanged("TitleState");
            }
        }

        public long Weapons
        {
            get
            {
                return Game.Weapons;
            }

            set
            {
                Game.Weapons = value;
                OnPropertyChanged("Weapons");
            }
        }

        public int Year
        {
            get
            {
                return Game.Year;
            }

            set
            {
                Game.Year = value;
                OnPropertyChanged("Year");
            }
        }

        public YearlyBalanceVM CalculateNextTurn()
        {
            var balance = Game.CalculateNextTurn();
            OnPropertyChanged(string.Empty);
            return new YearlyBalanceVM(balance);
        }

        public void Build(BuildingVM building, int count)
        {
            if (building.Build(count))
                OnPropertyChanged(string.Empty);

        }

        public void Sell(BuildingVM building, int count)
        {
            if (building.Sell(count))
                OnPropertyChanged(string.Empty);
        }
        
    }
}
