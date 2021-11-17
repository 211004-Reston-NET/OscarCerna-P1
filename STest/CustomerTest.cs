using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using Xunit;

namespace STest
{
    public class CustomerTest
    {
        private readonly DbContextOptions<StoreAppDatabaseContext> _options;
        public CustomerTest()
        {
            _options = new DbContextOptionsBuilder<StoreAppDatabaseContext>()
                        .UseSqlite("Filename = Test.db").Options; //UseSqlLite() will create an inmemory database for Test.db
                         Seed();
        }

        [Fact]

        public void AddCustomerShouldAddCustomer()
        {
            using (var context = new StoreAppDatabaseContext(_options))
            {
                //Arrange
                IRepository repo = new RepositoryCloud(context);
                Customer addCust = new Customer
                {
                    Name = "Johnny Test",
                    Address = "412 Session Street, Anderson, SC 29687",
                    Email = "test@yahoo.com",
                    Phone = "516-453-5697",
                };

                //Act
                repo.AddCustomer(addCust);

                using (var contexts = new StoreAppDatabaseContext(_options))
                {
                    Customer result = contexts.Customers.Find(3);

                    Assert.NotNull(result);
                    Assert.Equal("Johnny Test", result.Name);
                    Assert.Equal("412 Session Street, Anderson, SC 29687", result.Address);
                    Assert.Equal("test@yahoo.com", result.Email);
                    Assert.Equal("516-453-5697", result.Phone);
                }
            }
        }

        [Fact]
        public void GetAllCustomerShouldReturnAllCustomer()
        {
            using (var context = new StoreAppDatabaseContext(_options))
            {
                //Arrange
                IRepository repo = new RepositoryCloud(context);

                //Act
                List<Customer> test = repo.GetAllCustomer();

                //Assert.Equal(Expected, Acutal Count)
                //Assert.Equal(Expected Name, test[list index].Attribute)
                //Assert
                Assert.Equal(2, test.Count);
                Assert.Equal("Johnny Test", test[0].Name);
            }
        }

        [Fact]
        public void GetCustomerByIdShouldWork()
        {
            using (var context = new StoreAppDatabaseContext(_options))
            {
                //Arange
                IRepository repo = new RepositoryCloud(context);

                //Act
                Customer foundCust = repo.GetCustomerById(1);

                //Assert
                Assert.Equal("Johnny Test", foundCust.Name);
            }
        }


        private void Seed()
        {
            //using block to automatically close the resource that is used to connect to this db after seeding data to it
            using (var context = new StoreAppDatabaseContext(_options))
            {
                //We want to make sure that our inmemory db gets deleted and recreated to not have any data from previous tests
                //We want a pristine database to ensure that every tests will have the exact same database being used to execute the test
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Customers.AddRange
                (
                    new Customer
                    {
                        Name = "Johnny Test",
                        Address = "412 Session Street, Anderson, SC 29687",
                        Email = "test@yahoo.com",
                        Phone = "516-453-5697",
                    },

                    new Customer
                    {
                        Name = "John Smith",
                        Address = "1000 Dog Street, Starr, SC 29621",
                        Email = "smith@yahoo.com",
                        Phone = "864-523-8965",
                    });

                context.SaveChanges();
            }
        }
    }
}
