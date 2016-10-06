using Emperor.Core;
using Emperor.WPF.ViewModels.DataVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emperor.Core.States;

namespace Emperor.WPF.ViewModels
{
    public class GameVM :BaseVM,IGame
    {
       
        public GameVM()
        {
            Game = new Game();
            Buildings = Game.Buildings.Select(x => new BuildingVM(x)).ToList();
        }

        private Game Game { get; set; }
        public List<BuildingVM> Buildings { get; private set; }

        public int Citizens
        {
            get
            {
                return Game.Citizens;
            }

            set
            {
                Game.Citizens = value;
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
            }
        }

        public int Soldiers
        {
            get
            {
                return Game.Soldiers;
            }

            set
            {
                Game.Soldiers = value;
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
            }
        }

        public void CalculateNextTurn()
        {
            Game.CalculateNextTurn();
        }

        public void Build(BuildingVM building, int count)
        {
            if (building.Build(count))
                OnPropertyChanged(String.Empty);

        }

        public void NextYear()
        {
            Game.CalculateNextTurn();
            OnPropertyChanged(String.Empty);
        }
    }
}
