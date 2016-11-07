using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.Core.Managers
{
    public class BuildingManager
    {
        private List<Building> _buildings;
        private Game _game;

        public BuildingManager(Game game)
        {
            _game = game;
            _buildings = game.Buildings;
        }

        public void Build(Building building, int count)
        {
            if (CanBeBuilt(building, count))
            {
                building.Level += count;
                _game.Gold -= count * building.Price;
            }

            building.OnBuild();
            UpdateAvailability();
        }

        public bool CanBeBuilt(Building building, int count)
        {
            if (!IsBuildingAvailable(building))
                return false;

            if (building.Price * count <= _game.Gold)
                return true;

            return false;
        }

        public bool IsBuildingAvailable(Building building)
        {
            return building.BuildingAvailable();
        }

        public void UpdateAvailability()
        {
            foreach(Building building in _buildings)
            {
                building.BuildingAvailable();
            }
        }
    }
}
