using System;
using System.Collections.Generic;
using System.Text;

namespace Kutlariz.Entities
{
    public class BirthdayPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string UserId { get; set; }
    }
}
