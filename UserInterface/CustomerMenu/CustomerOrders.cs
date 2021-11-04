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
            List<Orders> listOfOrder = _orderBL.GetAllStoreOrdersById(Singleton.orders.CustomerId);
            foreach (Orders item in listOfOrder)
            {
                Console.WriteLine("Customer ID: "+item.CustomerId);
                 Console.WriteLine("Store ID: "+item.StoreId);
                Console.WriteLine("Order ID: "+item.OrderId);
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
                    return MenuType.OrderHistory;
                default:
                    Console.WriteLine("Invalid Selection!");
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadLine();
                    return MenuType.MainMenu;
            }
        }
    }
}