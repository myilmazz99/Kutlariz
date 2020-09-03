using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Imagekit;
using Kutlariz.Core.Extensions;

namespace Kutlariz.Business.Services.ImageCDN.ImagekitCDN
{
    public class ImageManager : IImageService
    {
        private readonly Imagekit.Imagekit imagekit;

        public ImageManager()
        {
            imagekit = new Imagekit.Imagekit(Keys.PublicKey, Keys.SecretKey, Keys.UrlEndpoint, "path");
        }

        public async Task<string> Upload(IFormFile image)
        {
            string fileName = Guid.NewGuid().ToString() + "_" + image.FileName;
            ImagekitResponse response = imagekit.FileName(fileName).Upload(await image.GetBytes());
            return (Keys.UrlEndpoint + response.FilePath);
        }
    }
}
