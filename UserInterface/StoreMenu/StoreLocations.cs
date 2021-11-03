using System;
using System.Collections.Generic;
using BusinessLogic;
using Models;

namespace UserInterface
{
    public class StoreLocations : IMenu
    {
        private StoreBL _storeBL;
        public StoreLocations (StoreBL p_storeBL)
        {
            _storeBL = p_storeBL;
        }
        public void Menu()
        {
            Console.Clear();
            Console.WriteLine(" ==== Store Locations ====");
            List<StoreFront> listOfStores = _storeBL.GetAllStores();
            foreach (StoreFront store in listOfStores)
            {
                Console.WriteLine();
                Console.WriteLine(store);
                Console.WriteLine("------------");
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
                    return MenuType.StoreLocations;
            }
        }
    }
}