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

        public Product(string name, long count)
        {
            Id = new Guid();
            Name = name;
            Count = count;
        }
    }
}
