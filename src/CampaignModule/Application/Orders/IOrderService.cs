using CampaignModule.Domain.AggregatesModel.OrderAggregate;

namespace CampaignModule.Application.Orders
{
    public interface IOrderService
    {
        Order CreateOrder(Order order);
    }
}
