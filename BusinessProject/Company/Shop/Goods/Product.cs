using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Shop.Goods
{
    public class Product 
    {
        public string NameProduct { get; private set; }
        public decimal Price { get; private set; }
        public int Count { get; set; }
        
        public Product(string nameProduct, decimal price, int count)
        {
            NameProduct = nameProduct;
            Price = price;
            Count = count;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType()!=this.GetType()) return false;
            Product product = (Product)obj;
            return ((this.NameProduct == product.NameProduct) && (this.Price == product.Price));
        }

        public override string ToString()
        {
            return "Товар: " + this.NameProduct + ";  Цена: " + this.Price + "; Количество: " + this.Count;
        }
    }
}
