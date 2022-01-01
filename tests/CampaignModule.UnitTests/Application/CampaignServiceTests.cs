using CampaignModule.Application.Campaigns;
using CampaignModule.Application.Common;
using CampaignModule.Application.Products;
using CampaignModule.Domain.AggregatesModel.CampaignAggregate;
using CampaignModule.Domain.AggregatesModel.ProductAggregate;
using Moq;
using System;
using Xunit;

namespace CampaignModule.UnitTests.Application
{
    public class CampaignServiceTests
    {
        private readonly Mock<ICampaignRepository> _campaignRepository;
        private readonly Mock<IProductService> _productService;
        private readonly Mock<ITimeService> _timeService;

        public CampaignServiceTests()
        {
            _campaignRepository = new Mock<ICampaignRepository>();
            _productService = new Mock<IProductService>();
            _timeService = new Mock<ITimeService>();
        }

        [Fact]
        public void Add_campaign()
        {
            //Arrange
            var campaignName = "FakeCampaignName";
            var fakeCampaign = GetCampaignFake(campaignName);
            _campaignRepository.Setup(x => x.Add(It.IsAny<Campaign>())).Returns(fakeCampaign);

            //Act
            var campaignService = new CampaignService(
                _campaignRepository.Object,
                _productService.Object,
                _timeService.Object
                );

            var campaign = campaignService.Add(fakeCampaign);

            //Assert
            Assert.Equal(campaignName, campaign.Name);
        }

        [Fact]
        public void Get_campaign_by_campaign_name()
        {
            //Arrange
            var campaignName = "FakeCampaignName";
            var fakeCampaign = GetCampaignFake(campaignName);
            _campaignRepository.Setup(x => x.GetByName(It.IsAny<string>())).Returns(fakeCampaign);

            //Act
            var campaignService = new CampaignService(
                _campaignRepository.Object,
                _productService.Object,
                _timeService.Object
                );

            var campaign = campaignService.GetByName(campaignName);

            //Assert
            Assert.Equal(campaignName, campaign.Name);
        }
        [Fact]
        public void Get_campaign_by_product_code()
        {
            //Arrange
            var fakeCampaign = new Campaign("FakeCampaignName", "001", 10, 20, 100);
            _campaignRepository.Setup(x => x.GetByProductCode(It.IsAny<string>())).Returns(fakeCampaign);

            //Act
            var campaignService = new CampaignService(
                _campaignRepository.Object,
                _productService.Object,
                _timeService.Object
                );

            var campaign = campaignService.GetByProductCode(fakeCampaign.ProductCode);

            //Assert
            Assert.Equal(fakeCampaign.ProductCode, campaign.ProductCode);
        }

        [Fact]
        public void GetSalePrice_when_sales_are_low_price_should_decrease()
        {
            //Arrange
            var fakeCampaign = new Campaign("FakeCampaignName", "001", 10, 20, 100);
            var fakeProduct = new Product("001", 100, 1000);
            _campaignRepository.Setup(x => x.GetByName(It.IsAny<string>())).Returns(fakeCampaign);
            _productService.Setup(x => x.GetByProductCode(It.IsAny<string>())).Returns(fakeProduct);
            _timeService.Setup(x => x.Now).Returns(new TimeSpan(1, 0, 0));
            //Act
            var campaignService = new CampaignService(
                _campaignRepository.Object,
                _productService.Object,
                _timeService.Object
                );

            var price = campaignService.CalculatePriceToSalesStatus(fakeCampaign);

            //Assert
            Assert.True(price <= fakeProduct.Price);
        }

        [Fact]
        public void GetSalePrice_when_sales_are_high_price_should_incrase()
        {
            //Arrange
            var fakeCampaign = new Campaign("FakeCampaignName", "001", 10, 20, 100);
            fakeCampaign.SetTotalSalesCount(90);
            var fakeProduct = new Product("001", 100, 1000);
            _campaignRepository.Setup(x => x.GetByName(It.IsAny<string>())).Returns(fakeCampaign);
            _productService.Setup(x => x.GetByProductCode(It.IsAny<string>())).Returns(fakeProduct);
            _timeService.Setup(x => x.Now).Returns(new TimeSpan(1, 0, 0));
            //Act
            var campaignService = new CampaignService(
                _campaignRepository.Object,
                _productService.Object,
                _timeService.Object
                );

            var price = campaignService.CalculatePriceToSalesStatus(fakeCampaign);

            //Assert
            Assert.True(price >= fakeProduct.Price);
        }

        private Campaign GetCampaignFake(string name)
        {
            return new Campaign(name, "001", 10, 20, 100);
        }
    }
}
