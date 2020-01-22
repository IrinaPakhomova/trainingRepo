using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Shop.Goods
{
    public class ServiceProducts : IServiceProduct
    {
        public decimal Percent { get; set; } = 50;
        private List<Product> products;
        public ServiceProducts()
        {
            products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            if (GetTheSameProduct(product) != null)
            {
                ChangeProductCount(product);
            }
            else
            {
                products.Add(product);
            }
        }
        public Product GetTheSameProduct(Product product)
        {
            Product sameProduct = null;
            foreach (Product tempProduct in products)
            {
                if (tempProduct.Equals(product))
                {
                    sameProduct = tempProduct;
                    break;
                }
            }
            return sameProduct;
        }
        private void ChangeProductCount(Product product)
        {
            foreach (Product tempProduct in products)
            {
                if (tempProduct.Equals(product))
                {
                    tempProduct.Count += product.Count;
                    break;
                }
            }
        }
        public decimal AllProductsCosts()
        {
            decimal value = 0;
            foreach (Product item in products)
            {
                value += item.Price * item.Count;
            }
            return value;
        }
        public List<Product> GetAllProducts()
        {
            return this.products;
        }
        public decimal GetPercent() { return Percent; }


    }
}
