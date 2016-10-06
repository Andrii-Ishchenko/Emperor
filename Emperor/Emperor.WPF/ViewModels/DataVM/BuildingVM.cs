using Emperor.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.WPF.ViewModels.DataVM
{
    public class BuildingVM :BaseVM, IBuilding
    {

        private IBuilding _building;

        public BuildingVM(Building building)
        {
            _building = building;
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

        public bool CanBeBuiltQuantity(int quantity)
        {
            return _building.CanBeBuiltQuantity(quantity);
        }

        public void Produce(YearlyBalance income)
        {
            _building.Produce(income);
        }
    }
}
