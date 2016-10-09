using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Emperor.Core
{
    public abstract class Building : IBuilding
    {
         protected Game _game;

        protected Building(Game game, string name, int price, int startCount)
        {
            _game = game;
            Price = price;
            Name = name;
            Count = startCount;
        }

        public string Name { get; private set; }

        public int Price { get; private set; }
        public int Count { get; private set; }

        public abstract void Produce(YearlyBalance income);

        public  bool CanBeBuiltQuantity(int quantity)
        {
            return (quantity*Price >= _game.Gold);
        }

        public virtual bool Build(int count)
        {
            if (_game.Gold < count * Price)
                return false;

            _game.Gold -= count * Price;
            Count += count;
            return true;
        }

        public virtual bool Sell(int count)
        {
            var sellCount = (int)Math.Min(count, Count);
            Count -= sellCount;
            _game.Gold += (sellCount * Price) / 2;
            return true;    
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
