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

        }

        public bool CanBeBuilt(Building building, int count)
        {
            return true;
        }

        public bool IsBuildingAvailable(Building building, int count)
        {
            return true;
        }

        public void UpdateAvailability()
        {
            foreach(Building building in _buildings)
            {
               
            }
        }
    }
}
