using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.Core
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public long Count { get; set; }
        public double Price { get; set; }
        public double BuyPrice { get { return Price * 1.075; } }
        public double SellPrice { get { return Price * 0.93; } }

        public Product(string name, long count, double price)
        {
            Id = new Guid();
            Name = name;
            Count = count;
            Price = price;
        }
    }
}
