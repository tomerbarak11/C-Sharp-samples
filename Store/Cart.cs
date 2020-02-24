using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AteraAssignment
{
    public class Cart
    {
        private List<Product> cartProductsList;
        private Store store;


        public Cart(ref Store store)
        {
            cartProductsList = new List<Product>();
            this.store = store;
        }

        public void add(String SKU)
        {
            foreach (var i in store.getProductsList())
            {
                if (i.getSKU().Equals(SKU))
                {
                    cartProductsList.Add(i);
                    Console.WriteLine("Item was added\n");
                    return;
                }
            }
            Console.WriteLine("Item was not found\n");
        }

        public float checkOut()
        {
            float totalPrice = 0;
            foreach (var i in cartProductsList)
            {
                totalPrice += i.getPrice();
            }
            return totalPrice;
        }

        //creates a copy of a cart with all of its products
        public Cart copyCart()
        {
            Cart temp = new Cart(ref this.store); 
            foreach (var product in cartProductsList)
            {
                temp.cartProductsList.Add(product);
            }
            return temp;
        }

        public void printCartName()
        {
            Console.WriteLine("Your items are:\n");
            foreach (var product in cartProductsList)
            {
                Console.WriteLine("Name of product = " + product.getName() + "\n");
            }
        }

        public int getCartProductsListSize()
        {
            return cartProductsList.Count();
        }
    }
}
