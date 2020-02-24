using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AteraAssignment
{
    public class Product
    {
        private String name;
        private float price;
        private String SKU;

        public Product(String name, float price, String SKU)
        {
            this.name = name;
            this.price = price;
            this.SKU = SKU;
        }

        public String getName()
        {
            return name;
        }

        public float getPrice()
        {
            return price;
        }
        public String getSKU()
        {
            return SKU;
        }

        public void printPruductInfo()
        {
            Console.WriteLine("Name: " + name);
            Console.WriteLine("price: " + price);
            Console.WriteLine("SKU: " + SKU);
            Console.WriteLine("\n");
        }
    }

}
