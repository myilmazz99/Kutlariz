using System;
using System.Collections.Generic;
using System.Text;

namespace Kutlariz.Entities.Dto
{
    public class BirthdayPersonOrderDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string FirstLetter { get; set; }
        public DateTime Birthday { get; set; }
    }
}
