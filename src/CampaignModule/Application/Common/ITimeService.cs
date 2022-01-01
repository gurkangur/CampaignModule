using System;

namespace CampaignModule.Application.Common
{
    public interface ITimeService
    {
        TimeSpan Now { get; }
        TimeSpan IncraseTime(int hour);
    }
}
