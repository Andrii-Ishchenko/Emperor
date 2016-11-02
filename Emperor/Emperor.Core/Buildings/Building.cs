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
            _buildRequirements = new List<Func<Game, bool>>();
            _names = new Dictionary<int, string>();
        }

        protected Dictionary<int,string> _names;
        protected List<Func<Game, bool>> _buildRequirements; 
        public string Name { get; protected set; }
        public int Price { get; protected set; }
        public int Level { get; protected set; }
        public string Description { get; protected set; }

        public abstract void Produce(YearlyBalance income);

        public bool CanBeBuilt(int quantity)
        {
            return  BuildingAvailable() && (quantity*Price <= _game.Gold) ;
        }

        public bool BuildingAvailable()
        {
            if (_buildRequirements == null || _buildRequirements.Count == 0)
                return true;
            return _buildRequirements.All(br => br.Invoke(_game) == true);
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
