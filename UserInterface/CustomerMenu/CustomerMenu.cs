using System;

namespace UserInterface
{
    public class CustomerMenu : IMenu
    {
        public void Menu()
        {
            Console.Clear();
            Console.WriteLine(" ==== Customer Menu ====");
            Console.WriteLine();
            Console.WriteLine("[1] Add Customer");
            Console.WriteLine("[2] Search Customer");
            Console.WriteLine("[0] Go Back");
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "1":
                    return MenuType.AddCustomer;
                case "2":
                    Console.WriteLine("Enter Customer ID");
                    try
                    {
                        Singleton.customer.CustomerId = Int32.Parse(Console.ReadLine());
                    }
                    catch (System.Exception)
                    {                    
                        Console.WriteLine("Please Enter A Number!");
                        Console.WriteLine("Press Enter to Contine");
                        Console.ReadLine();
                        return MenuType.CustomerMenu;
                    }       
                    return MenuType.ShowCustomer;
                case "0":
                    return MenuType.MainMenu;
                default:
                    Console.WriteLine("Invalid Selection!");
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadLine();
                    return MenuType.CustomerMenu;
            }
        }
    }
}