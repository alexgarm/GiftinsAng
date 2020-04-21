using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Giftins.Framework
{
    public class GiftinsDbContextOptions
    {
        private Dictionary<Type, Action<DbContextOptionsBuilder>> _config;

        public GiftinsDbContextOptions()
        {
            _config = new Dictionary<Type, Action<DbContextOptionsBuilder>>();
        }

        public void Set<T>(Action<DbContextOptionsBuilder> configure)
            where T: DbContext
        {
            _config[typeof(T)] = configure;
        }

        public Action<DbContextOptionsBuilder> Get<T>()
            where T: DbContext
        {
            var type = typeof(T);
            if (_config.ContainsKey(type))
                return _config[type];

            return null;
        }
    }
}
