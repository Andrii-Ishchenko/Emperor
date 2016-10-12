using Emperor.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emperor.WPF.Commands;

namespace Emperor.WPF.ViewModels.DataVM
{
    public class BuildingVM :BaseVM, IBuilding
    {

        private IBuilding _building;

        public BuildingVM(Building building)
        {
            _building = building;
            BuyCommand = new BuyBuildingCommand(this);
        }

        public string Name => _building.Name.ToUpper();

        public int Count => _building.Count;

        public int Price => _building.Price;

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

        public void Produce(YearlyBalance income)
        {
            _building.Produce(income);
        }

        public BuyBuildingCommand BuyCommand { get; set; }
    }
}
