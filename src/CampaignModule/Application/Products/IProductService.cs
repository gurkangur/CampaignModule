using CampaignModule.Domain.AggregatesModel.ProductAggregate;

namespace CampaignModule.Application.Products
{
    public interface IProductService
    {
        Product Add(Product product);
        Product GetByProductCode(string productCode);
        void ChangeProductSalePrice(string productCode, decimal price);
        void ResetSalePrice(string productCode);
        void DecreaseStock(string productCode, int quantity);
    }
}
