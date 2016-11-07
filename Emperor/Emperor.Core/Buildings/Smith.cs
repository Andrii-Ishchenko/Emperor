using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.Core.Buildings
{
    public class Smith : Building
    {
        
        public int ProductionTotal { get { return Level*100; } }

        public int WeaponsCount { get; set; }
        public int MaxWeapons { get { return (int) (ProductionTotal/ProductionPerWeapon); } }
        public double WeaponsProductionTotal { get { return ProductionPerWeapon*WeaponsCount; } }
        public double ProductionPerWeapon { get { return 10; } }
        public double IronPerWeapon { get { return 2; } }
        public double WeaponsIronTotal { get { return IronPerWeapon*WeaponsCount; } }

        public int ToolsCount { get { return (int)Math.Floor(ToolsProductionTotal/ProductionPerTool); } }
        public double ToolsProductionTotal { get { return ProductionTotal - WeaponsProductionTotal; } }
        public double ProductionPerTool { get { return 5; } }
        public double IronPerTool { get { return 1.2; } }
        public double ToolsIronTotal {  get { return IronPerTool*ToolsCount; } }

        public int IronTotal { get { return (int) Math.Ceiling(ToolsIronTotal + WeaponsIronTotal); } }

        public Smith(Game game,int price, int level) : base(game,"Smith", price, level)
        {
            Description = "Required to produce weapons and tools";
            WeaponsCount = 0;
        }

        public override void Produce(YearlyBalance balance)
        {
            var maxProduceCount = 10 * Level;
            var takenIron = Math.Min(_game.Iron , maxProduceCount);
            balance.WeaponsGrowth = takenIron;// 1<->1
            balance.IronConsumed = takenIron;
        }
    }
}
