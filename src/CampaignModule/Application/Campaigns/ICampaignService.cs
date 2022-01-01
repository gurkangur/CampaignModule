using CampaignModule.Domain.AggregatesModel.CampaignAggregate;

namespace CampaignModule.Application.Campaigns
{
    public interface ICampaignService
    {
        Campaign Add(Campaign campaign);
        Campaign GetByName(string name);
        Campaign GetByProductCode(string productCode);
        decimal CalculatePriceToSalesStatus(Campaign campaign);
        void IncraseTime(int hour);
        void IncraseSales(string campaignName, int quantity, decimal price);
    }
}
