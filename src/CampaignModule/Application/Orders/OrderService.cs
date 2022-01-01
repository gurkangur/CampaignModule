using CampaignModule.Application.Campaigns;
using CampaignModule.Application.Products;
using CampaignModule.Domain.AggregatesModel.OrderAggregate;

namespace CampaignModule.Application.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductService _productService;
        private readonly ICampaignService _campaignService;

        public OrderService(IOrderRepository orderRepository, IProductService productService, ICampaignService campaignService)
        {
            _orderRepository = orderRepository;
            _productService = productService;
            _campaignService = campaignService;
        }

        public Order CreateOrder(Order order)
        {
            var product = _productService.GetByProductCode(order.ProductCode);
            _productService.DecreaseStock(order.ProductCode, order.Quantity);

            var existingCampaign = _campaignService.GetByProductCode(order.ProductCode);
            if (existingCampaign is not null)
                _campaignService.IncraseSales(existingCampaign.Name, order.Quantity, product.Price);

            order.SetPrice(product.Price);
            return _orderRepository.Add(order);
        }
    }
}
