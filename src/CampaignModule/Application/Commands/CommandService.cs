using CampaignModule.Application.Campaigns;
using CampaignModule.Application.Common;
using CampaignModule.Application.Common.Constants;
using CampaignModule.Application.Orders;
using CampaignModule.Application.Products;
using CampaignModule.Domain.AggregatesModel.CampaignAggregate;
using CampaignModule.Domain.AggregatesModel.OrderAggregate;
using CampaignModule.Domain.AggregatesModel.ProductAggregate;
using System;
using System.Collections.Generic;

namespace CampaignModule.Application.Commands
{
    public class CommandService : ICommandService
    {
        private readonly Dictionary<string, Func<string[], string>> commands = new Dictionary<string, Func<string[], string>>();
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly ICampaignService _campaignService;
        private readonly ITimeService _timeService;

        public CommandService(IProductService productService, IOrderService orderService, ICampaignService campaignService, ITimeService timeService)
        {
            _productService = productService;
            _orderService = orderService;
            _campaignService = campaignService;
            _timeService = timeService;

            InitiliazeCommands();
        }

        private void InitiliazeCommands()
        {
            commands[AppConstants.CreateProductCommand] = new Func<string[], string>((s) => { return CreateProduct(s); });
            commands[AppConstants.GetProductInfoCommand] = new Func<string[], string>((s) => { return GetProductInfo(s); });
            commands[AppConstants.CreateOrderCommand] = new Func<string[], string>((s) => { return CreateOrder(s); });
            commands[AppConstants.CreateCampaingCommand] = new Func<string[], string>((s) => { return CreateCampaign(s); });
            commands[AppConstants.GetCampaignInfoCommand] = new Func<string[], string>((s) => { return GetCampaignInfo(s); });
            commands[AppConstants.IncreaseTime] = new Func<string[], string>((s) => { return IncreaseTime(s); });
        }

        public void Execute(string command, string[] args)
        {
            if (commands.ContainsKey(command))
            {
                var response = commands[command](args);
                Console.WriteLine(response);
            }
            else
            {
                Console.WriteLine(AppConstants.NotFound);
            }
        }

        private string CreateProduct(string[] args)
        {
            var product = _productService.Add(new Product(args[0], decimal.Parse(args[1]), int.Parse(args[2])));
            return string.Format(AppConstants.ProductCreated, product.Code, product.Price, product.Stock);
        }
        private string GetProductInfo(string[] args)
        {
            var productCode = args[0];
            var product = _productService.GetByProductCode(productCode);
            return string.Format(AppConstants.ProductInfo, product.Code, product.Price, product.Stock);
        }
        private string CreateOrder(string[] args)
        {
            var order = new Order(args[0], int.Parse(args[1]));
            _orderService.CreateOrder(order);
            return string.Format(AppConstants.OrderCreated, order.ProductCode, order.Quantity);

        }
        private string CreateCampaign(string[] args)
        {
            var campaign = new Campaign(args[0], args[1], int.Parse(args[2]), int.Parse(args[3]), int.Parse(args[4]));
            _campaignService.Add(campaign);
            return string.Format(AppConstants.CampaignCreated, campaign.Name, campaign.ProductCode,
                campaign.Duration, campaign.PriceManipulationLimit, campaign.TargetSalesCount);

        }
        private string GetCampaignInfo(string[] args)
        {
            var name = args[0];
            var campaign = _campaignService.GetByName(name);
            return string.Format(AppConstants.CampaignInfo, campaign.Name, campaign.IsActive,
                  campaign.TargetSalesCount, campaign.TotalSalesCount, "0", campaign.AverageItemPrice);
        }
        private string IncreaseTime(string[] args)
        {
            var hour = int.Parse(args[0]);
            var time = _timeService.IncraseTime(hour);
            _campaignService.IncraseTime(hour);
            return string.Format(AppConstants.IncreasedTime, time.ToString("hh\\:mm")); ;
        }
    }
}
