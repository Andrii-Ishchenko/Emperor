using Emperor.WPF.ViewModels.DataVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emperor.Core;
using Emperor.WPF.ViewModels.DataVM.Buildings;

namespace Emperor.WPF.ViewModels.Utils
{
    public class BuildingVMFactory
    {
        public static BuildingVM GetInstance(Building building)
        {
            if (building == null)
                return null;
            switch (building.Name)
            {
                case "Academy":
                    return new AcademyVM(building);
                case "Bank":
                    return new BankVM(building);
                case "Barracks":
                    return new BarracksVM(building);
                case "Castle":
                    return new CastleVM(building);
                case "Church":
                    return new ChurchVM(building);
                case "Farm":
                    return new FarmVM(building);
                case "Market":
                    return new MarketVM(building);
                case "Mine":
                    return new MineVM(building);
                case "Quarry":
                    return new QuarryVM(building);
                case "Sawmill":
                    return new SawmillVM(building);
                case "Smith":
                    return new SmithVM(building);
                case "Stable":
                    return new StableVM(building);
                case "Tavern":
                    return new TavernVM(building);
                default:
                    return new BuildingVM(building);
            }
        }
    }
}
