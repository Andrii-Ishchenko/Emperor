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
        public GraphVM GraphsVM { get; private set; }
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
            BuildingsVM.BuildingsChanged += (sender, args) => { OnPropertyChanged(string.Empty); };


            RatesVM = new RatesVM(this);

            ProductsVM = new ProductsVM(this);
            ProductsVM.FetchProducts(_game.Products);
            ProductsVM.ProductsChanged += (sender, args) => { OnPropertyChanged(string.Empty); };

            GraphsVM = new GraphVM(this);

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

        public long Wood
        {
            get { return _game.Wood; }

            set
            {
                _game.Wood = value;
                OnPropertyChanged("Wood");
            }
        }

        public long Stone
        {
            get { return _game.Stone; }

            set
            {
                _game.Stone = value;
                OnPropertyChanged("Stone");
            }
        }

        public long Tools
        {
            get { return _game.Tools; }

            set
            {
                _game.Tools = value;
                OnPropertyChanged("Tools");
            }
        }

        public long Horses
        {
            get { return _game.Horses; }

            set
            {
                _game.Horses = value;
                OnPropertyChanged("Horses");
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

        public BuildingManager BuildingManager
        {
            get { return _game.BuildingManager; }
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
                bw.ResizeMode = ResizeMode.CanMinimize; 
                var vm = new BalancePopupWindowVM(BalanceHistory.Last().Value, this);
                bw.DataContext = vm;
                bw.ShowDialog();
            }
            
            OnPropertyChanged(string.Empty);
        }


        //todo: remove\refactor
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
