using CampaignModule.Domain.SeedWork;
using System;

namespace CampaignModule.Domain.AggregatesModel.OrderAggregate
{
    public class Order : Entity
    {
        public string ProductCode { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }

        public Order(string productCode, int quantity)
        {
            if (quantity <= 0)
            {
                throw new Exception("Invalid number of quantity");
            }
            ProductCode = productCode;
            Quantity = quantity;
        }
        public void SetPrice(decimal unitPrice)
        {
            UnitPrice = unitPrice;
        }
    }
}
