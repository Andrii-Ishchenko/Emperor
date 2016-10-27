using Emperor.Core;
using System;

namespace Emperor.WPF.ViewModels.DataVM
{
    public class ProductVM : BaseVM
    {
        private Product _product;

        public ProductVM(Product product)
        {
            Product = product;
            product.ProductChanged += Update;
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

        public string Image
        {
            get { return string.Format(@"/Emperor.WPF;component/Resources/{0}.png", Name.ToLower()); }
        }

        public Product Product
        {
            get { return _product; }

            set { _product = value; }
        }

        public void Update(object sender, EventArgs eventArgs)
        {
            OnPropertyChanged(string.Empty);
        }

        
    }
}
