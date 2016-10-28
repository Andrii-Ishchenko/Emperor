using Emperor.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emperor.WPF.Commands;
using System.Windows.Input;
using System.Diagnostics;

namespace Emperor.WPF.ViewModels.DataVM
{
    public class BuildingVM : BaseVM
    {

        private Building _building;

        public BuildingVM(Building building)
        {
            _building = building;
            _buyBuildingCommand = new RelayCommand(Build, CanBeBuiltQuantity);

            _sellBuildingCommand = new RelayCommand(Sell, CanBeSoldQuantity);
        }

        public string Name => _building.Name;

        public int Count => _building.Count;

        public int Price => _building.Price;

        public ICommand BuyCommand
        {
            get { return _buyBuildingCommand; }

            set { _buyBuildingCommand = value; }
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

        public void Build(object parameter)
        {
            if (parameter == null)
                return;

            int count = Convert.ToInt32(parameter);

            var res = _building.Build(count);
            OnPropertyChanged("Count");

        }

        public void Sell(object parameter)
        {
            if (parameter == null)
                return;

            int count = Convert.ToInt32(parameter);

            var res = _building.Sell(count);
            OnPropertyChanged("Count");

        }

        public bool CanBeBuiltQuantity(object parameter)
        {
            // Debug.WriteLine("CanBeBuild :{0} \t\t {1}",Name,parameter==null?"NULL":parameter.ToString());
            if (parameter == null)
                return false;

            int count = Convert.ToInt32(parameter);

            return _building.CanBeBuiltQuantity(count);
        }

        public bool CanBeSoldQuantity(object parameter)
        {
            if (parameter == null)
                return false;

            int count = Convert.ToInt32(parameter);

            return _building.CanBeSoldQuantity(count);
        }

        private ICommand _buyBuildingCommand;
        private ICommand _sellBuildingCommand;


    }
}
