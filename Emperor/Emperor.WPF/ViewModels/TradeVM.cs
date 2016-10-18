using Emperor.WPF.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Emperor.Core.Managers;

namespace Emperor.WPF.ViewModels
{
    public class TradeVM : BaseVM
    {
        private GameVM _gameVM;
        private TradeManager _tradeManager;
        public TradeVM(GameVM gameVM)
        {
            _gameVM = gameVM;
            _tradeManager = _gameVM.TradeManager;
            Multiplicator = 1;
            IncreaseMultiplicatorCommand = new RelayCommand(IncreaseMultiplicator, CanIncreaseMultiplicator);
            DecreaseMultiplicatorCommand = new RelayCommand(DecreaseMultiplicator, CanDecreaseMultiplicator);
            BuyFoodCommand = new RelayCommand(BuyFood,CanBuyFood);
            SellFoodCommand = new RelayCommand(SellFood, CanSellFood);
        }

        private long _multiplicator;

        public long Multiplicator
        {
            get
            {
                return _multiplicator;
            }

            set
            {
                _multiplicator = value;
                OnPropertyChanged(string.Empty);
            }
        }

        public GameVM Game { get { return _gameVM; } }

        public double FoodPrice { get { return _tradeManager.GetFoodPrice(); } }
        public long TotalFoodPrice { get { return _tradeManager.GetTotalFoodPrice(Multiplicator); } }


        public ICommand IncreaseMultiplicatorCommand { get; set; }

        public ICommand DecreaseMultiplicatorCommand { get; set; }

        public ICommand BuyFoodCommand { get; set; }
        public ICommand SellFoodCommand { get; set; }
        public ICommand BuyIronCommand { get; set; }
        public ICommand SellIronCommand { get; set; }
        public ICommand BuyWeaponsCommand { get; set; }
        public ICommand SellWeaponsCommand { get; set; }

        public bool CanIncreaseMultiplicator(object parameter)
        {
            return Multiplicator < long.MaxValue / 10;
        }
        public void IncreaseMultiplicator(object parameter)
        {
            
            Multiplicator *=  10;
        }

        public bool CanDecreaseMultiplicator(object parameter)
        {
            return Multiplicator >= 10;
        }
        public void DecreaseMultiplicator(object parameter)
        {
            Multiplicator /= 10;
        }

        public void BuyFood(object parameter)
        {
            //var count = (long) parameter;
            var count = Multiplicator;
            _tradeManager.BuyFood(count);

            OnPropertyChanged(string.Empty);
        }

        public void SellFood(object parameter)
        {
            //var count = (long)parameter;
            var count = Multiplicator;
            _tradeManager.SellFood(count);

            OnPropertyChanged(string.Empty);
        }
        public bool CanBuyFood(object parameter)
        {
            //var count = (long)parameter;
            var count = Multiplicator;
            return _tradeManager.CanBuyFood(count);
        }

        public bool CanSellFood(object parameter)
        {
            //var count = (long)parameter;
            var count = Multiplicator;
            return _tradeManager.CanSellFood(count);
        }

        public void BuyIron(object parameter) { }
        public void SellIron(object parameter) { }
        public bool CanBuyIron(object parameter)
        {
            return true;
        }
        public bool CanSellIron(object parameter)
        {
            return true;
        }

        public void BuyWeapons(object parameter) { }
        public void SellWeapons(object parameter) { }
        public bool CanBuyWeapons(object parameter)
        {
            return true;
        }
        public bool CanSellWeapons(object parameter)
        {
            return true;
        }


    }
}
