using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using Xunit;


namespace STest
{
    public class StoreTest
    {
        private readonly DbContextOptions<StoreAppDatabaseContext> _options;
        public StoreTest()
        {
            _options = new DbContextOptionsBuilder<StoreAppDatabaseContext>()
                        .UseSqlite("Filename = Test.db").Options; //UseSqlLite() will create an inmemory database for Test.db
                        Seed();
        }
        [Fact] 
        public void GetAllStoreShouldReturnAllStore()
        {
            using (var context = new StoreAppDatabaseContext(_options))
            {
                //Arrange
                IRepository repo = new RepositoryCloud(context);

                //Act
                List<StoreFront> test = repo.GetAllStores();

                //Assert.Equal(Expected, Acutal Count)
                //Assert.Equal(Expected Name, test[list index].Attribute)
                //Assert
                Assert.Equal(2, test.Count);
                Assert.Equal("Test Store 1", test[0].StoreName);
            }
        }

        [Fact]
        public void GetStoreByIdShouldWork()
        {
            using (var context = new StoreAppDatabaseContext(_options))
            {
                //Arange
                IRepository repo = new RepositoryCloud(context);

                //Act
                StoreFront foundStore = repo.GetStoreById(1);

                //Assert
                Assert.Equal("Test Store 1", foundStore.StoreName);
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

                context.StoreFronts.AddRange
                (
                    new StoreFront
                    {
                        StoreName = "Test Store 1",
                        StoreAddress = "123 Test Drive, Test, NC 14789",
                    },

                    new StoreFront
                    {
                        StoreName = "Test Store 2",
                        StoreAddress = "456 Test Drive, Test, NC 14789",
                    });

                context.SaveChanges();
            }
        }
    }
}
     