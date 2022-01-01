using CampaignModule.Application.Common;
using CampaignModule.Application.Products;
using CampaignModule.Domain.AggregatesModel.CampaignAggregate;
using CampaignModule.Domain.AggregatesModel.ProductAggregate;
using System;

namespace CampaignModule.Application.Campaigns
{
    public class CampaignService : ICampaignService
    {
        private readonly ICampaignRepository _campaignRepository;
        private readonly IProductService _productService;
        private readonly ITimeService _timeService;

        public CampaignService(ICampaignRepository campaignRepository, IProductService productService, ITimeService timeService)
        {
            _campaignRepository = campaignRepository;
            _productService = productService;
            _timeService = timeService;
        }

        public Campaign Add(Campaign campaign)
        {
            return _campaignRepository.Add(campaign);
        }

        public Campaign GetByName(string name)
        {
            return _campaignRepository.GetByName(name);
        }
        public Campaign GetByProductCode(string productCode)
        {
            return _campaignRepository.GetByProductCode(productCode);
        }

        public void IncraseTime(int hour)
        {
            UpdateStatusOfExpiredCampaigns();
            var activeCampaigns = _campaignRepository.GetWhere(t => t.IsActive);
            foreach (var campaign in activeCampaigns)
            {
                _productService.ChangeProductSalePrice(campaign.ProductCode, CalculatePriceToSalesStatus(campaign));
            }
        }
        public decimal CalculatePriceToSalesStatus(Campaign campaign)
        {
            var product = _productService.GetByProductCode(campaign.ProductCode);
            var manipulationPrice = product.ListPrice * campaign.PriceManipulationLimit / 100;
            var expectedSalesCount = campaign.TargetSalesCount / campaign.Duration * _timeService.Now.TotalHours;
            if (campaign.TotalSalesCount < expectedSalesCount)
            {
                return DecreasePrice(product, manipulationPrice);
            }
            return IncrasePrice(product, manipulationPrice);
        }

        private decimal IncrasePrice(Product product, decimal manipulationPrice)
        {
            var maxManipulationPrice = product.ListPrice + manipulationPrice;
            return product.Price + new Random().Next(0, Convert.ToInt32(Math.Floor(maxManipulationPrice - product.Price)));
        }

        private decimal DecreasePrice(Product product, decimal manipulationPrice)
        {
            var minManipulationPrice = product.ListPrice - manipulationPrice;
            return product.Price - new Random().Next(0, Convert.ToInt32(Math.Floor(product.Price - minManipulationPrice)));
        }

        private void UpdateStatusOfExpiredCampaigns()
        {
            var expiredCampaigns = _campaignRepository.GetWhere(t => t.IsActive && t.Duration < _timeService.Now.TotalHours);
            foreach (var campaign in expiredCampaigns)
            {
                campaign.SetInActiveStatus();
                _productService.ResetSalePrice(campaign.ProductCode);
            }
        }

        public void IncraseSales(string campaignName, int quantity, decimal price)
        {
            var campaign = GetByName(campaignName);
            var averageItemPrice = ((campaign.AverageItemPrice * campaign.TotalSalesCount) + (price * quantity)) / (campaign.TotalSalesCount + quantity);
            campaign.SetAverageItemPrice(averageItemPrice);
            campaign.SetTotalSalesCount(quantity);
        }
    }
}
