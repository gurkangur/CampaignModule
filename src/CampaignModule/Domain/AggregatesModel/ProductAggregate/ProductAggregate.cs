using CampaignModule.Domain.SeedWork;
using System;

namespace CampaignModule.Domain.AggregatesModel.ProductAggregate
{
    public class Product : Entity
    {
        public string Code { get; private set; }
        public int Stock { get; private set; }
        public decimal Price { get; private set; }
        public decimal ListPrice { get; private set; }

        public Product(string code, decimal price, int stock)
        {
            Code = code;
            Price = price;
            ListPrice = price;
            Stock = stock;
        }

        public void SetSalePrice(decimal price)
        {
            Price = price;
        }
        public void DecreaseStock(int quantity)
        {
            if (Stock - quantity < 0)
                throw new Exception("Out of stock");

            Stock -= quantity;
        }
    }
}
