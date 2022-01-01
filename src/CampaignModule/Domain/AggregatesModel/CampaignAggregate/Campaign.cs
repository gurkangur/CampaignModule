using CampaignModule.Domain.SeedWork;

namespace CampaignModule.Domain.AggregatesModel.CampaignAggregate
{
    public class Campaign : Entity
    {
        public string Name { get; private set; }
        public string ProductCode { get; private set; }
        public int Duration { get; private set; }
        public int PriceManipulationLimit { get; private set; }
        public int TargetSalesCount { get; private set; }
        public int TotalSalesCount { get; private set; }
        public decimal AverageItemPrice { get; private set; }
        public bool IsActive { get; private set; }


        public Campaign(string name, string productCode, int duration, int priceManipulationLimit, int targetSalesCount)
        {
            Name = name;
            ProductCode = productCode;
            Duration = duration;
            PriceManipulationLimit = priceManipulationLimit;
            TargetSalesCount = targetSalesCount;
            IsActive = true;
        }

        public void SetInActiveStatus()
        {
            IsActive = false;
        }

        public void SetTotalSalesCount(int quantity)
        {
            TotalSalesCount += quantity;
        }

        public void SetAverageItemPrice(decimal averageItemPrice)
        {
            AverageItemPrice = averageItemPrice;
        }
    }
}
