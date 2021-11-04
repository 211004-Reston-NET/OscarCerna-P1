using System;
using Models;
using Xunit;

namespace STest
{
    public class UnitTest1
    {
        [Fact]
        public void NameShouldSetVaildData()
        {
            //Arrange
            Customer _custTest = new Customer();
            string name = "John";

            //Act
            _custTest.Name = name;

            //Assert 
            Assert.NotNull(_custTest.Name);
            Assert.Equal(_custTest.Name, name);   
        }

        [Fact]
        public void StoreIdShouldBeValidInt()
        {
        //Arrange
        StoreFront _storeTest = new StoreFront();
        int StoreID = 1;
        
        //Act
        _storeTest.StoreId = StoreID;

        //Assert
        Assert.Equal(_storeTest.StoreId, StoreID);
        }

        [Fact]
        public void ProductPriceShouldBeDecimal()
        {
       
       //Arrange
       Product _productTest = new Product();
       decimal Price = 1;

       //Act
       _productTest.ProductPrice = Price;

       //Assert
        Assert.Equal(_productTest.ProductPrice, Price);

        }
    }
}
