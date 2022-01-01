namespace CampaignModule.Application.Common.Constants
{
    public struct AppConstants
    {
        public const string CreateProductCommand = "create_product";
        public const string GetProductInfoCommand = "get_product_info";
        public const string CreateOrderCommand = "create_order";
        public const string CreateCampaingCommand = "create_campaign";
        public const string GetCampaignInfoCommand = "get_campaign_info";
        public const string IncreaseTime = "increase_time";



        public const string NotFound = "Could not execute because the specified command was not found.";
        public const string ProductInfo = "Product {0} info; price {1}, stock {2}";
        public const string ProductCreated = "Product created; code {0}, price {1}, stock {2}";
        public const string OrderCreated = "Order created; product {0}, quantity {1}";
        public const string CampaignCreated = "Campaign created; name {0}, product {1}, duration {2}, limit {3}, target sales count {4}";
        public const string CampaignInfo = "Campaign {0} info, Status {1}, Target Sales {2}, Total Sales {3}, Turnover {4}, Average Item Price {5}";
        public const string IncreasedTime = "Time is {0}";

    }
}
