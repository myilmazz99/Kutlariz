using Kutlariz.Entities;
using Kutlariz.Entities.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kutlariz.WebUI.Models
{
    public class OrderModel
    {
        public BirthdayPersonDto BirthdayPersonDetails { get; set; }
        public OrderDto Order { get; set; }
        public IFormFile BoutiqueCakePicture { get; set; }
    }
}
