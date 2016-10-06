using System.Collections.Generic;
using Emperor.Core.States;

namespace Emperor.Core
{
    public interface IGame
    {
        int Citizens { get; set; }
        long Food { get; set; }
        long Gold { get; set; }
        long Iron { get; set; }
        int MaxYear { get; set; }
        int Soldiers { get; set; }
        TitleState TitleState { get; set; }
        long Weapons { get; set; }
        int Year { get; set; }

        void CalculateNextTurn();
    }
}