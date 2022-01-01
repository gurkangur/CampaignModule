namespace CampaignModule.Domain.AggregatesModel.ProductAggregate
{
    public interface IProductRepository
    {
        Product Add(Product product);
        Product GetByProductCode(string productCode);
    }
}
