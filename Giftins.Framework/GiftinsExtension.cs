using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;
using MediatR.Pipeline;

using Giftins.Core.Domain.User;
using Giftins.Core.Configuration;
using Giftins.Data;
using Giftins.Application.Infrastructure;
using Giftins.Application.Account.Get;

namespace Giftins.Framework
{
    public static partial class GiftinsExtension
    {
        public static void AddGiftinsDbContexts<TAccount, TUser, TMedia, TMarket, TOrders>(this IServiceCollection services,
            string msSqlConnectionString,
            Action<GiftinsDbContextOptions> configure)
            where TAccount: AccountDbContext
            where TUser: UserDbContext
            where TMedia: MediaDbContext
            where TMarket: MarketDbContext
            where TOrders: OrderDbContext
        {
            GiftinsDbContextOptions options = new GiftinsDbContextOptions();
            configure?.Invoke(options);

            services.AddGiftinsAccountContext<TAccount, GiftinsUser, GiftinsRole>(msSqlConnectionString, options.Get<UserDbContext>(), null);
            services.AddGiftinsUserContext<TUser>(msSqlConnectionString, options.Get<UserDbContext>());
            services.AddGiftinsMediaContext<TMedia>(msSqlConnectionString, options.Get<MediaDbContext>());
            services.AddGiftinsMarketContext<TMarket>(msSqlConnectionString, options.Get<MarketDbContext>());
            services.AddGiftinsOrdersContext<TOrders>(msSqlConnectionString, options.Get<OrderDbContext>());
        }

        public static void AddGiftinsServices(this IServiceCollection services, Action<GiftinsConfig> configure)
        {
            var gConfig = new GiftinsConfig();
            configure?.Invoke(gConfig);
            services.AddSingleton(gConfig);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddMediatR(typeof(GetAccountByIdQueryHandler).GetTypeInfo().Assembly);
        }
    }
}
