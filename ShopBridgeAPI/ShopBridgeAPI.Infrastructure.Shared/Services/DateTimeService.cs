using ShopBridgeAPI.Application.Interfaces;
using System;

namespace ShopBridgeAPI.Infrastructure.Shared.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
