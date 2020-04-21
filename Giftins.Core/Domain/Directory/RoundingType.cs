using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Giftins.Core.ComponentModel;

namespace Giftins.Core.Domain.Directory
{
    /// <summary>
    /// Rounding type
    /// </summary>
    public sealed class RoundingType : ClassEnumeration<RoundingType>
    {
        public string Description { get; private set; }

        private const string ROUNDING001_DESCRIPTION = "Default rounding (Match.Round(num, 2))";
        public static readonly RoundingType Rounding001 = new RoundingType(0, "r001", ROUNDING001_DESCRIPTION);

        private const string ROUNDING005_UP_DESCRIPTION = "Prices are rounded up to the nearest multiple of 5 cents for sales ending in: 3¢ & 4¢ round to 5¢; and, 8¢ & 9¢ round to 10¢";
        public static readonly RoundingType Rounding005Up = new RoundingType(10, "r005up", ROUNDING005_UP_DESCRIPTION);


        private const string ROUNDING005_DOWN_DESCRIPTION = "Prices are rounded down to the nearest multiple of 5 cents for sales ending in: 1¢ & 2¢ to 0¢; and, 6¢ & 7¢ to 5¢";
        public static readonly RoundingType Rounding005Down = new RoundingType(20, "r005down", ROUNDING005_DOWN_DESCRIPTION);

        private const string ROUNDING01_UP_DESCRIPTION = "Round up to the nearest 10 cent value for sales ending in 5¢";
        public static readonly RoundingType Rounding01Up = new RoundingType(30, "r01up", ROUNDING01_UP_DESCRIPTION);
        
        private const string ROUNDING01_DOWN_DESCRIPTION = "Round down to the nearest 10 cent value for sales ending in 5¢";
        public static readonly RoundingType Rounding01Down = new RoundingType(40, "r01down", ROUNDING01_DOWN_DESCRIPTION);
        
        private const string ROUNDING01_DESCRIPTION = 
            "Sales ending in 1–24 cents round down to 0¢\r\n" +
            "Sales ending in 25–49 cents round up to 50¢\r\n" +
            "Sales ending in 51–74 cents round down to 50¢\r\n" +
            "Sales ending in 75–99 cents round up to the next whole dollar";
        public static readonly RoundingType Rounding05 = new RoundingType(50, "r05", ROUNDING01_DESCRIPTION);

        private const string ROUNDING1_DESCRIPTION =
            "Sales ending in 1–49 cents round down to 0\r\n" +
            "Sales ending in 50–99 cents round up to the next whole dollar\r\n";
        public static readonly RoundingType Rounding1 = new RoundingType(60, "r1", ROUNDING1_DESCRIPTION);

        private const string ROUNDING1_UP_DESCRIPTION = "Sales ending in 1–99 cents round up to the next whole dollar";
        public static readonly RoundingType Rounding1Up = new RoundingType(70, "r1up", ROUNDING1_UP_DESCRIPTION);

        public static RoundingType Default => Rounding001;

        private RoundingType(int id, string name, string description)
            : base(id, name)
        {
            Description = description;
        }
    }
}
