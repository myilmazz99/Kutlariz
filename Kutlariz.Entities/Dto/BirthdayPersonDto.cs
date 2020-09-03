using System;
using System.Collections.Generic;
using System.Text;

namespace Kutlariz.Entities.Dto
{
    public class BirthdayPersonDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string FirstLetter { get; set; }
        public int DaysUntilBirthday { get; set; }
        public string TimeUntilBirthday { get; set; }
        public string UserId { get; set; }
    }
}
