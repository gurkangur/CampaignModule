using CampaignModule.Domain.AggregatesModel.OrderAggregate;
using System;
using Xunit;

namespace CampaignModule.UnitTests.Domain
{
    public class OrderAggregateTest
    {
        [Fact]
        public void Create_order_success()
        {
            //Arrange    
            var productCode = "FakeProductCode";
            var quantity = 5;

            //Act 
            var fakeOrderItem = new Order(productCode, quantity);

            //Assert
            Assert.NotNull(fakeOrderItem);
        }
        [Fact]
        public void Invalid_number_of_quantity()
        {
            //Arrange    
            var productCode = "FakeProductCode";
            var quantity = -1;

            //Act - Assert
            Assert.Throws<Exception>(() => new Order(productCode, quantity));
        }
        [Fact]
        public void Order_should_price_set()
        {
            //Arrange
            var order = new Order("FakeProductCode", 1);

            //Act
            order.SetPrice(50);
            //expected
            Assert.Equal(50, order.UnitPrice);
        }
    }
}
