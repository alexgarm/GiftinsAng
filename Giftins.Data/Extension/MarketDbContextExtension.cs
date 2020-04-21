using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Giftins.Data
{
    public static class MarketDbContextExtension
    {
        public static void AddGiftinsMarketContext<T>(this IServiceCollection services,
            string msSqlConnectionString,
            Action<DbContextOptionsBuilder> setupDbContextOptions)
            where T : MarketDbContext
        {
            services.AddDbContext<T>(opts =>
            {
                if (!string.IsNullOrEmpty(msSqlConnectionString))
                    opts.UseSqlServer(msSqlConnectionString);

                setupDbContextOptions?.Invoke(opts);
            });

            if (typeof(T) != typeof(MarketDbContext))
                services.AddScoped<MarketDbContext>(s => s.GetRequiredService<T>());
        }

        public static void AddGiftinsMarketContext<T>(this IServiceCollection services,
            string msSqlConnectionString)
            where T : MarketDbContext
        {
            if (string.IsNullOrEmpty(msSqlConnectionString))
                throw new ArgumentNullException(nameof(msSqlConnectionString));

            services.AddGiftinsMarketContext<T>(msSqlConnectionString, null);
        }

        public static void AddGiftinsMarketContext<T>(this IServiceCollection services,
            Action<DbContextOptionsBuilder> setupDbContextOptions)
            where T : MarketDbContext
        {
            if (setupDbContextOptions == null)
                throw new ArgumentNullException(nameof(setupDbContextOptions));

            services.AddGiftinsMarketContext<T>(null, setupDbContextOptions);
        }
    }
}