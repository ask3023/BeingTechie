using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebRouting
{
    public interface IProductRepository
    {
        List<Product> RetrieveProducts();
    }

    public class ProductRepository : IProductRepository
    {
        public List<Product> RetrieveProducts()
        {
            // Usually repository contains code to read from database. 
            // Below code returns sample data for demonstration purpose

            var products = new List<Product>();

            var p1 = new Product()
            {
                Id = 1,
                Name = "Pen",
                Price = 2.3M
            };

            products.Add(p1);

            var p2 = new Product()
            {
                Id = 2,
                Name = "Pencil",
                Price = 1.2M
            };

            products.Add(p2);

            return products;
        }

    }
}