using System;
using System.Collections.Generic;
using BusinessLogic;
using Models;

namespace UserInterface
{
    public class ShowCustomer : IMenu
    {
        private CustomerBL _customerBL;
        public ShowCustomer (CustomerBL p_customerBL)
        {
            this._customerBL = p_customerBL;
        }
        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("==== Search Result ====");
            Console.WriteLine();
            Customer foundCustomer = _customerBL.GetCustomerByName(Singleton.customer.Name);
            Console.WriteLine("CustomerId: "+foundCustomer.CustomerId);
            Console.WriteLine("Name: "+foundCustomer.Name);
            Console.WriteLine("Address: "+foundCustomer.Address);
            Console.WriteLine("E-mail: "+foundCustomer.Email);
            Console.WriteLine("Phone: "+foundCustomer.Phone);
            Console.WriteLine();
            Console.WriteLine("[0] Go Back");
  
            
        }

        public MenuType YourChoice()
       {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "0":
                    return MenuType.MainMenu;
                default:
                    Console.WriteLine("Invalid Selection!");
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadLine();
                    return MenuType.ShowCustomer;
            }
        }
    }
}