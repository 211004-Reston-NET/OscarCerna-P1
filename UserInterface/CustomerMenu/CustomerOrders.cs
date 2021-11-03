using System;
using System.Collections.Generic;
using BusinessLogic;
using Models;

namespace UserInterface
{
    public class CustomerOrders : IMenu
    {
        private OrderBL _orderBL;
        public CustomerOrders (OrderBL p_orderBL)
        {
            this._orderBL = p_orderBL;
        }
        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("=== Customer Orders ===");
            Console.WriteLine();
            List<Orders> listOfOrder = _orderBL.GetAllStoreOrdersById(Singleton.orders.CustomerID);
            foreach (Orders item in listOfOrder)
            {
                Console.WriteLine("Customer ID: "+item.CustomerID);
                 Console.WriteLine("Store ID: "+item.StoreID);
                Console.WriteLine("Order ID: "+item.OrderID);
                Console.WriteLine("Order Date: "+item.OrderDate);
                Console.WriteLine("Total Price: "+item.TotalPrice);
            }   
                Console.WriteLine();
                Console.WriteLine("[0] Go Back");
        }

        public MenuType YourChoice()
         {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "0":
                    return MenuType.StoreMenu;
                default:
                    Console.WriteLine("Invalid Selection!");
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadLine();
                    return MenuType.MainMenu;
            }
        }
    }
}