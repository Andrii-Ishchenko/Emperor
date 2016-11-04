using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emperor.Core;
using Emperor.Core.Buildings;

namespace Emperor.WPF.ViewModels.DataVM.Buildings
{
    public class FarmVM : BuildingVM
    {
        private Farm _farm;

        public FarmVM(Building building) : base(building)
        {
            _farm = building as Farm;
        }

        public int Horses
        {
            get { return _farm.Horses; }
            set
            {
                if (value<=MaxHorses)
                {
                    _farm.Horses = value;
                    OnPropertyChanged(string.Empty);
                }
            }
        }

        public int MaxHorses
        {
            get { return _farm.MaxHorses; }
        }

        public int FoodGrowth
        {
            get { return _farm.FoodGrowth; }
        }

        public int FoodPerHorse
        {
            get { return _farm.FoodPerHorse; }
        }
    }
}
