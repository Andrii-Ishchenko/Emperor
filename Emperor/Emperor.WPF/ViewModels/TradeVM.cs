using Emperor.WPF.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Emperor.Core.Managers;
using Emperor.WPF.ViewModels.DataVM;

namespace Emperor.WPF.ViewModels
{
    public class TradeVM : BaseVM
    {
        private const long _multiplicatorMaxValue = 1000000000;
        private GameVM _gameVM;
        private TradeManager _tradeManager;
        public TradeVM(GameVM gameVM)
        {
            _gameVM = gameVM;
            _tradeManager = _gameVM.TradeManager;
            Multiplicator = 1;
            IncreaseMultiplicatorCommand = new RelayCommand(IncreaseMultiplicator, CanIncreaseMultiplicator);
            DecreaseMultiplicatorCommand = new RelayCommand(DecreaseMultiplicator, CanDecreaseMultiplicator);

            BuyCommand = new RelayCommand(Buy, CanBuy);
            SellCommand = new RelayCommand(Sell, CanSell);

            SelectedProduct = Products.FirstOrDefault();
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

        public List<ProductVM> Products { get { return _gameVM.Products; } }

        private ProductVM _selectedProduct;
        public ProductVM SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                if (_selectedProduct != value)
                {
                    _selectedProduct = value;
                    OnPropertyChanged("SelectedProduct");
                }
            }
        }
        public ICommand IncreaseMultiplicatorCommand { get; set; }

        public ICommand DecreaseMultiplicatorCommand { get; set; }

        public ICommand BuyCommand { get; set; }
        public ICommand SellCommand { get; set; }

        public bool CanIncreaseMultiplicator(object parameter)
        {
            return Multiplicator <= _multiplicatorMaxValue;
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

        public long TotalBuyPrice
        {
            get
            {
                return _tradeManager.GetTotalPriceBuy(SelectedProduct.Product, Multiplicator);
            }
        }

        public long TotalSellPrice
        {
            get
            {
                return _tradeManager.GetTotalPriceSell(SelectedProduct.Product, Multiplicator);
            }
        }

        public void Buy(object parameter)
        {
            _tradeManager.Buy(SelectedProduct.Product, Multiplicator);
            OnPropertyChanged(string.Empty);
        }

        public void Sell(object parameter)
        {
            _tradeManager.Sell(SelectedProduct.Product, Multiplicator);
            OnPropertyChanged(string.Empty);
        }

        public bool CanBuy(object parameter)
        {
            return _tradeManager.CanBuy(SelectedProduct.Product, Multiplicator);
        }

        public bool CanSell(object parameter)
        {
            return _tradeManager.CanSell(SelectedProduct.Product, Multiplicator);
        }
    }
}
