using System;
using System.Collections.Generic;
using System.Text;

namespace Giftins.Core.Domain.Media
{
    public interface IPreviewImage
    {
        /// <summary>
        /// URL копии фотографии с максимальным размером 75x75px.
        /// </summary>
        string Photo75 { get; }
        /// <summary>
        /// URL копии фотографии с максимальным размером 200x200px.
        /// </summary>
        string Photo280 { get; }
        /// <summary>
        /// URL копии фотографии с максимальным размером 600x600px.
        /// </summary>
        string Photo600 { get; }
    }
}
