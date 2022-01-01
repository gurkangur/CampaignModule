using CampaignModule.Application.Campaigns;
using CampaignModule.Application.Commands;
using CampaignModule.Application.Common;
using CampaignModule.Application.Orders;
using CampaignModule.Application.Products;
using CampaignModule.Domain.AggregatesModel.CampaignAggregate;
using CampaignModule.Domain.AggregatesModel.OrderAggregate;
using CampaignModule.Domain.AggregatesModel.ProductAggregate;
using CampaignModule.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace CampaignModule
{
    class Program
    {
        static void Main(string[] args)
        {

            var serviceCollection = new ServiceCollection();

            serviceCollection.AddScoped<ITimeService, TimeService>();
            serviceCollection.AddScoped<ICommandService, CommandService>();
            serviceCollection.AddScoped<IProductRepository, ProductRepository>();
            serviceCollection.AddScoped<IProductService, ProductService>();
            serviceCollection.AddScoped<IOrderRepository, OrderRepository>();
            serviceCollection.AddScoped<IOrderService, OrderService>();
            serviceCollection.AddScoped<ICampaignRepository, CampaignRepository>();
            serviceCollection.AddScoped<ICampaignService, CampaignService>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var commandService = serviceProvider.GetRequiredService<ICommandService>();

            while (true)
            {
                var command = Console.ReadLine().Split(' ');
                commandService.Execute(command[0], command.Skip(1).ToArray());
            }
        }
    }
}
