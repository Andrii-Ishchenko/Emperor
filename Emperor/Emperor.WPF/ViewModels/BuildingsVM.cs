using Emperor.Core;
using Emperor.WPF.Commands;
using Emperor.WPF.ViewModels.DataVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Emperor.WPF.ViewModels.Utils;
using Emperor.Core.Managers;

namespace Emperor.WPF.ViewModels
{
    public class BuildingsVM :BaseVM
    {
        private long _multiplicatorMaxValue = 1000000000;
        private BuildingManager _buildingManager;

        public BuildingsVM(GameVM gameVM)
        {
            _multiplicator = 1;
            _buildingManager = gameVM.BuildingManager; 
            IncreaseMultiplicatorCommand = new RelayCommand(IncreaseMultiplicator, CanIncreaseMultiplicator);
            DecreaseMultiplicatorCommand = new RelayCommand(DecreaseMultiplicator, CanDecreaseMultiplicator);
            BuyCommand = new RelayCommand(Buy, CanBuy);

            BuildingsChanged += (s, e) => { OnPropertyChanged("Buildings"); };

        }

        public List<BuildingVM> Buildings { get; private set; }

        public void FetchBuildings (List<Building> buildings)
        {
            Buildings = buildings.Select(BuildingVMFactory.GetInstance).ToList();
            Buildings.ForEach(x=>x.PropertyChanged+=(s,a)=> {OnBuildingsChanged();});
            SelectedBuilding = Buildings.FirstOrDefault();
        }

        private BuildingVM _selectedBuilding;

        public BuildingVM SelectedBuilding
        {
            get { return _selectedBuilding; }
            set
            {
                _selectedBuilding = value; 
                OnPropertyChanged("SelectedBuilding");
            }
        }

        #region Multiplicator

        private int _multiplicator;
        public int Multiplicator
        {
            get
            {
                return _multiplicator;
            }

            set
            {
                _multiplicator = value;
                OnPropertyChanged("Multiplicator");
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

            Multiplicator += 1;
        }

        public bool CanDecreaseMultiplicator(object parameter)
        {
            return Multiplicator > 1;
        }
        public void DecreaseMultiplicator(object parameter)
        {
            Multiplicator -= 1; ;
        }

        #endregion

        public ICommand BuyCommand { get; private set; }

        public void Buy(object parameter)
        {
            BuildingVM building = parameter as BuildingVM;

            if (building == null)
                return;

            _buildingManager.Build(building.Building, Multiplicator);
            OnBuildingsChanged();
            
        }

        public bool CanBuy(object parameter)
        {
            BuildingVM building = parameter as BuildingVM;

            if (building == null)
                return false;

            return _buildingManager.CanBeBuilt(building.Building, Multiplicator);
        }

        public event EventHandler BuildingsChanged;

        protected void OnBuildingsChanged()
        {
            if (BuildingsChanged != null)
                BuildingsChanged(this, new EventArgs());


        }
    }
}
