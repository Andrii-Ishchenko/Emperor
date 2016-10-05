using Emperor.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.WPF.ViewModels
{
    public class GameVM
    {
        public Game Game { get; set; }
        public GameVM()
        {
            Game = new Game();
        }
    }
}
