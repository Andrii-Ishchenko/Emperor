using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.Core.Managers
{
    public class TradeManager
    {
        private Game _game;

        public TradeManager(Game game)
        {
            _game = game;
        }

        public bool CanBuy(Product product, long count)
        {
            return false;
        }

        public bool CanSell(Product product, long count)
        {
            return false;
        }

        public void Buy(Product product, long count)
        {

        }

        public void Sell(Product product, long count)
        {

        }

        public void GetPrice(Product product)
        {

        }
    }
}
