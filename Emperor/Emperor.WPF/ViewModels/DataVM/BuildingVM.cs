﻿using Emperor.Core;
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
            Building = building;
            Building.BuildingChanged += (s, a) =>
            {
                OnPropertyChanged(string.Empty);
            };
          //  _buyBuildingCommand = new RelayCommand(Build, CanBeBuilt);
        }

        public string Name => _building.Name;

        public int Level => _building.Level;

        public int Price => _building.Price;

        public string Description => _building.Description;

        public bool BuildingAvailable => _building.IsBuildingAvailable;

        public bool DetailsViewAvailable => _building.Level > 0;
        //public ICommand BuyCommand
        //{
        //    get { return _buyBuildingCommand; }

        //    set { _buyBuildingCommand = value; }
        //}

        public Building Building
        {
            get { return _building; }

            private set { _building = value; }
        }

        //public void Build(object parameter)
        //{
        //    if (parameter == null)
        //        return;

        //    int count = Convert.ToInt32(parameter);

        //    var res = _building.Build(count);
        //   // OnPropertyChanged(string.Empty);

        //}

        //public bool CanBeBuilt(object parameter)
        //{

        //    if (parameter == null)
        //        return false;

        //    int count = Convert.ToInt32(parameter);

        //    return _building.CanBeBuilt(count);
        //}

        //private ICommand _buyBuildingCommand;
       
    }
}
