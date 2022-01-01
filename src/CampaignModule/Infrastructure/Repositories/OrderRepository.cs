using CampaignModule.Domain.AggregatesModel.OrderAggregate;
using System.Collections.Generic;

namespace CampaignModule.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private static List<Order> orders = new List<Order>();

        public Order Add(Order order)
        {
            orders.Add(order);
            return order;
        }
    }
}
