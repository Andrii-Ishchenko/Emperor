using Emperor.Core.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.Core
{
    public class Stats
    {
        public int Year { get; set; }

        public long Gold { get; set; }
        public long Food { get; set; }
        public long Iron { get; set; }
        public long Weapons { get; set; }

        public long Citizens { get; set; }
        public long Soldiers { get; set; }

        public long Happiness { get; set; }
        public TitleState TitleState { get; set; }
    }
}
