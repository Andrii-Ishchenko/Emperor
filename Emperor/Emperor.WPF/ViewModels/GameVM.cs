using Emperor.Core;
using Emperor.WPF.ViewModels.DataVM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Emperor.Core.Managers;
using Emperor.Core.States;
using Emperor.WPF.Commands;
using System.Windows;

namespace Emperor.WPF.ViewModels
{
    public class GameVM :BaseVM
    {

        public AdviceVM AdviceVM { get;private set; }
        public BalancesVM BalancesVM { get;private set; }
        public BuildingsVM BuildingsVM { get; private set; }
        public RatesVM RatesVM { get; private  set; }
        public TradeVM TradeVM { get; private set; }
       
        public GameVM()
        {
            _game = ((App)Application.Current).Game;

            Products = _game.Products.Select(x => new ProductVM(x)).ToList();
          
           

            UpdateBalanceHistory();
            UpdateTitleState();
            //Command
            NextTurnCommand = new RelayCommand(NextTurn, CanNextTurn);

            //OTHER VM INIT
            AdviceVM = new AdviceVM(this);
            BalancesVM = new BalancesVM(this);
            BuildingsVM = new BuildingsVM(this);
            BuildingsVM.FetchBuildings(_game.Buildings);
            foreach (var building in BuildingsVM.Buildings)
            {
                building.PropertyChanged += (sender, args) => { OnPropertyChanged(""); };
            }

            RatesVM = new RatesVM(this);

            TradeVM = new TradeVM(this);
            TradeVM.TradeExecuted += (sender, args) => { OnPropertyChanged(string.Empty); };

            
        }

        private Game _game { get; set; }
        private TitleStateVM _titleStateVM;

        public List<ProductVM> Products { get; private set; }
        public Dictionary<int,YearlyBalanceVM> BalanceHistory { get; private set; } 

        public long Citizens
        {
            get
            {
                return _game.Citizens;
            }

            set
            {
                _game.Citizens = value;
                OnPropertyChanged("Citizens");
            }
        }

        public long Food
        {
            get
            {
                return _game.Food;
            }

            set
            {
                _game.Food = value;
                OnPropertyChanged("Food");
            }
        }

        public long Gold
        {
            get
            {
                return _game.Gold;
            }

            set
            {
                _game.Gold = value;
                OnPropertyChanged("Gold");
            }
        }

        public long Iron
        {
            get
            {
                return _game.Iron;
            }

            set
            {
                _game.Iron = value;
                OnPropertyChanged("Iron");
            }
        }

        public int MaxYear
        {
            get
            {
                return _game.MaxYear;
            }

            set
            {
                _game.MaxYear = value;
                OnPropertyChanged("MaxYear");
            }
        }

        public long Soldiers
        {
            get
            {
                return _game.Soldiers;
            }

            set
            {
                _game.Soldiers = value;
                OnPropertyChanged("Soldiers");
            }
        }

        public TitleStateVM TitleState
        {
            get
            {
                return _titleStateVM;
            }

            set
            {
                _titleStateVM = value;
                OnPropertyChanged("TitleState");
            }
        }

        public long Weapons
        {
            get
            {
                return _game.Weapons;
            }

            set
            {
                _game.Weapons = value;
                OnPropertyChanged("Weapons");
            }
        }

        public int Year
        {
            get
            {
                return _game.Year;
            }

            set
            {
                _game.Year = value;
                OnPropertyChanged("Year");
            }
        }

        public long Happiness
        {
            get { return _game.Happiness; }
            set { _game.Happiness = value;
                OnPropertyChanged("Happiness");
            }
        } 

        public Rates Rates
        {
            get
            {
                return _game.Rates;
            }
        }

        public TradeManager TradeManager { get { return _game.TradeManager; } }

        public void NextTurn(object parameter)
        {
            var balance = _game.NextTurn();          
            UpdateBalanceHistory();
            UpdateTitleState();
            BalancesVM.FetchBalanceHistory();
            OnPropertyChanged(string.Empty);
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

        private void UpdateBalanceHistory()
        {
            BalanceHistory =
               _game.BalanceHistory.ToDictionary(kvp => kvp.Key, kvp => new YearlyBalanceVM(kvp.Value));
        }

        private void UpdateTitleState()
        {
            _titleStateVM = new TitleStateVM(_game.TitleState);
        }

        public ICommand NextTurnCommand { get; private set; }
        public bool CanNextTurn(object parameter)
        {
            return true;
        }
    }
}
