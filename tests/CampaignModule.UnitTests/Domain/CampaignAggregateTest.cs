using CampaignModule.Domain.AggregatesModel.CampaignAggregate;
using Xunit;

namespace CampaignModule.UnitTests.Domain
{
    public class CampaignAggregateTest
    {
        [Fact]
        public void Create_campaign_success()
        {
            //Arrange    
            var name = "FakeCampaignName";
            var productCode = "FakeProductCode";
            var duration = 10;
            var priceManipulationLimit = 20;
            var targetSalesCount = 100;


            //Act 
            var fakeCampaignItem = new Campaign(name, productCode, duration, priceManipulationLimit, targetSalesCount);

            //Assert
            Assert.NotNull(fakeCampaignItem);
        }


        [Fact]
        public void Campaign_should_inactive_status_set()
        {
            //Arrange
            var name = "FakeCampaignName";
            var productCode = "FakeProductCode";
            var duration = 10;
            var priceManipulationLimit = 20;
            var targetSalesCount = 100;
            var fakeCampaignItem = new Campaign(name, productCode, duration, priceManipulationLimit, targetSalesCount);


            //Act 
            fakeCampaignItem.SetInActiveStatus();

            //Assert
            Assert.False(fakeCampaignItem.IsActive);
        }

        [Fact]
        public void Campaign_should_total_sales_count_set()
        {
            //Arrange
            var name = "FakeCampaignName";
            var productCode = "FakeProductCode";
            var duration = 10;
            var priceManipulationLimit = 20;
            var targetSalesCount = 100;
            var fakeCampaignItem = new Campaign(name, productCode, duration, priceManipulationLimit, targetSalesCount);


            //Act 
            fakeCampaignItem.SetTotalSalesCount(5);

            //Assert
            Assert.Equal(5, fakeCampaignItem.TotalSalesCount);
        }

        [Fact]
        public void Campaign_should_average_item_price_set()
        {
            //Arrange
            var name = "FakeCampaignName";
            var productCode = "FakeProductCode";
            var duration = 10;
            var priceManipulationLimit = 20;
            var targetSalesCount = 100;
            var fakeCampaignItem = new Campaign(name, productCode, duration, priceManipulationLimit, targetSalesCount);


            //Act 
            fakeCampaignItem.SetAverageItemPrice(5);

            //Assert
            Assert.Equal(5, fakeCampaignItem.AverageItemPrice);
        }


    }
}
