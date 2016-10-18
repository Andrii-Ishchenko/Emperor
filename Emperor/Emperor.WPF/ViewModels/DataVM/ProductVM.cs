using Emperor.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Emperor.WPF.ViewModels.DataVM
{
    public class ProductVM : BaseVM
    {
        private Product _product;

        public ProductVM(Product product)
        {
            Product = product;
        }

        public long Count
        {
            get { return Product.Count; }
            set
            {
                Product.Count = value;
                OnPropertyChanged("Count");
            }
        }

        public string Name
        {
            get { return Product.Name; }          
        }

        public double BuyPrice
        {
            get { return Product.BuyPrice; }         
        }

        public double SellPrice
        {
            get { return Product.SellPrice; }
        }

        public Product Product
        {
            get
            {
                return _product;
            }

            set
            {
                _product = value;
            }
        }
    }
}
