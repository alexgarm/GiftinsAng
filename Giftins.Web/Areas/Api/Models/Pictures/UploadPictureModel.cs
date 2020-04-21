using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giftins.Web.Areas.Pictures.Models.Pictures
{
    public class ApiUploadPictureModel
    {
        public IFormFile File { get; set; }
    }
}
