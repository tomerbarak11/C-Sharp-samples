using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace AteraAssignment
{
    public class Store
    {
        private List<Product> productsList;

        //data is inserted from JSON file or SQL server
        public Store(ProductsProvider productsProvider)
        {
            initProducts(productsProvider);
        }

        private void initProducts(ProductsProvider productsProvider)
        {
            productsList = productsProvider.readProducts();
        }

        public void printStore()
        {
            Console.WriteLine("The store is:\n");
            foreach (Product product in productsList)
            {
                product.printPruductInfo();
            }
        }

        public List<Product> getProductsList()
        {
            return productsList;
        }

        public void addProduct(Product product)
        {
            productsList.Add(product);
        }
    }

}
