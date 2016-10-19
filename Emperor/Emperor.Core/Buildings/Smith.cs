﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.Core.Buildings
{
    public class Smith : Building
    {

        public Smith(Game game,int price, int count) : base(game,"Smith", price, count)
        {

        }

        public override void Produce(YearlyBalance balance)
        {
            var maxProduceCount = 10 * Count;
            var takenIron = Math.Min(_game.Iron , maxProduceCount);
            balance.WeaponsGrowth = takenIron;// 1<->1
            balance.IronConsumed = takenIron;
        }
    }
}
