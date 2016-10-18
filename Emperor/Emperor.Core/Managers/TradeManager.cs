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
            if (count < 0)
                return false;

            return GetTotalPriceBuy(product, count) <= _game.Gold;
        }

        public bool CanSell(Product product, long count)
        {
            if (count < 0)
                return false;

            return product.Count >= count;
        }

        public void Buy(Product product, long count)
        {
            if (CanBuy(product, count))
            {
                _game.Gold -= GetTotalPriceBuy(product, count);
                product.Count += count;
            }
        }

        public void Sell(Product product, long count)
        {
            if (CanSell(product, count))
            {
                _game.Gold += GetTotalPriceSell(product, count);
                product.Count -= count;
            }
        }

        public long GetTotalPriceBuy(Product product, long count)
        {
            return (long)Math.Ceiling(count * product.BuyPrice);
        }

        public long GetTotalPriceSell(Product product, long count)
        {
            return (long)Math.Floor(count * product.SellPrice);
        }
     
    }
}
