using Emperor.Core;
using Emperor.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.WPF.ViewModels
{
    public class RatesVM : BaseVM
    {
        private GameVM _gameVM;

        public RatesVM(GameVM gameVM)
        {
            _gameVM = gameVM;
        }

        public GameVM Game
        {
            get { return _gameVM; }
        }
        
        public Rate FoodRate
        {
            get
            {
                return _gameVM.Rates.FoodRate;
            }
            set
            {
                _gameVM.Rates.FoodRate = value;
                OnPropertyChanged("FoodRate");
                OnPropertyChanged("ConsumedFood");
            }
        }

        public Rate SocialRate
        {
            get
            {
                return _gameVM.Rates.SocialRate;
            }
            set
            {
                _gameVM.Rates.SocialRate = value;
                OnPropertyChanged("SocialRate");
                OnPropertyChanged("PayedGold");
            }
        }

        public Rate TaxRate
        {
            get
            {
                return _gameVM.Rates.TaxRate;
            }
            set
            {
                _gameVM.Rates.TaxRate = value;
                OnPropertyChanged("TaxRate");
                OnPropertyChanged("PayedTaxes");
            }
        }

        public Rate ArmyRate
        {
            get
            {
                return _gameVM.Rates.ArmyRate;
            }
            set
            {
                _gameVM.Rates.ArmyRate = value;
                OnPropertyChanged("ArmyRate");
            }
        }

        public long ConsumedFood
        {
            get { return _gameVM.Rates.GetConsumedFood(_gameVM.Citizens); }
        }

        public long PayedTaxes
        {
            get { return _gameVM.Rates.GetPayedTaxes(_gameVM.Citizens); }
        }

        public long PayedGold
        {
            get { return _gameVM.Rates.GetPayedGold(_gameVM.Citizens); }
        }
    }
}
