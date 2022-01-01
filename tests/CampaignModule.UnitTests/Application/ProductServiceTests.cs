using CampaignModule.Application;
using CampaignModule.Domain.AggregatesModel.ProductAggregate;
using Moq;
using Xunit;

namespace CampaignModule.UnitTests.Application
{
    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;

        public ProductServiceTests()
        {
            _productRepositoryMock = new Mock<IProductRepository>(); ;
        }

        [Fact]
        public void Add_product()
        {
            //Arrange
            var fakeProductCode = "001";
            var fakeProduct = GetProductFake(fakeProductCode);
            _productRepositoryMock.Setup(x => x.Add(It.IsAny<Product>())).Returns(fakeProduct);

            //Act
            var productService = new ProductService(_productRepositoryMock.Object);

            var product = productService.Add(fakeProduct);

            //Assert
            Assert.Equal(fakeProductCode, product.Code);
        }
        [Fact]
        public void Get_product_by_product_code()
        {
            //Arrange
            var fakeProductCode = "001";
            var fakeProduct = GetProductFake(fakeProductCode);
            _productRepositoryMock.Setup(x => x.GetByProductCode(It.IsAny<string>())).Returns(fakeProduct);

            //Act
            var productService = new ProductService(_productRepositoryMock.Object);
            var product = productService.GetByProductCode(fakeProductCode);

            //Assert
            Assert.Equal(fakeProductCode, fakeProduct.Code);
        }

        [Fact]
        public void Change_product_sale_price()
        {
            //Arrange
            var fakeProductCode = "001";
            var fakeProduct = GetProductFake(fakeProductCode);
            _productRepositoryMock.Setup(x => x.GetByProductCode(It.IsAny<string>())).Returns(fakeProduct);

            //Act
            var salePrice = 50;
            var productService = new ProductService(_productRepositoryMock.Object);
            productService.ChangeProductSalePrice(fakeProductCode, salePrice);

            //Assert
            Assert.Equal(salePrice, fakeProduct.Price);
        }

        [Fact]
        public void Reset_sale_price()
        {
            //Arrange
            var fakeProductCode = "001";
            var fakeProduct = GetProductFake(fakeProductCode);
            fakeProduct.SetSalePrice(50);
            _productRepositoryMock.Setup(x => x.GetByProductCode(It.IsAny<string>())).Returns(fakeProduct);

            //Act
            var productService = new ProductService(_productRepositoryMock.Object);
            productService.ResetSalePrice(fakeProductCode);

            //Assert
            Assert.Equal(1, fakeProduct.Price);
        }

        [Fact]
        public void Decrease_stock()
        {
            //Arrange
            var fakeProductCode = "001";
            var fakeProduct = GetProductFake(fakeProductCode);
            _productRepositoryMock.Setup(x => x.GetByProductCode(It.IsAny<string>())).Returns(fakeProduct);

            //Act
            var productService = new ProductService(_productRepositoryMock.Object);
            productService.DecreaseStock(fakeProductCode, 1);

            //Assert
            Assert.Equal(0, fakeProduct.Stock);
        }

        private Product GetProductFake(string fakeProductCode)
        {
            return new Product(fakeProductCode, 1, 1);
        }
    }
}
