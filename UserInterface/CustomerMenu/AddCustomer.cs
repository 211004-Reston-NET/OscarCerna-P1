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
            "[4] Enter Phone");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Name: "+Singleton.customer.Name);
            Console.WriteLine("Address: "+Singleton.customer.Address);
            Console.WriteLine("Email: "+Singleton.customer.Email);
            Console.WriteLine("Phone: "+Singleton.customer.Phone);
            Console.WriteLine("-------------------------------------");
            Console.WriteLine();
            Console.WriteLine("[5] Save Customer");
            Console.WriteLine("[0] Go Back");
        }
        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "0":
                    return MenuType.CustomerMenu;
                case "1":
                    Console.WriteLine("Enter Customer Name");
                    try
                    {
                        Singleton.customer.Name = Console.ReadLine();  
                    }
                    catch (System.Exception)
                    {
                        Console.WriteLine("Invalid Name Format");
                        Console.WriteLine("Press Enter to Continue");
                        Console.ReadLine();
                        return MenuType.AddCustomer;
                    }
                    return MenuType.AddCustomer;

                case "2":
                    Console.WriteLine("Enter Customer Address");
                    try
                    {
                        Singleton.customer.Address = Console.ReadLine();
                    }
                    catch (System.Exception)
                    {
                        Console.WriteLine("Invalid Address Format");
                        Console.WriteLine("Press Enter to Continue");
                        Console.ReadLine();
                        return MenuType.AddCustomer;
                    }
                    return MenuType.AddCustomer;

                case "3":
                    Console.WriteLine("Enter Customer E-mail");
                    try
                    {
                        Singleton.customer.Email = Console.ReadLine();
                    }
                       catch (System.Exception)
                    {
                        Console.WriteLine("Invalid E-mail Format");
                        Console.WriteLine("Press Enter to Continue");
                        Console.ReadLine();
                        return MenuType.AddCustomer;
                    }
                    return MenuType.AddCustomer;

                case "4":
                    Console.WriteLine("Enter Customer Phone Number");
                    try
                    {
                        Singleton.customer.Phone = Console.ReadLine();
                    }
                    catch (System.Exception)
                    {
                        Console.WriteLine("Invalid Phone Number Format");
                        Console.WriteLine("Press Enter to Continue");
                        Console.ReadLine();
                        return MenuType.AddCustomer;
                    }
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