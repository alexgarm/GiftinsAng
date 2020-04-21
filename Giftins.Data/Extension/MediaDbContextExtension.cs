using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Giftins.Data
{
    public static class MediaDbContextExtension
    {
        public static void AddGiftinsMediaContext<T>(this IServiceCollection services,
            string msSqlConnectionString,
            Action<DbContextOptionsBuilder> setupDbContextOptions)
            where T : MediaDbContext
        {
            services.AddDbContext<T>(opts =>
            {
                if (!string.IsNullOrEmpty(msSqlConnectionString))
                    opts.UseSqlServer(msSqlConnectionString);

                setupDbContextOptions?.Invoke(opts);
            });

            if (typeof(T) != typeof(MediaDbContext))
                services.AddScoped<MediaDbContext>(s => s.GetRequiredService<T>());
        }

        public static void AddGiftinsMediaContext<T>(this IServiceCollection services,
            string msSqlConnectionString)
            where T : MediaDbContext
        {
            if (string.IsNullOrEmpty(msSqlConnectionString))
                throw new ArgumentNullException(nameof(msSqlConnectionString));

            services.AddGiftinsMediaContext<T>(msSqlConnectionString, null);
        }

        public static void AddGiftinsMediaContext<T>(this IServiceCollection services,
            Action<DbContextOptionsBuilder> setupDbContextOptions)
            where T : MediaDbContext
        {
            if (setupDbContextOptions == null)
                throw new ArgumentNullException(nameof(setupDbContextOptions));

            services.AddGiftinsMediaContext<T>(null, setupDbContextOptions);
        }
    }
}