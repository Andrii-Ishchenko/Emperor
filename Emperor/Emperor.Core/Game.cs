using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Emperor.Core.Buildings;
using Emperor.Core.States;

namespace Emperor.Core
{
    public class Game
    {
        public int Year { get; set; }
        public int MaxYear { get; set; }

        public long Gold { get; set; }
        public long Food { get; set; }
        public long Iron { get; set; }
        public long Weapons { get; set; }

        public int Citizens { get; set; }
        public int Military { get; set; }

        public TitleState TitleState { get; set; }

        public List<Building> buildings { get; private set; }

        public Game()
        {
            buildings = new List<Building>()
            {
                new Farm(this, "Farm", 1000)
            };
        }
    }
}
