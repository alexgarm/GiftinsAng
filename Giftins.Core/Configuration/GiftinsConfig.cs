using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Newtonsoft.Json;

namespace Giftins.Core.Configuration
{
    [DisplayName("System configuration")]
    [Description("Configuration for Giftins system")]
    public class GiftinsConfig
    {
        /// <summary>
        /// Возвращать вместе с описанием ошибки данные из <see cref="Exception"/>
        /// </summary>
        [JsonProperty(PropertyName = "error_debug_info")]
        [DisplayName("Error debug info")]
        [Description("Add extended error information to error messages")]
        public bool ReturnErrorDebugInfo { get; set; } = true;

        [JsonProperty(PropertyName = "db_table_prefix")]
        [DisplayName("DB table prefix")]
        [Description("Prefix to add to tablenames")]
        public string TablePrefix { get; set; } = "Giftins";
    }
}
