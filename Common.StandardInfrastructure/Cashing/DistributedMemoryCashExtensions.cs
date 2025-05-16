using Microsoft.Extensions.Caching.Distributed;
using System;

namespace Common.StandardInfrastructure.Cashing
{
    public static class DistributedMemoryCashExtensions
    {
        public static DistributedCacheEntryOptions Options(double? timeByMinutes = 30)
        {
            return new DistributedCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(timeByMinutes ?? 30));
        }
    } 
}
