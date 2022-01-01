using CampaignModule.Domain.AggregatesModel.ProductAggregate;

namespace CampaignModule.Application.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product Add(Product product)
        {
            return _productRepository.Add(product);
        }

        public void ChangeProductSalePrice(string productCode, decimal price)
        {
            var product = GetByProductCode(productCode);
            product.SetSalePrice(price);
        }

        public void ResetSalePrice(string productCode)
        {
            var product = GetByProductCode(productCode);
            product.SetSalePrice(product.ListPrice);
        }

        public Product GetByProductCode(string productCode)
        {
            return _productRepository.GetByProductCode(productCode);
        }

        public void DecreaseStock(string productCode, int quantity)
        {
            var product = GetByProductCode(productCode);
            product.DecreaseStock(quantity);
        }
    }
}
