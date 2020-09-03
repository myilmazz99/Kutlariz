using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kutlariz.Business.Services.ImageCDN
{
    public interface IImageService
    {
        Task<string> Upload(IFormFile image);
    }
}
