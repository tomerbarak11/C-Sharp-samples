using System;

namespace AteraAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            //user chooses to read from JSON or SQL
            Console.Write("Type JSON to read from a JSON file OR type SQL to read from a SQL file:\n\n");
            String option = Console.ReadLine();

            ProductsProvider productsProvider;

            if (option == "JSON")
            {
                productsProvider = new JSONProductsProviderImpl();
            }
            else
            {
                productsProvider = new SQLProductsProviderImpl();
            }
            //store is the same store in all program so it can be used as a reference
            Store store = new Store(productsProvider);
            CartManager cm = new CartManager(ref store);
            store.printStore();
            //UI menu with the options add / undo / clear / checkout
            while (true)
            {
                Console.WriteLine("Type an action of the following: add / undo / clear / checkout");
                String action = Console.ReadLine();
                switch (action)
                {
                    case "add":
                        String addSKU = Console.ReadLine();
                        cm.add(addSKU);
                        break;

                    case "undo":
                        cm.undo();
                        break;

                    case "clear":
                        cm.clearAllItems();
                        break;

                    case "checkout":
                        Console.WriteLine("Total price of cart: " + cm.checkOut() + "\n");
                        break;

                    default:
                        Console.WriteLine("Unknown command, please try again" + "\n");
                        break;
                }
                cm.printCartName();
            }
        }
    }
}
