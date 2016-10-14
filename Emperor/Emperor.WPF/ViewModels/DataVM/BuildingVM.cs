using Emperor.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emperor.WPF.Commands;
using System.Windows.Input;

namespace Emperor.WPF.ViewModels.DataVM
{
    public class BuildingVM :BaseVM
    {

        private Building _building;

        public BuildingVM(Building building)
        {
            _building = building;
            _buyBuildingCommand = new RelayCommand(
                (obj)=> { Build(1); },
                (obj)=> { return CanBeBuiltQuantity(1); }
            );

            _sellBuildingCommand = new RelayCommand(
                (obj) => { Sell(1); },
                (obj) => { return CanBeSoldQuantity(1); }
            );
        }

        public string Name => _building.Name;

        public int Count => _building.Count;

        public int Price => _building.Price;

        public ICommand BuyCommand
        {
            get
            {
                return _buyBuildingCommand;
            }

            set
            {
                _buyBuildingCommand = value;
            }
        }
        public ICommand SellCommand
        {
            get
            {
                return _sellBuildingCommand;
            }
            set
            {
                _sellBuildingCommand = value;
            }
        }

        public bool Build(int count)
        {
            var res = _building.Build(count);
            OnPropertyChanged("Count");
            return res;
        }

        public bool Sell(int count)
        {
            var res = _building.Sell(count);
            OnPropertyChanged("Count");
            return res;
        }

        public bool CanBeBuiltQuantity(int quantity)
        {
            return _building.CanBeBuiltQuantity(quantity);
        }

        public bool CanBeSoldQuantity(int quantity)
        {
            return _building.CanBeSoldQuantity(quantity);
        }

        public void Produce(YearlyBalance income)
        {
            _building.Produce(income);
        }

        private ICommand _buyBuildingCommand;
        private ICommand _sellBuildingCommand;
    }
}
