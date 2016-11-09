using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emperor.Core;
using Emperor.Core.Buildings;

namespace Emperor.WPF.ViewModels.DataVM.Buildings
{
    public class SmithVM : BuildingVM
    {
        private Smith _smith;

        public SmithVM(Building building) : base(building)
        {
            _smith = building as Smith;
        }

        public int ProductionTotal { get { return _smith.ProductionTotal; } }

        public int Weapons
        {
            get { return _smith.WeaponsCount; }
            set
            {
                _smith.WeaponsCount = value;
                OnPropertyChanged(string.Empty);
            }
        }
        public int MaxWeapons { get { return _smith.MaxWeapons; } }

        public bool ProduceWeapons
        {
            get
            {
                return _smith.ProduceWeapons;
            }
            set
            {
                _smith.ProduceWeapons = value;
                OnPropertyChanged("ProduceWeapons");
            }
        }

        public double WeaponsProductionTotal { get { return _smith.WeaponsProductionTotal; } }
        public double WeaponsIronTotal { get { return _smith.WeaponsIronTotal; } }

        public int Tools
        {
            get { return _smith.ToolsCount; }
        }

        public bool ProduceTools
        {
            get { return _smith.ProduceTools; }
            set
            {
                _smith.ProduceTools = value;
                OnPropertyChanged("ProduceTools");
            }
        }
        public double ToolsProductionTotal { get { return _smith.ToolsProductionTotal; } }
        public double ToolsIronTotal { get { return _smith.ToolsIronTotal; } }

        public int IronTotal { get { return _smith.IronTotal; } }
    }
}
