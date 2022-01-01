using System;

namespace CampaignModule.Application.Common
{
    public class TimeService : ITimeService
    {
        private static TimeSpan _now = new TimeSpan(0, 0, 0);

        public TimeSpan Now => _now;

        public TimeSpan IncraseTime(int hour)
        {
            _now = _now.Add(new TimeSpan(hour, 0, 0));
            return _now;
        }
    }
}
