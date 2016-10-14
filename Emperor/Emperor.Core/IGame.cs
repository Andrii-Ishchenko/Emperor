using System.Collections.Generic;
using Emperor.Core.States;

namespace Emperor.Core
{
    public interface IGame
    {
        YearlyBalance NextTurn();
    }
}