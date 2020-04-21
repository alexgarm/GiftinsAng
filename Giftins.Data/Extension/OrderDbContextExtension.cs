using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Giftins.Data
{
    public static class OrderDbContextExtension
    {
        public static void AddGiftinsOrdersContext<T>(this IServiceCollection services,
            string msSqlConnectionString,
            Action<DbContextOptionsBuilder> setupDbContextOptions)
            where T : OrderDbContext
        {
            services.AddDbContext<T>(opts =>
            {
                if (!string.IsNullOrEmpty(msSqlConnectionString))
                    opts.UseSqlServer(msSqlConnectionString);

                setupDbContextOptions?.Invoke(opts);
            });

            if (typeof(T) != typeof(OrderDbContext))
                services.AddScoped<OrderDbContext>(s => s.GetRequiredService<T>());
        }

        public static void AddGiftinsOrdersContext<T>(this IServiceCollection services,
            string msSqlConnectionString)
            where T : OrderDbContext
        {
            if (string.IsNullOrEmpty(msSqlConnectionString))
                throw new ArgumentNullException(nameof(msSqlConnectionString));

            services.AddGiftinsOrdersContext<T>(msSqlConnectionString, null);
        }

        public static void AddGiftinsOrdersContext<T>(this IServiceCollection services,
            Action<DbContextOptionsBuilder> setupDbContextOptions)
            where T : OrderDbContext
        {
            if (setupDbContextOptions == null)
                throw new ArgumentNullException(nameof(setupDbContextOptions));

            services.AddGiftinsOrdersContext<T>(null, setupDbContextOptions);
        }
    }
}