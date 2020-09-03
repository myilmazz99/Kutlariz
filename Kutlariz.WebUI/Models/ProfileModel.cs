using Kutlariz.Entities;
using Kutlariz.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kutlariz.WebUI.Models
{
    public class ProfileModel
    {
        public ProfileModel()
        {
            BirthdayPeople = new List<BirthdayPersonDto>();
        }

        public UserDto User { get; set; }
        public List<BirthdayPersonDto> BirthdayPeople { get; set; }
    }
}
