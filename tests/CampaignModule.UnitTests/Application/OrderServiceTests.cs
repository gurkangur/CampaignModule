using CampaignModule.Application.Orders;
using CampaignModule.Application.Products;
using CampaignModule.Domain.AggregatesModel.OrderAggregate;
using CampaignModule.Domain.AggregatesModel.ProductAggregate;
using Moq;
using Xunit;

namespace CampaignModule.UnitTests.Application
{
    public class OrderServiceTests
    {
        private readonly Mock<IOrderRepository> _orderRepository;
        private readonly Mock<IProductService> _productService;

        public OrderServiceTests()
        {
            _orderRepository = new Mock<IOrderRepository>();
            _productService = new Mock<IProductService>();
        }

        [Fact]
        public void Create_order()
        {
            //Arrange
            var productPrice = 1;
            var fakeProduct = new Product("001", productPrice, 1);
            var fakeOrder = new Order(fakeProduct.Code, 1);

            _productService.Setup(x => x.GetByProductCode(It.IsAny<string>())).Returns(fakeProduct);
            _orderRepository.Setup(x => x.Add(It.IsAny<Order>())).Returns(GetOrderFake(fakeProduct.Code, fakeOrder.Quantity, productPrice));

            //Act
            var orderService = new OrderService(
                _orderRepository.Object,
                _productService.Object
                );

            var order = orderService.CreateOrder(fakeOrder);

            //Assert
            Assert.Equal(fakeProduct.Code, order.ProductCode);
            Assert.Equal(productPrice, order.UnitPrice);

        }
        public Order GetOrderFake(string productcode, int quantity, decimal price)
        {
            var order = new Order(productcode, quantity);
            order.SetPrice(price);
            return order;
        }
    }
}
