using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem
{
    public class ProductRepository
    {
        private List<Product> products = new List<Product>();

        public void AddProduct(Product product) => products.Add(product);
        public void UpdateProduct(Product product) => products.Add(product);
        public void RemoveProduct(string name) => products.RemoveAll(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        public Product GetProduct(string name) => products.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        public List<Product> GetAllProducts() => new List<Product>(products);

    }
}
