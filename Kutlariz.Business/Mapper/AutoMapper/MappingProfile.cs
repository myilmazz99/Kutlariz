using AutoMapper;
using Kutlariz.Core.Entities;
using Kutlariz.Core.Utilities.Helpers;
using Kutlariz.Entities;
using Kutlariz.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kutlariz.Business.Mapper.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BirthdayPerson, BirthdayPersonDto>()
                .ForMember(d => d.FirstLetter, s => s.MapFrom(i => i.FirstName[0].ToString().ToUpper()))
                .ForMember(d => d.TimeUntilBirthday, s => s.MapFrom(i => CalculateTimeLeftTillBirthday.Calculate(i.Birthday)));
            CreateMap<BirthdayPersonDto, BirthdayPerson>();

            CreateMap<BirthdayPerson, AddOrUpdateBirthdayPersonDto>();
            CreateMap<AddOrUpdateBirthdayPersonDto, BirthdayPerson>();

            CreateMap<UserDto, ApplicationUser>();
            CreateMap<ApplicationUser, UserDto>()
                .ForMember(d => d.BirthdayShortDate, s => s.MapFrom(i => i.Birthday.ToShortDateString()));

            CreateMap<RegisterDto, ApplicationUser>()
                .ForMember(
                d => d.UserName,
                s => s.MapFrom(i => i.Email)
                );

            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();

            CreateMap<Order, DisplayOrderDto>();
            CreateMap<DisplayOrderDto, Order>();
        }
    }
}
