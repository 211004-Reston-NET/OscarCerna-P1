using System.IO;
using BusinessLogic;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace UserInterface
{
    public class MenuFactory : IFactory
    {
        public IMenu GetMenu(MenuType p_menu)
        {
            var configuartion = new ConfigurationBuilder() //Configurationbuilder is the class that came from the Microsoft.extensions.configuration package
            .SetBasePath(Directory.GetCurrentDirectory()) //Gets the current directory of the RRUI file path
            .AddJsonFile("appsetting.json") //Adds the appsetting.json file in our RRUI
            .Build(); //Builds our configuration

            DbContextOptions<StoreAppDatabaseContext> options = new DbContextOptionsBuilder<StoreAppDatabaseContext>()
            .UseSqlServer(configuartion.GetConnectionString("Reference2DB"))
            .Options;

            switch (p_menu)
            {
                case MenuType.MainMenu:
                    return new MainMenu();
                case MenuType.CustomerMenu:
                    return new CustomerMenu();
                case MenuType.AddCustomer:
                    return new AddCustomer(new CustomerBL(new RepositoryCloud(new StoreAppDatabaseContext(options))));
                case MenuType.ShowCustomer:
                    return new ShowCustomer(new CustomerBL(new RepositoryCloud(new StoreAppDatabaseContext(options))));
                case MenuType.StoreMenu:
                    return new StoreMenu();
                case MenuType.StoreLocations:
                    return new StoreLocations(new StoreBL(new RepositoryCloud(new StoreAppDatabaseContext(options))));   
                case MenuType.ShowInventory:
                    return new ShowInventory(new StoreBL(new RepositoryCloud(new StoreAppDatabaseContext(options))),
                            new InventoryBL(new RepositoryCloud(new StoreAppDatabaseContext(options))));
                case MenuType.PlaceOrder:
                    return new PlaceOrder(new StoreBL(new RepositoryCloud(new StoreAppDatabaseContext(options))),
                            new CustomerBL(new RepositoryCloud(new StoreAppDatabaseContext(options))),
                            new OrderBL(new RepositoryCloud(new StoreAppDatabaseContext(options))));
                case MenuType.AddItem:
                    return new Additem(new LineItemBL(new RepositoryCloud(new StoreAppDatabaseContext(options))),
                           new OrderBL(new RepositoryCloud(new StoreAppDatabaseContext(options))));
                case MenuType.OrderHistory:
                    return new OrderHistory();
                case MenuType.StoreOrders:
                    return new StoreOrders(new OrderBL(new RepositoryCloud(new StoreAppDatabaseContext(options))));
                case MenuType.CustomerOrders:
                    return new CustomerOrders(new OrderBL(new RepositoryCloud(new StoreAppDatabaseContext(options))));
                    default:
                    return null;
            }
        }
    }
}