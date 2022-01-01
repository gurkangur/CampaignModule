using CampaignModule.Domain.AggregatesModel.ProductAggregate;
using System.Collections.Generic;
using System.Linq;

namespace CampaignModule.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private static List<Product> products = new List<Product>();

        public Product Add(Product product)
        {
            products.Add(product);
            return product;
        }

        public Product GetByProductCode(string productCode)
        {
            return products.FirstOrDefault(t => t.Code == productCode);
        }
    }
}
