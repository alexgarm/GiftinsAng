using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Giftins.Core.Domain.User;

namespace Giftins.Data
{
    public static class AccountDbContextExtension
    {
        public static IdentityBuilder AddGiftinsAccountContext<T, TUser, TRole>(this IServiceCollection services,
            string msSqlConnectionString,
            Action<DbContextOptionsBuilder> setupDbContextOptions,
            Action<IdentityOptions> setupIdentity)
            where T : AccountDbContext
            where TUser : GiftinsUser
            where TRole : GiftinsRole
        {
            services.AddDbContext<T>(opts =>
            {
                if (!string.IsNullOrEmpty(msSqlConnectionString))
                    opts.UseSqlServer(msSqlConnectionString);

                setupDbContextOptions?.Invoke(opts);
            });

            if (typeof(T) != typeof(AccountDbContext))
                services.AddScoped<AccountDbContext>(s => s.GetRequiredService<T>());

            var idb = services.AddDefaultGiftinsIdentity<GiftinsUser, GiftinsRole, T>(setupIdentity);
            return idb;
        }

        #region AddGiftinsUserContext Alias
        public static IdentityBuilder AddGiftinsAccountContext<T, TUser, TRole>(this IServiceCollection services,
            Action<DbContextOptionsBuilder> setupDbContextOptions,
            Action<IdentityOptions> setupIdentity)
            where T : AccountDbContext
            where TUser : GiftinsUser
            where TRole : GiftinsRole
        {
            return services.AddGiftinsAccountContext<T, TUser, TRole>(null, setupDbContextOptions, setupIdentity);
        }

        public static IdentityBuilder AddGiftinsAccountContext<T>(this IServiceCollection services,
            string msSqlConnectionString,
            Action<DbContextOptionsBuilder> setupDbContextOptions,
            Action<IdentityOptions> setupIdentity)
            where T : AccountDbContext
        {
            return services.AddGiftinsAccountContext<T, GiftinsUser, GiftinsRole>(msSqlConnectionString, setupDbContextOptions, setupIdentity);
        }

        public static IdentityBuilder AddGiftinsAccountContext<T>(this IServiceCollection services,
            Action<DbContextOptionsBuilder> setupDbContextOptions,
            Action<IdentityOptions> setupIdentity)
            where T : AccountDbContext
        {
            return services.AddGiftinsAccountContext<T, GiftinsUser, GiftinsRole>(setupDbContextOptions, setupIdentity);
        }

        public static IdentityBuilder AddGiftinsAccountContext<T>(this IServiceCollection services,
            string msSqlConnectionString,
            Action<DbContextOptionsBuilder> setupDbContextOptions)
            where T : AccountDbContext
        {
            return services.AddGiftinsAccountContext<T>(msSqlConnectionString, setupDbContextOptions, null);
        }

        public static IdentityBuilder AddGiftinsAccountContext<T>(this IServiceCollection services,
            Action<DbContextOptionsBuilder> setupDbContextOptions)
            where T : AccountDbContext
        {
            return services.AddGiftinsAccountContext<T>(setupDbContextOptions, null);
        }
        #endregion

        public static IdentityBuilder AddDefaultGiftinsIdentity<TUser, TRole, T>(this IServiceCollection services, Action<IdentityOptions> configure = null)
            where TUser : GiftinsUser
            where TRole : GiftinsRole
            where T : AccountDbContext
        {
            var idb = services.AddIdentity<GiftinsUser, GiftinsRole>(options =>
            {
                options.User.RequireUniqueEmail = true;

                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 3;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;

                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;

                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);

                configure?.Invoke(options);
            });

            idb.AddEntityFrameworkStores<T>();
            idb.AddDefaultTokenProviders();
            idb.AddUserStore<UserStore<TUser, TRole, T>>();
            idb.AddRoleStore<RoleStore<TRole, T>>();

            return idb;
        }

        #region AddDefaultGiftinsIdentity Alias
        public static IdentityBuilder AddDefaultGiftinsIdentity<TUser, TRole>(this IServiceCollection services, Action<IdentityOptions> configure = null)
            where TUser : GiftinsUser
            where TRole : GiftinsRole
        {
            return services.AddDefaultGiftinsIdentity<TUser, TRole, AccountDbContext>(configure);
        }

        public static IdentityBuilder AddDefaultGiftinsIdentity(this IServiceCollection services)
        {
            return services.AddDefaultGiftinsIdentity<GiftinsUser, GiftinsRole>(null);
        }
        #endregion
    }
}
