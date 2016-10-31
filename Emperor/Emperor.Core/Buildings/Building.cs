using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Emperor.Core
{
    public abstract class Building
    {
         protected Game _game;

        protected Building(Game game, string name, int price, int startLevel)
        {
            _game = game;
            Price = price;
            Name = name;
            Level = startLevel;
        }

        private Dictionary<int,string> _names;  

        public string Name { get; private set; }

        public int Price { get; private set; }
        public int Level { get; private set; }

        public abstract void Produce(YearlyBalance income);

        public bool CanBeBuiltQuantity(int quantity)
        {
            return (quantity*Price <= _game.Gold);
        }

        public virtual bool Build(int count)
        {
            if (_game.Gold < count * Price)
                return false;

            _game.Gold -= count * Price;
            Level += count;          
            return true;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
