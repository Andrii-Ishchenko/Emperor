using Emperor.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.WPF.ViewModels.DataVM
{
    public class BuildingVM
    {
        private Building _building;

        public BuildingVM(Building building)
        {
            _building = building;
        }

        public string Name => _building.Name;

        public int Count => _building.Count;

        public int Price => _building.Price;
    }
}
