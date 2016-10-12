using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Emperor.WPF.ViewModels.DataVM;

namespace Emperor.WPF.Commands
{
    public class BuyBuildingCommand : ICommand
    {
        private BuildingVM building;

        public BuyBuildingCommand(BuildingVM building)
        {
            this.building = building;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            building.Build(1);
        }

        public event EventHandler CanExecuteChanged;
    }
}
