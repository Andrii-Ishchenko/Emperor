using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.Core
{
    public class Product
    {
        private readonly string _name;
        private long _count;
        private double _price;

        public string Name
        {
            get { return _name; }
        }

        public long Count
        {
            get { return _count; }
            set
            {
                _count = value;
                OnProductChanged();
            }
        }

        public double Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnProductChanged();
            }
        }

        public double BuyPrice { get { return Price * 1.075; } }
        public double SellPrice { get { return Price * 0.93; } }

        public Product(string name, long count, double price)
        {
            _name = name;
            Count = count;
            Price = price;
        }

        public event EventHandler ProductChanged;

        protected void OnProductChanged()
        {
            if (ProductChanged != null)
                ProductChanged(this, new EventArgs());
        }
    }
}
