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
using Emperor.WPF.Views;
using Emperor.WPF.ViewModels.Views.Advice;

namespace Emperor.WPF.ViewModels
{
    public class GameVM : BaseVM
    {
        public AdviceVM AdviceVM { get; private set; }
        public ArmyVM ArmyVM { get; private set; }
        public BalancesVM BalancesVM { get; private set; }
        public BuildingsVM BuildingsVM { get; private set; }
        public RatesVM RatesVM { get; private set; }
        public ProductsVM ProductsVM { get; private set; }

        public GameVM()
        {
            _game = ((App) Application.Current).Game;
            _game.GameChanged += (o, a) => { OnPropertyChanged(string.Empty); };
            UpdateBalanceHistory();
            UpdateTitleState();

            //Command
            NextTurnCommand = new RelayCommand(NextTurn, CanNextTurn);
            ShowAdviceCommand = new RelayCommand(ShowAdvice);

            //OTHER VM INIT
            AdviceVM = new AdviceVM(this);

            ArmyVM = new ArmyVM(this);
            ArmyVM.RecruitEvent += ArmyVmOnRecruitEvent;

            BalancesVM = new BalancesVM(this);

            BuildingsVM = new BuildingsVM(this);
            BuildingsVM.FetchBuildings(_game.Buildings);
            //TODO: do as with tradevm
            foreach (var building in BuildingsVM.Buildings)
            {
                building.PropertyChanged += (sender, args) => { OnPropertyChanged(""); };
            }

            RatesVM = new RatesVM(this);

            ProductsVM = new ProductsVM(this);
            ProductsVM.FetchProducts(_game.Products);
            ProductsVM.ProductsChanged += (sender, args) => { OnPropertyChanged(string.Empty); };

            ShowPopup = true;
        }


        private Game _game { get; set; }
        private TitleStateVM _titleStateVM;
        
        public bool ShowPopup { get; set; }

        //public List<ProductVM> Products { get; set; }
        public Dictionary<int, YearlyBalanceVM> BalanceHistory { get; private set; }

        public long Citizens
        {
            get { return _game.Citizens; }

            set
            {
                _game.Citizens = value;
                OnPropertyChanged("Citizens");
            }
        }

        public long Food
        {
            get { return _game.Food; }

            set
            {
                _game.Food = value;
                OnPropertyChanged("Food");
            }
        }

        public long Gold
        {
            get { return _game.Gold; }

            set
            {
                _game.Gold = value;
                OnPropertyChanged("Gold");
            }
        }

        public long Iron
        {
            get { return _game.Iron; }

            set
            {
                _game.Iron = value;
                OnPropertyChanged("Iron");
            }
        }

        public int MaxYear
        {
            get { return _game.MaxYear; }

            set
            {
                _game.MaxYear = value;
                OnPropertyChanged("MaxYear");
            }
        }

        public long Soldiers
        {
            get { return _game.Soldiers; }

            set
            {
                _game.Soldiers = value;
                OnPropertyChanged("Soldiers");
            }
        }

        public TitleStateVM TitleState
        {
            get { return _titleStateVM; }

            set
            {
                _titleStateVM = value;
                OnPropertyChanged("TitleState");
            }
        }

        public long Weapons
        {
            get { return _game.Weapons; }

            set
            {
                _game.Weapons = value;
                OnPropertyChanged("Weapons");
            }
        }

        public int Year
        {
            get { return _game.Year; }

            set
            {
                _game.Year = value;
                OnPropertyChanged("Year");
            }
        }

        public bool IsGameEnd { get { return _game.IsGameEnd; } }

        public long Happiness
        {
            get { return _game.Happiness; }
            set
            {
                _game.Happiness = value;
                OnPropertyChanged("Happiness");
            }
        }

        public Rates Rates
        {
            get { return _game.Rates; }
        }

        public TradeManager TradeManager
        {
            get { return _game.TradeManager; }
        }

        public ArmyManager ArmyManager
        {
            get { return _game.ArmyManager; }
        }

        public void NextTurn(object parameter)
        {
            _game.NextTurn();
            UpdateBalanceHistory();
            UpdateTitleState();
            BalancesVM.FetchBalanceHistory();

            if (ShowPopup)
            {
                BalanceWindow bw = new BalanceWindow();
                var vm = new BalancePopupWindowVM(BalanceHistory.Last().Value, this);
                bw.DataContext = vm;
                bw.ShowDialog();
            }
            

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

        private void ArmyVmOnRecruitEvent(object sender, EventArgs eventArgs)
        {
            OnPropertyChanged(string.Empty);
        }

        public ICommand NextTurnCommand { get; private set; }
        public ICommand ShowAdviceCommand { get; private set; }

        public void ShowAdvice(object parameter)
        {
            AdviceWindow aw = new AdviceWindow();
            aw.DataContext = AdviceVM;
            aw.ShowDialog();
        }

        public bool CanNextTurn(object parameter)
        {
            return true;
        }
    }
}
