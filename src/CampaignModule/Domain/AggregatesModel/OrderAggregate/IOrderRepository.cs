namespace CampaignModule.Domain.AggregatesModel.OrderAggregate
{
    public interface IOrderRepository
    {
        Order Add(Order order);
    }
}
