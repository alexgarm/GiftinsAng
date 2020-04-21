using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using MediatR.Pipeline;

using Giftins.Core.Configuration;
using Giftins.Core.Domain.User;
using Giftins.Core.Infrastructure;
using Giftins.Core.ComponentModel.Validation;
using Giftins.Data;
using Giftins.Application.Infrastructure;
using Giftins.Application.Account.Get;

namespace Giftins.TestUtils
{
    using Giftins.Core.Domain.User.Validators;
    using Initializers;
    using System.Linq;

    public static class ServiceProviderFactory
    {
        public static IServiceProvider CreateGiftinsServicesCollection(string database = "InMemoryDbForTesting")
        {
            var services = new ServiceCollection();

            services.AddEntityFrameworkInMemoryDatabase();
            AddGiftinsDbContexts(services, database);
            AddDbInitializers(services);

            services.AddSingleton(new GiftinsConfig()
            {
                ReturnErrorDebugInfo = true
            });

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddMediatR(typeof(GetAccountByIdQueryHandler).GetTypeInfo().Assembly);

            AddValidators(services);

            return services.BuildServiceProvider();
        }

        private static void AddGiftinsDbContexts(ServiceCollection services, string database, 
            ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            services.AddDbContext<AccountDbContext>(options =>
            {
                options.UseInMemoryDatabase(database);
            }, lifetime);
            services.AddDefaultGiftinsIdentity<GiftinsUser, GiftinsRole>();

            services.AddDbContext<UserDbContext>(options =>
            {
                options.UseInMemoryDatabase(database);
            }, lifetime);

            services.AddDbContext<ProductDbContext>(options =>
            {
                options.UseInMemoryDatabase(database);
            }, lifetime);
            
            services.AddDbContext<OrderDbContext>(options =>
            {
                options.UseInMemoryDatabase(database);
            }, lifetime);
            
            services.AddDbContext<MediaDbContext>(options =>
            {
                options.UseInMemoryDatabase(database);
            }, lifetime);
            
            services.AddDbContext<MarketDbContext>(options =>
            {
                options.UseInMemoryDatabase(database);
            }, lifetime);
        }

        public static void AddDbInitializers(ServiceCollection services)
        {
            services.AddSingleton<BasicDummyInitializer>();
        }

        public static void AddValidators(ServiceCollection services)
        {
            Type type = typeof(IPropertiesValidator);
            Type genericType = typeof(IPropertiesValidator<>);
            Type propertyValidatorBase = typeof(PropertiesValidator);

            var validatorClasses = AppDomainTypeFinder.Global.FindClassesOfType(type, true);
            foreach (var vClass in validatorClasses)
            {
                var interfaces = vClass.GetInterfaces();
                var genericInterface = interfaces.FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == genericType);
                if (genericInterface == null)
                {
                    if (vClass != propertyValidatorBase)
                        services.AddSingleton(Activator.CreateInstance(vClass));
                }
                else
                {
                    if (genericInterface.GetGenericArguments()[0].GetConstructors().Any())
                        services.AddSingleton(genericInterface, Activator.CreateInstance(vClass));
                }
            }
        }
    }
}
