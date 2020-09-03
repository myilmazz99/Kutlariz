using System;
using System.Collections.Generic;
using System.Text;

namespace Kutlariz.Entities.Dto
{
    public class DisplayOrderDto
    {
        public int Id { get; set; }
        public string BirthdayPersonName { get; set; }
        public string BirthdayPersonProfilePictureUrl { get; set; }
        public CakeType CakeType { get; set; }
        public string CakeIngredients { get; set; }
        public string Message { get; set; }
        public byte CakeSize { get; set; }
        public string AddressDescription { get; set; }
        public string Neigborhood { get; set; }
        public string State { get; set; }
        public Status Status { get; set; }
        public string PhoneNumber { get; set; }
        public string CakePicture { get; set; }
        public double Price { get; set; }
    }
}
