using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CampaignModule.Domain.AggregatesModel.CampaignAggregate
{
    public interface ICampaignRepository
    {
        Campaign Add(Campaign campaign);
        Campaign GetByName(string name);
        Campaign GetByProductCode(string productCode);
        IEnumerable<Campaign> GetWhere(Expression<Func<Campaign, bool>> predicate);
    }
}
