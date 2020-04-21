using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Giftins.Data
{
    public static class UserDbContextExtension
    {
        public static void AddGiftinsUserContext<T>(this IServiceCollection services,
            string msSqlConnectionString,
            Action<DbContextOptionsBuilder> setupDbContextOptions)
            where T : UserDbContext
        {
            services.AddDbContext<T>(opts =>
            {
                if (!string.IsNullOrEmpty(msSqlConnectionString))
                    opts.UseSqlServer(msSqlConnectionString);

                setupDbContextOptions?.Invoke(opts);
            });

            if (typeof(T) != typeof(UserDbContext))
                services.AddScoped<UserDbContext>(s => s.GetRequiredService<T>());
        }

        public static void AddGiftinsUserContext<T>(this IServiceCollection services,
            string msSqlConnectionString)
            where T : UserDbContext
        {
            if (string.IsNullOrEmpty(msSqlConnectionString))
                throw new ArgumentNullException(nameof(msSqlConnectionString));

            services.AddGiftinsUserContext<T>(msSqlConnectionString, null);
        }

        public static void AddGiftinsUserContext<T>(this IServiceCollection services,
            Action<DbContextOptionsBuilder> setupDbContextOptions)
            where T : UserDbContext
        {
            if (setupDbContextOptions == null)
                throw new ArgumentNullException(nameof(setupDbContextOptions));

            services.AddGiftinsUserContext<T>(null, setupDbContextOptions);
        }
    }
}
