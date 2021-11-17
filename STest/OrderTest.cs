using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using Xunit;

namespace STest
{
    public class OrderTest
    {
        private readonly DbContextOptions<StoreAppDatabaseContext> _options;
        public OrderTest()
        {
            _options = new DbContextOptionsBuilder<StoreAppDatabaseContext>()
                        .UseSqlite("Filename = Test.db").Options; //UseSqlLite() will create an inmemory database for Test.db
            Seed();
        }

        [Fact]
        public void AddOrderShouldAddOrder()
        {
            using (var context = new StoreAppDatabaseContext(_options))
            {
                //Arrange
                IRepository repo = new RepositoryCloud(context);
                Orders addedorder = new Orders
                {
                    CustomerId = 1,
                    StoreId = 2,
                    OrderDate = System.DateTime.Now,
                    TotalPrice = 200,
                    LineItems = new List<LineItem>
                    {
                        new LineItem
                        {
                            LineItemId = 1,
                            OrderId = 1,
                            ProductId = 2,
                            Quantity = 2,
                            Product =
                            {
                                ProductName = "Test Item 1",
                                ProductBrand = "Test Brand 1",
                                ProductDescription = "Test Drive",
                                ProductPrice = 20,
                            }
                        }
                    }
                };

                //Act
                repo.AddOrder(addedorder);
            }

            //Assert
            using (var contexts = new StoreAppDatabaseContext(_options))
            {
                Orders result = contexts.Orders.Find(10);
                Assert.Equal(1, result.CustomerId);
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

                context.Orders.AddRange
                (
                    new Orders
                    {
                        CustomerId = 1,
                        StoreId = 2,
                        OrderDate = System.DateTime.Now,
                        TotalPrice = 200,
                        LineItems = new List<LineItem>
                        {
                            new LineItem
                            {
                                LineItemId = 1,
                                OrderId = 1,
                                ProductId = 2,
                                Quantity = 2,
                                Product =
                                {
                                    ProductName = "Test Item 1",
                                    ProductBrand = "Test Brand 1",
                                    ProductDescription = "Test Drive",
                                    ProductPrice = 20,
                                }
                            }
                        }
                    }
                );

                context.SaveChanges();
            }
        }
    } 
}