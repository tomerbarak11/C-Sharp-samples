using AteraAssignment;
using System;
using System.Collections.Generic;
using System.Text;

namespace AteraAssignment
{
    //this class is a wraper class that is referenced from main, holds a list of Carts from class Cart
    public class CartManager
    {
        private List<Cart> cartsList;
        private Store store;
        public CartManager(ref Store store)
        {
            this.store = store;
            cartsList = new List<Cart>();
            cartsList.Add(new Cart(ref store));
        }

        //creates a copy of last cart for safe copies
        public void add(String SKU)
        {
            Cart last = cartsList[cartsList.Count - 1];
            Cart tmp = last.copyCart();
            tmp.add(SKU);
            cartsList.Add(tmp);
        }

        public void undo()
        {
            if (cartsList.Count > 0)
            {
                cartsList.RemoveAt(cartsList.Count - 1);
            }
        }

        public void clearAllItems()
        {
            cartsList.Add(new Cart(ref store));
            Console.WriteLine(cartsList.Count);
        }

        public float checkOut()
        {
            return cartsList[cartsList.Count - 1].checkOut();
        }
        public void printCartName()
        {
            if (cartsList.Count > 0)
            {
                cartsList[cartsList.Count - 1].printCartName();
            }
        }

        public int getLastCartSize()
        {
            return (cartsList[cartsList.Count-1]).getCartProductsListSize();
        }
    }
}
