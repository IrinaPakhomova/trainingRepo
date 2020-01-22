using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Shop.Goods
{
    interface IServiceProduct
    {
        void AddProduct(Product product);

        Product GetTheSameProduct(Product product);

        decimal AllProductsCosts();

        List<Product> GetAllProducts();

        decimal GetPercent();
    }
}
