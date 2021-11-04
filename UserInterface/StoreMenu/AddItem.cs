using System;
using System.Collections.Generic;
using BusinessLogic;
using Models;

namespace UserInterface
{
    public class Additem : IMenu
    {
        private LineItemBL _lineItemBL;
        private OrderBL _orderBL;
        public Additem (LineItemBL p_lineItem, OrderBL p_orderBL)
        {
            _lineItemBL = p_lineItem;
            _orderBL = p_orderBL;
        }
        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("=== Adding Item ===");
            Console.WriteLine();
            Console.WriteLine("[1] Select Product");
            Console.WriteLine("[2] Select Quanity");
            Console.WriteLine("[3] Select OrderId");
            Console.WriteLine("-------------------");
            Console.WriteLine("Product ID: "+Singleton.lineItems.ProductId);      
            Console.WriteLine("Quantity: "+Singleton.lineItems.Quantity);
            Console.WriteLine("Order ID: "+Singleton.lineItems.OrderId);
            Console.WriteLine();
            Console.WriteLine("[4] Add Item");
        }

        public MenuType YourChoice()
       {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "1":
                Console.WriteLine("Enter Product ID");
                Singleton.lineItems.ProductId = Int32.Parse(Console.ReadLine());
                    return MenuType.AddItem;

                case "2":
                Console.WriteLine("Enter Quantity");
                Singleton.lineItems.Quantity = Int32.Parse(Console.ReadLine());
                    return MenuType.AddItem;

                case "3":
                List<Orders> listOfOrders = _orderBL.GetAllOrders();
                foreach (Orders orders in listOfOrders)
                {
                    Console.WriteLine(orders.OrderId);
                    Console.WriteLine(orders.OrderDate);
                }
                Console.WriteLine("Enter Order ID");
                Singleton.lineItems.OrderId = Int32.Parse(Console.ReadLine());
                return MenuType.AddItem;

                case "4":
                _lineItemBL.AddLineItems(Singleton.lineItems);
                return MenuType.StoreMenu;

                case "0":
                    return MenuType.MainMenu;
                default:
                    Console.WriteLine("Invalid Selection!");
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadLine();
                    return MenuType.MainMenu;
            }
        }
    }
}