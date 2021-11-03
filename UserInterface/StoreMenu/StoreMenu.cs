using System;

namespace UserInterface
{
    public class StoreMenu : IMenu
    {
        public void Menu()
        {
            Console.Clear();
            Console.WriteLine(" ==== Store Menu ====");
            Console.WriteLine();
            Console.WriteLine("[1] See Store Locations");
            Console.WriteLine("[2] View Inventory");
            Console.WriteLine("[3] Place Order");
            Console.WriteLine("[4] View Order History"); 
            Console.WriteLine("[0] Go Back");
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "0":
                    return MenuType.MainMenu;
                    
                case "1":
                    return MenuType.StoreLocations;

                case "2":
                    Console.WriteLine("Enter Store ID");
                    try
                    {
                        Singleton.inventory.StoreId = Int32.Parse(Console.ReadLine());
                        Singleton.storeFront.StoreID = Singleton.inventory.StoreId;
                    }
                    catch (System.Exception)
                    {                    
                        Console.WriteLine("Please Enter A Number!");
                        Console.WriteLine("Press Enter to Contine");
                        Console.ReadLine();
                        return MenuType.StoreMenu;
                    }    
                    return MenuType.ShowInventory;
                    
                case "3":
                    return MenuType.PlaceOrder;

                case "4":
                    return MenuType.OrderHistory;
                
                default:
                    Console.WriteLine("Invalid Selection!");
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadLine();
                    return MenuType.StoreMenu;
            }
        }
    }
}