using CampaignModule.Domain.AggregatesModel.ProductAggregate;
using System;
using Xunit;

namespace CampaignModule.UnitTests.Domain
{
    public class ProductAggregateTest
    {
        [Fact]
        public void Create_product_success()
        {
            //Arrange    
            var code = "FakeProductCode";
            var price = 5;
            var stock = 5;


            //Act 
            var fakeProductItem = new Product(code, price, stock);

            //Assert
            Assert.NotNull(fakeProductItem);
        }
        [Fact]
        public void Product_Should_Price_Set()
        {
            //Arrange
            var price = 5;
            var product = new Product("FakeProductCode", price, 1);

            //Act
            var newPrice = 50;
            product.SetSalePrice(newPrice);

            //expected
            Assert.Equal(newPrice, product.Price);
            Assert.Equal(price, product.ListPrice);
        }
        [Fact]
        public void Product_Should_Decrease_Stock()
        {
            //Arrange
            var stock = 100;
            var product = new Product("FakeProductCode", 5, stock);

            //Act
            var quantity = 50;
            product.DecreaseStock(quantity);

            //expected
            Assert.Equal(stock - quantity, product.Stock);
        }

        [Fact]
        public void DecreaseStock_Invalid_number_of_quantity()
        {
            //Arrange    
            var stock = 100;
            var product = new Product("FakeProductCode", 5, stock);

            //Act - Assert
            Assert.Throws<Exception>(() => product.DecreaseStock(101));
        }
    }
}
