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
        protected int _count = 0;
        protected Game _game;

        protected Building(Game game,string name, int price)
        {
            _game = game;
            Price = price;
            Name = name;
        }

        

        public string Name { get; private set; }

        public int Price { get; private set; }
        public int Count { get; private set; }

        public abstract void Produce();

        public  bool CanBuildQuantity(int quantity)
        {
            return (quantity*Price >= _game.Gold);
        }

        public abstract bool Build(int count);
    }
}
