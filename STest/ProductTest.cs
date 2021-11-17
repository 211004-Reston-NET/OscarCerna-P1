using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using Xunit;

namespace STest
{
    public class ProductTest
    {
        private readonly DbContextOptions<StoreAppDatabaseContext> _options;
        public ProductTest()
        {
            _options = new DbContextOptionsBuilder<StoreAppDatabaseContext>()
                        .UseSqlite("Filename = Test.db").Options; //UseSqlLite() will create an inmemory database for Test.db
                         Seed();
        }

        [Fact]
        public void AddProductShouldAddProduct()
        {
            using (var context = new StoreAppDatabaseContext(_options))
            {
                //Arrange
                IRepository repo = new RepositoryCloud(context);
                Product addProd = new Product
                {
                    ProductName = "Test Item 1",
                    ProductBrand = "Test",
                    ProductDescription = "Test Drive",
                    ProductPrice = 10,
                };

                //Act
                repo.AddProduct(addProd);

                using (var contexts = new StoreAppDatabaseContext(_options))
                {
                    Product result = contexts.Products.Find(1);

                    Assert.NotNull(result);
                    Assert.Equal("Test Item 1", result.ProductName);
                    Assert.Equal("Test", result.ProductBrand);
                    Assert.Equal("Test Drive", result.ProductDescription);
                    Assert.Equal(10, result.ProductPrice);
                }
            }
        }

        [Fact]
        public void GetAllProductShouldReturnAllProduct()
        {
            using (var context = new StoreAppDatabaseContext(_options))
            {
                //Arrange
                IRepository repo = new RepositoryCloud(context);

                //Act
                List<Product> test = repo.GetAllProduct();

                //Assert.Equal(Expected, Acutal Count)
                //Assert.Equal(Expected Name, test[list index].Attribute)
                //Assert
                Assert.Equal(2, test.Count);
                Assert.Equal("Test Item 1", test[0].ProductName);
            }
        }

        [Fact]
        public void GetProductByIdShouldWork()
        {
            using (var context = new StoreAppDatabaseContext(_options))
            {
                //Arange
                IRepository repo = new RepositoryCloud(context);

                //Act
                Product foundProduct = repo.GetProductById(1);

                //Assert
                Assert.Equal("Test Item 1", foundProduct.ProductName);
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

                context.Products.AddRange
                (
                    new Product
                    {
                        ProductName = "Test Item 1",
                        ProductBrand = "Test",
                        ProductDescription = "Test Drive",
                        ProductPrice = 10,
                    },

                    new Product
                    {
                        ProductName = "Test Item 2",
                        ProductBrand = "Test 2",
                        ProductDescription = "Test Drive 2",
                        ProductPrice = 20,
                    });

                context.SaveChanges();
            }
        }
    }
}
