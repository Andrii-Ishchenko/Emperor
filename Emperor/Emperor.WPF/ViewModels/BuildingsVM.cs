using Emperor.Core;
using Emperor.WPF.ViewModels.DataVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.WPF.ViewModels
{
    public class BuildingsVM :BaseVM
    {
        public BuildingsVM(GameVM gameVM)
        {
                 
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
        

        public event EventHandler BuildingsChanged;

        protected void OnBuildingsChanged()
        {
            if (BuildingsChanged != null)
                BuildingsChanged(this, new EventArgs());
        }
    }
}
