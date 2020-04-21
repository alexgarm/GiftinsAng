using System;
using System.Collections.Generic;
using System.Text;

namespace Giftins.Core.Domain.Media
{
    public class Picture : IPreviewImage
    {
        /// <summary>
        /// ID фотографии
        /// </summary>
        public string Id { get; protected set; }
                
        /// <summary>
        /// Id загрузившего фотографию
        /// </summary>
        public string UserId { get; protected set; }
        /// <summary>
        /// Дата добавления
        /// </summary>
        public DateTime UploadUtc { get; protected set; }

        /// <summary>
        /// URL копии фотографии с максимальным размером 75x75px.
        /// </summary>
        public string Photo75 { get; protected set; }
        /// <summary>
        /// URL копии фотографии с максимальным размером 200x200px.
        /// </summary>
        public string Photo280 { get; protected set; }
        /// <summary>
        /// URL копии фотографии с максимальным размером 600x600px.
        /// </summary>
        public string Photo600 { get; protected set; }
        /// <summary>
        /// URL фотографии с оригинальным размером.
        /// </summary>
        public string PhotoSrc { get; protected set; }

        /// <summary>
        /// Ширина оригинала фотографии в пикселах.
        /// </summary>
        public int Width { get; protected set; }
        /// <summary>
        /// Высота оригинала фотографии в пикселах.
        /// </summary>
        public int Height { get; protected set; }

        /// <summary>
        /// Foreign Key
        /// </summary>
        protected Picture()
        { }
    }
}
