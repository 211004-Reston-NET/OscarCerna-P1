using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using Xunit;

namespace STest
{
    public class RepoTest
    {
        private readonly DbContextOptions<StoreAppDatabaseContext> _options;

        public RepoTest()
        {
            _options = new DbContextOptionsBuilder<StoreAppDatabaseContext>()
                        .UseSqlite("Filename = Test.db").Options; //UseSqlLite() will create an inmemory database for Test.db
                        Seed();
        }


        [Fact]
        public void GetInventoryByIdTest()
        {
            using (var context = new StoreAppDatabaseContext(_options))
            {
                //Arrange
                IRepository repo = new RepositoryCloud(context);

                //Act
                List<Inventory> listOfInventory = repo.GetInventoryByStoreId(1);

                //Assert
            }
        }


        [Fact]
        public void GetAllStoresTest()
        {
            using (var context = new StoreAppDatabaseContext(_options))
            {
                //Arrange
                IRepository repo = new RepositoryCloud(context);

                //Act
                List<StoreFront> test = repo.GetAllStores();

                //Assert
                Assert.Equal(1,1);
                Assert.Equal("Test Store", test[1].StoreName);

            }   
        }
        [Fact]
        public void AddCustomerShouldAddCustomer()
        {
            using (var context = new StoreAppDatabaseContext(_options))
            {
                //Arrange
                IRepository repo = new RepositoryCloud(context);
                Customer addedCust = new Customer()
                {
                    Name = "Test Customer",
                    Address = "1000 West Market St, Greensboro, NC 27401",
                    Email = "T@test.com",
                    Phone = "777-555-8888",
                };

                //Act
                repo.AddCustomer(addedCust);
            }
             //Assert
            using (var context = new StoreAppDatabaseContext(_options))
            {
                var result = context.Customers.Find(1);

                Assert.NotNull(result);
                Assert.Equal("Test Customer", result.Name);
                Assert.Equal("1000 West Market St, Greensboro, NC 27401", result.Address);
                Assert.Equal("T@test.com", result.Email);
                Assert.Equal("777-555-8888", result.Phone); 
            }
        }
        private void Seed()
        {
            //automatically close the resourse that is used to connect to db
            using (var context = new StoreAppDatabaseContext(_options))
            {

            //Ensures inmemory DB gets deleted and recreated to not have any data from previous tests
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Customers.AddRange

                (
                   new Customer
                   {
                       Name = "Test Customer",
                       Address = "1000 West Market St, Greensboro, NC 27401",
                       Email = "T@test.com",
                       Phone = "777-555-8888",
                   };

                context.StoreFronts.AddRange

                    new StoreFront
                {
                    StoreName = "Test Store",
                    StoreAddress = "412 West Market, Greens, NC 27401",
                };

                 context.SaveChanges();

            }
        }

    }
}