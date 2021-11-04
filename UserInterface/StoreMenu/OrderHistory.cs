using System;

namespace UserInterface
{
    public class OrderHistory : IMenu
    {
        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("=== View Order History ====");
            Console.WriteLine();
            Console.WriteLine("[1] - View Store Orders");
            Console.WriteLine("[2] - View Customer Orders");
            Console.WriteLine("[0] - Go Back");

        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "0":
                    return MenuType.StoreMenu;    
                case "1":
                Console.WriteLine("Enter Store ID");
                Singleton.orders.StoreId = Int32.Parse(Console.ReadLine());
                return MenuType.StoreOrders;

                case "2":
                Console.WriteLine("Enter Customer ID");
                Singleton.orders.CustomerId = Int32.Parse(Console.ReadLine());
                return MenuType.CustomerOrders;

                default:
                    Console.WriteLine("Invalid Selection!");
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadLine();
                    return MenuType.OrderHistory;
            }
        }
    }
}