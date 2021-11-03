using System;

namespace UserInterface
{
    public class MainMenu : IMenu
    {
        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Store App!\r\n");
            Console.WriteLine();
            Console.WriteLine("[1] Customer Menu");
            Console.WriteLine("[2] Store Menu");
            Console.WriteLine("[0] Exit Application");
        }
        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "1":
                    return MenuType.CustomerMenu;
                case "2":
                    return MenuType.StoreMenu;
                case "0":
                    return MenuType.Exit;
                default:
                    Console.WriteLine("Invalid Selection!");
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadLine();
                    return MenuType.MainMenu;
            }
        }
    }
}