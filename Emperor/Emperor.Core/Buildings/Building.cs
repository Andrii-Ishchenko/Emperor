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

        protected Dictionary<int,string> _names;
        protected List<Func<Game, bool>> BuildRequirements; 
        public string Name { get; protected set; }
        public int Price { get; protected set; }
        public int Level { get; protected set; }
        public string Description { get; protected set; }

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
