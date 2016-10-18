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

        public void BuyFood(long count)
        {
            _game.Gold -= GetTotalFoodPrice(count);
            _game.Food += count;
        }

        public void SellFood(long count)
        {
            _game.Gold += GetTotalFoodPrice(count);
            _game.Food -= count;
        }
        public bool CanBuyFood(long count)
        {
            return GetTotalFoodPrice(count) <= _game.Gold;
        }
        public bool CanSellFood(long count)
        {
            return _game.Food >= count;
        }
        public double GetFoodPrice()
        {
            return 1.1;
        }

        public long GetTotalFoodPrice(long count)
        {
            return (long) (GetFoodPrice()*count);
        }

        public void BuyIron(long count) { }
        public void SellIron(long count) { }
        public bool CanBuyIron(long count)
        {
            return true;
        }
        public bool CanSellIron(long count)
        {
            return true;
        }

        public void BuyWeapons(long count) { }
        public void SellWeapons(long count) { }
        public bool CanBuyWeapons(long count)
        {
            return true;
        }
        public bool CanSellWeapons(long count)
        {
            return true;
        }
    }
}
