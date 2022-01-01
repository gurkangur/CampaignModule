using CampaignModule.Application.Products;
using CampaignModule.Domain.AggregatesModel.OrderAggregate;

namespace CampaignModule.Application.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductService _productService;

        public OrderService(IOrderRepository orderRepository, IProductService productService)
        {
            _orderRepository = orderRepository;
            _productService = productService;
        }

        public Order CreateOrder(Order order)
        {
            var product = _productService.GetByProductCode(order.ProductCode);
            _productService.DecreaseStock(order.ProductCode, order.Quantity);
            order.SetPrice(product.Price);
            return _orderRepository.Add(order);
        }
    }
}
