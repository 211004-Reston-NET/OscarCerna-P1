using System;
using System.Collections.Generic;
using BusinessLogic;
using Models;

namespace UserInterface
{
    public class ShowInventory : IMenu
    {  
         private StoreBL _storeBL;
        private InventoryBL _inventoryBL;
        public ShowInventory (StoreBL p_storeBL, InventoryBL p_inventoryBL)
        {
            this._storeBL = p_storeBL;
            this._inventoryBL = p_inventoryBL;
        }
        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("=== Inventory ===");
            Console.WriteLine();
            StoreFront foundStore = _storeBL.GetStoreById(Singleton.storeFront.StoreId);
            Console.WriteLine("Store ID: "+foundStore.StoreId);
            Console.WriteLine("Name: "+foundStore.StoreName);
            Console.WriteLine("Address: "+foundStore.StoreAddress);
            Console.WriteLine();
            Console.WriteLine("-----------------------------");
            Console.WriteLine();
            List<Inventory> listOfInventory = _inventoryBL.GetInventoryByStoreId(Singleton.inventory.StoreId);
            foreach (Inventory item in listOfInventory)
            {
                Console.WriteLine("Product ID: "+item.ProductId);
                Console.WriteLine("Name: "+item);
                Console.WriteLine("Brand: "+item);
                Console.WriteLine("Quantity: "+item.Quantity);
                Console.WriteLine("Price: " + item);
                Console.WriteLine();
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