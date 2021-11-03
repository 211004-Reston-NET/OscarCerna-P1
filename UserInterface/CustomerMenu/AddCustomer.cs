using System;
using BusinessLogic;

namespace UserInterface
{
    public class AddCustomer : IMenu
    {
        private CustomerBL _customerBL;
        public AddCustomer (CustomerBL p_customerBL)
        {
            _customerBL = p_customerBL;
        }
        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("==== Adding New Customer ==== ");
            Console.WriteLine("\r\n" +
            "[1] Enter Name\n" +
            "[2] Enter Address\n" +
            "[3] Enter E-mail\n" +
            "[4] Enter Phone\n");
            Console.WriteLine("Name: "+Singleton.customer.Name);
            Console.WriteLine("Address: "+Singleton.customer.Address);
            Console.WriteLine("Email: "+Singleton.customer.Email);
            Console.WriteLine("Phone: "+Singleton.customer.Phone);
            Console.WriteLine("\r\n[5] Add Customer");
            Console.WriteLine();
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "0":
                    return MenuType.MainMenu;
                case "1":
                    Console.WriteLine("Enter Customer Name");
                    Singleton.customer.Name = Console.ReadLine();
                    return MenuType.AddCustomer;
                case "2":
                    Console.WriteLine("Enter Customer Address");
                    Singleton.customer.Address = Console.ReadLine();
                    return MenuType.AddCustomer;
                case "3":
                    Console.WriteLine("Enter Customer E-mail");
                    Singleton.customer.Email = Console.ReadLine();
                    return MenuType.AddCustomer;
                case "4":
                    Console.WriteLine("Enter Customer Phone Number");
                    Singleton.customer.Phone = Console.ReadLine();
                    return MenuType.AddCustomer;
                case "5":
                    _customerBL.AddCustomer(Singleton.customer);
                    return MenuType.CustomerMenu;
                default:
                    Console.WriteLine("Invalid Selection!");
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadLine();
                    return MenuType.AddCustomer;
            }
        }
    }
}