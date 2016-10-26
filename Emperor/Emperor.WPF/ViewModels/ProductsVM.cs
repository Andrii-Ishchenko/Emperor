using Emperor.WPF.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Emperor.Core;
using Emperor.Core.Managers;
using Emperor.WPF.ViewModels.DataVM;

namespace Emperor.WPF.ViewModels
{
    public class ProductsVM : BaseVM
    {
        private const long _multiplicatorMaxValue = 1000000000;
        private GameVM _gameVM;
        private TradeManager _tradeManager;

        public ProductsVM(GameVM gameVM)
        {
            _gameVM = gameVM;
            _tradeManager = _gameVM.TradeManager;

            _multiplicator = 1;
            IncreaseMultiplicatorCommand = new RelayCommand(IncreaseMultiplicator, CanIncreaseMultiplicator);
            DecreaseMultiplicatorCommand = new RelayCommand(DecreaseMultiplicator, CanDecreaseMultiplicator);

            BuyCommand = new RelayCommand(Buy, CanBuy);
            SellCommand = new RelayCommand(Sell, CanSell);       
        }

        public void FetchProducts(List<Product> products)
        {
            Products = products.Select(p => new ProductVM(p)).ToList();
            Products.ForEach(p => TradeExecuted += p.ParentChanged);
        }

        public GameVM Game { get { return _gameVM; } }

        private List<ProductVM> _products;

        public List<ProductVM> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                OnPropertyChanged("Products");
                if (value != null)
                    SelectedProduct = value.FirstOrDefault();
            }
        }

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
                    OnPropertyChanged("TotalBuyPrice");
                    OnPropertyChanged("TotalSellPrice");
                }
            }
        }

        #region Multiplicator

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

        public ICommand IncreaseMultiplicatorCommand { get; set; }
        public ICommand DecreaseMultiplicatorCommand { get; set; }

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

        #endregion

        #region Buy & Sell Commands

        public ICommand BuyCommand { get; set; }
        public ICommand SellCommand { get; set; }

        public void Buy(object parameter)
        {
            var productVM = parameter as ProductVM;
            _tradeManager.Buy(productVM.Product, Multiplicator);
            OnPropertyChanged("Products");
            OnTradeExecuted();
        }

        public void Sell(object parameter)
        {
            var productVM = parameter as ProductVM;
            _tradeManager.Sell(productVM.Product, Multiplicator);
            OnPropertyChanged("Products");
            OnTradeExecuted();
        }

        public bool CanBuy(object parameter)
        {
            if (parameter == null)
                return true;

            var productVM = parameter as ProductVM;
            return _tradeManager.CanBuy(productVM.Product, Multiplicator);
        }

        public bool CanSell(object parameter)
        {
            if (parameter == null)
                return true;

            var productVM = parameter as ProductVM;
            
            return _tradeManager.CanSell(productVM.Product, Multiplicator);
        }

        #endregion

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

        public event EventHandler TradeExecuted;

        protected void OnTradeExecuted()
        {
            if (TradeExecuted != null)
                TradeExecuted(this, new EventArgs());
        }
    }
}
