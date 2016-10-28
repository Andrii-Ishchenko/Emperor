using Emperor.Core;
using Emperor.WPF.Commands;
using Emperor.WPF.ViewModels.DataVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Emperor.WPF.ViewModels
{
    public class BuildingsVM :BaseVM
    {
        private long _multiplicatorMaxValue = 1000000000;

        public BuildingsVM(GameVM gameVM)
        {
            _multiplicator = 1;
            IncreaseMultiplicatorCommand = new RelayCommand(IncreaseMultiplicator, CanIncreaseMultiplicator);
            DecreaseMultiplicatorCommand = new RelayCommand(DecreaseMultiplicator, CanDecreaseMultiplicator);
        }

        public List<BuildingVM> Buildings { get; private set; }

        public void FetchBuildings (List<Building> buildings)
        {
            Buildings = buildings.Select(x => new BuildingVM(x)).ToList();
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

        public event EventHandler BuildingsChanged;

        protected void OnBuildingsChanged()
        {
            if (BuildingsChanged != null)
                BuildingsChanged(this, new EventArgs());
        }
    }
}
