using CampaignModule.Domain.AggregatesModel.CampaignAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CampaignModule.Infrastructure.Repositories
{
    public class CampaignRepository : ICampaignRepository
    {
        private static List<Campaign> campaigns = new List<Campaign>();
        public Campaign Add(Campaign campaign)
        {
            campaigns.Add(campaign);
            return campaign;
        }

        public Campaign GetByName(string name)
        {
            return campaigns.FirstOrDefault(t => t.Name == name);
        }
        public Campaign GetByProductCode(string productCode)
        {
            return campaigns.FirstOrDefault(t => t.ProductCode == productCode);
        }

        public IEnumerable<Campaign> GetWhere(Expression<Func<Campaign, bool>> predicate)
        {
            return campaigns.Where(predicate.Compile()).ToList();
        }
    }
}
