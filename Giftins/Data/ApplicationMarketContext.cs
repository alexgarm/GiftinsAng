using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Giftins.Core.Configuration;
using Giftins.Data;
using Microsoft.EntityFrameworkCore;

namespace Giftins.Web.Data
{
    public class ApplicationMarketContext : MarketDbContext
    {
        public ApplicationMarketContext(DbContextOptions<MarketDbContext> options , GiftinsConfig gconfig)
            : base(options , gconfig)
        {}
    }
}
