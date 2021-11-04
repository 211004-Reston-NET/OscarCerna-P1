using System;
using System.Collections.Generic;
using BusinessLogic;
using Models;

namespace UserInterface
{
    public class PlaceOrder : IMenu
    {
        private StoreBL _storeBL;
        private CustomerBL _customerBL;
        private OrderBL _orderBL;
        
        public PlaceOrder (StoreBL p_storeBL, CustomerBL p_customerBL, OrderBL p_orderBL)
        {
            _storeBL = p_storeBL;
            _customerBL = p_customerBL;
            _orderBL = p_orderBL;
        }
        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("==== Order Information ====");
            Console.WriteLine();
            Console.WriteLine("[1] Select Customer");
            Console.WriteLine("[2] Select Store");
            Console.WriteLine();
            Console.WriteLine("Customer ID: "+Singleton.orders.CustomerId);
            Console.WriteLine("Store ID: "+Singleton.orders.StoreId);
            Console.WriteLine();
            Console.WriteLine("[4] Save Order");
            Console.WriteLine("[5] Add Item To Order ");
            Console.WriteLine("[0] Go Back");
            Console.WriteLine();
        }
        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "0":
                    return MenuType.StoreMenu;
                    
                case "1":
                    Console.WriteLine("Enter Customer ID");
                    Singleton.orders.CustomerId = Int32.Parse(Console.ReadLine());
                    return MenuType.PlaceOrder;

                case "2":
                    Console.WriteLine("Enter Store ID");
                    Singleton.orders.StoreId = Int32.Parse(Console.ReadLine());
                    return MenuType.PlaceOrder;

                case "4":
                    _orderBL.AddOrder(Singleton.orders);
                    return MenuType.PlaceOrder;

                case "5":
                return MenuType.AddItem;
                
                default:
                    Console.WriteLine("Invalid Selection!");
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadLine();
                    return MenuType.ShowStore;
            }
        }
    }
}